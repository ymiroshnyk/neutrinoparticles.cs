using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace Neutrino.Unity3D
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public abstract class NeutrinoRenderer : MonoBehaviour, ISerializationCallbackReceiver
	{
		#region Fields
		public bool simulateInWorldSpace = true;

		private bool neutrinoInited_ = false;
		private Neutrino.EffectModel neutrinoEffectModel_;
		private Neutrino.Effect neutrinoEffect_;

		private Material[] materials_;
		private Shader shaderNormal_;
		private Shader shaderAdd_;
		private Shader shaderMultiply_;

		NeutrinoRenderBuffer renderBuffer_;

		private float lastFrameTime_;
		#endregion

		#region Methods

		public Neutrino.Effect neutrinoEffect()
		{
			return neutrinoEffect_;
		}

		void Awake()
		{
			//Debug.Log("Awake()");

			shaderNormal_ = Shader.Find("Neutrino/Normal");
			shaderAdd_ = Shader.Find("Neutrino/Add");
			shaderMultiply_ = Shader.Find("Neutrino/Multiply");
		}

		void OnDestroy()
		{
			//Debug.Log("OnDestroy()");
		}

		void Start()
		{
			//Debug.Log("Start()");
					
		}

		void OnEnable()
		{
			//Debug.Log("OnEnable()");
		}

		void OnDisable()
		{
			//Debug.Log("OnDisable()");

			neutrinoEffectModel_ = null;
			neutrinoEffect_ = null;
			renderBuffer_ = null;
			neutrinoInited_ = false;

#if UNITY_EDITOR
			EditorApplication.update -= Update;
#endif
		}

		void Update()
		{
			if (!neutrinoInited_)
				initNeutrino();

			if (neutrinoEffect_ == null || neutrinoEffectModel_ == null )
				return;

#if UNITY_EDITOR
			float frameTime = Time.realtimeSinceStartup - lastFrameTime_;
			lastFrameTime_ = Time.realtimeSinceStartup;

			if (frameTime > 1)
				frameTime = 1;
#else
			float frameTime = Time.time - lastFrameTime_;
			lastFrameTime_ = Time.time;
#endif

			Transform camTrans = Camera.main.transform;

			Neutrino._math.vec3 cameraRight =
				Neutrino._math.vec3_(camTrans.right.x, camTrans.right.y, camTrans.right.z);
			Neutrino._math.vec3 cameraUp = 
				Neutrino._math.vec3_(camTrans.up.x, camTrans.up.y, camTrans.up.z);
			Neutrino._math.vec3 cameraDir =
				Neutrino._math.vec3_(camTrans.forward.x, camTrans.forward.y, camTrans.forward.z);

			Neutrino._math.quat rot = Neutrino._math.quat_(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z);

			if (simulateInWorldSpace)
			{
				Neutrino._math.vec3 pos = Neutrino._math.vec3_(transform.position.x / transform.localScale.x,
					transform.position.y / transform.localScale.y, 
					transform.position.z / transform.localScale.z);

				neutrinoEffect_.update(frameTime, pos, rot);
				neutrinoEffect_.updateRenderBuffer(cameraRight, cameraUp, cameraDir, pos, rot);
			}
			else
			{
				Neutrino._math.quat invRot = Neutrino._math.inverseq_(rot);
				Neutrino._math.vec3 localCameraRight = Neutrino._math.applyv3quat_(cameraRight, invRot);
				Neutrino._math.vec3 localCameraUp = Neutrino._math.applyv3quat_(cameraUp, invRot);
				Neutrino._math.vec3 localCameraDir = Neutrino._math.applyv3quat_(cameraDir, invRot);

				neutrinoEffect_.update(frameTime, null, null);
				neutrinoEffect_.updateRenderBuffer(localCameraRight, localCameraUp, localCameraDir, null, null);
			}

			renderBuffer_.updateMesh();

			Material[] subMeshMaterials = new Material[renderBuffer_.RenderCallsCount];

			for (uint renderCallIndex = 0; renderCallIndex < renderBuffer_.RenderCallsCount; ++renderCallIndex)
			{
				subMeshMaterials[renderCallIndex] = materials_[renderBuffer_.RenderCalls[renderCallIndex].renderStyleIndex_];
			}

			MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
			mr.sharedMaterials = subMeshMaterials;
		}

#endregion

#region DesignTime
		public float gizmoSize = 10;
		public void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, gizmoSize);
		}

		public void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, gizmoSize);
		}
#endregion

		private void initNeutrino()
		{
			//Debug.Log("initNeutrino()");

			neutrinoEffectModel_ = createModel();

			Mesh mesh = new Mesh();
			gameObject.GetComponent<MeshFilter>().mesh = mesh;
			renderBuffer_ = new NeutrinoRenderBuffer(mesh);

			neutrinoEffect_ = new Neutrino.Effect(neutrinoEffectModel_, renderBuffer_,
				simulateInWorldSpace ?
					Neutrino._math.vec3_(gameObject.transform.position.x / gameObject.transform.localScale.x,
					gameObject.transform.position.y / gameObject.transform.localScale.y,
					gameObject.transform.position.z / gameObject.transform.localScale.z) :
					Neutrino._math.vec3_(0, 0, 0),
				simulateInWorldSpace ?
					Neutrino._math.quat_(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z) :
					Neutrino._math.quat_(1, 0, 0, 0));

			deserializeToEffect();

			// preparing materials
			{
				string[] textures = neutrinoEffectModel_.textures();
				RenderStyle[] renderStyles = neutrinoEffectModel_.renderStyles();

				materials_ = new Material[renderStyles.Length];

				for (int i = 0; i < renderStyles.Length; ++i)
				{
					Material material;

					switch (neutrinoEffectModel_.materials()[renderStyles[i].material_])
					{
						default:
							material = new Material(shaderNormal_);
							break;

						case Neutrino.RenderMaterial.Add:
							material = new Material(shaderAdd_);
							break;

						case Neutrino.RenderMaterial.Multiply:
							material = new Material(shaderMultiply_);
							break;
					}

					string filename = Path.GetFileNameWithoutExtension(
						textures[renderStyles[i].textureIndex_[0]]);

					if (string.IsNullOrEmpty(filename))
					{
						Debug.LogError("Texture file name is empty or incorrect " +
							textures[renderStyles[i].textureIndex_[0]]);
						return;
					}

					Texture texture = Resources.Load(filename) as Texture;
					if (texture == null)
					{
						Debug.LogError("Unable to load texture from Resources: " + filename);
						return;
					}

					material.name = filename;
					material.SetTexture("_MainTex", texture);

					materials_[i] = material;
				}
			}

			neutrinoInited_ = true;

#if UNITY_EDITOR
			lastFrameTime_ = Time.realtimeSinceStartup;
#else
			lastFrameTime_ = Time.time;
#endif

#if UNITY_EDITOR
			EditorApplication.update += Update;
#endif
		}

		[Serializable]
		private class SerializableProperty
		{
			public string name_;
			public List<float> value_ = new List<float>();
		}

		[Serializable]
		private class SerializableEmitter
		{
			public string name_;
			public List<SerializableProperty> properties_ = new List<SerializableProperty>();
		}

		[Serializable]
		private class SerializableEffect
		{
			public List<SerializableEmitter> emitters_ = new List<SerializableEmitter>();
		}

		[HideInInspector]
		[SerializeField]
		private SerializableEffect serializableEffect_ = new SerializableEffect();

		public void OnBeforeSerialize()
		{
			Neutrino.Effect effect = neutrinoEffect_;
			if (effect == null)
				return;

			serializableEffect_.emitters_.Clear();

			for (int emitterIndex = 0; emitterIndex < effect.numEmitters(); ++emitterIndex)
			{
				Neutrino.Emitter emitter = effect.emitter(emitterIndex);

				var serialEmitter = new SerializableEmitter();
				serialEmitter.name_ = emitter.model().name();
				serializableEffect_.emitters_.Add(serialEmitter);

				for (int propIndex = 0; propIndex < emitter.model().numProperties(); ++propIndex)
				{
					var serialProp = new SerializableProperty();
					serialProp.name_ = emitter.model().propertyName(propIndex);
					serialEmitter.properties_.Add(serialProp);

					switch (emitter.model().propertyType(propIndex))
					{
						case Neutrino.EmitterModel.PropertyType.FLOAT:
							{
								float value = (float)emitter.propertyValue(propIndex);
								serialProp.value_.Add(value);
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC2:
							{
								_math.vec2 value = (_math.vec2)emitter.propertyValue(propIndex);
								serialProp.value_.Add(value.x);
								serialProp.value_.Add(value.y);
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC3:
							{
								_math.vec3 value = (_math.vec3)emitter.propertyValue(propIndex);
								serialProp.value_.Add(value.x);
								serialProp.value_.Add(value.y);
								serialProp.value_.Add(value.z);
							}
							break;
						case Neutrino.EmitterModel.PropertyType.QUAT:
							// none until inspector is ready for quaternions
							break;
					}
				}
			}
		}

		public void OnAfterDeserialize()
		{
			if (neutrinoEffect_ != null)
				deserializeToEffect();
		}

		private void deserializeToEffect()
		{
			if (serializableEffect_ == null)
				return;

			Neutrino.Effect effect = neutrinoEffect_;

			for (int emitterIndex = 0; emitterIndex < serializableEffect_.emitters_.Count; ++emitterIndex)
			{
				var serialEmitter = serializableEffect_.emitters_[emitterIndex];

				Neutrino.Emitter emitter = effect.emitter(serialEmitter.name_);
				if (emitter == null)
					continue;

				for (int propIndex = 0; propIndex < serialEmitter.properties_.Count; ++propIndex)
				{
					var serialProp = serialEmitter.properties_[propIndex];

					var propType = emitter.model().propertyType(serialProp.name_);
					if (propType == null)
						continue;

					switch (propType.Value)
					{
						case Neutrino.EmitterModel.PropertyType.FLOAT:
							{
								if (serialProp.value_.Count == 1)
									emitter.setPropertyValue(serialProp.name_, serialProp.value_[0]);
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC2:
							{
								if (serialProp.value_.Count == 2)
									emitter.setPropertyValue(serialProp.name_, 
										_math.vec2_(serialProp.value_[0], serialProp.value_[1]));
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC3:
							{
								if (serialProp.value_.Count == 3)
									emitter.setPropertyValue(serialProp.name_,
										_math.vec3_(serialProp.value_[0], serialProp.value_[1], serialProp.value_[2]));
							}
							break;
						case Neutrino.EmitterModel.PropertyType.QUAT:
							// none until inspector is ready for quaternions
							break;
					}
				}
			}
		}

		public abstract EffectModel createModel();
	}
}