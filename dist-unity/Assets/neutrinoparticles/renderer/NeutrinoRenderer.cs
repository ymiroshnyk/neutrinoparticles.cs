using UnityEngine;
using UnityEngine.Rendering;

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Neutrino.Unity3D
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class NeutrinoRenderer : MonoBehaviour
	{
		#region Fields
		public bool simulateInWorldSpace = true;

		private Neutrino.EffectModel neutrinoEffectModel_;
		private Neutrino.Effect neutrinoEffect_;

		private Material[] materials_;
		private Shader shaderNormal_;
		private Shader shaderAdd_;
		private Shader shaderMultiply_;

		NeutrinoRenderBuffer renderBuffer_;
		#endregion

		#region Methods

		void Awake()
		{
			shaderNormal_ = Shader.Find("Neutrino/Normal");
			shaderAdd_ = Shader.Find("Neutrino/Add");
			shaderMultiply_ = Shader.Find("Neutrino/Multiply");
		}

		void Start()
		{
			Component[] components = GetComponents<MonoBehaviour>();
			foreach (Component c in components)
			{
				if (c is Neutrino.EffectModel)
					neutrinoEffectModel_ = c as Neutrino.EffectModel;
			}

			Mesh mesh = new Mesh();
			gameObject.GetComponent<MeshFilter>().mesh = mesh;
			renderBuffer_ = new NeutrinoRenderBuffer(mesh);

			neutrinoEffect_ = new Neutrino.Effect(neutrinoEffectModel_, renderBuffer_,
				simulateInWorldSpace ? 
					Neutrino._math.vec3_(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) :
					Neutrino._math.vec3_(0, 0, 0),
				simulateInWorldSpace ?
					Neutrino._math.quat_(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z) :
					Neutrino._math.quat_(1, 0, 0, 0));

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
		}

		void Update()
		{
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
				Neutrino._math.vec3 pos = Neutrino._math.vec3_(transform.position.x, transform.position.y, transform.position.z);

				neutrinoEffect_.update(Time.deltaTime, pos, rot);
				neutrinoEffect_.updateRenderBuffer(cameraRight, cameraUp, cameraDir, pos, rot);
			}
			else
			{
				Neutrino._math.quat invRot = Neutrino._math.inverseq_(rot);
				Neutrino._math.vec3 localCameraRight = Neutrino._math.applyv3quat_(cameraRight, invRot);
				Neutrino._math.vec3 localCameraUp = Neutrino._math.applyv3quat_(cameraUp, invRot);
				Neutrino._math.vec3 localCameraDir = Neutrino._math.applyv3quat_(cameraDir, invRot);

				neutrinoEffect_.update(Time.deltaTime, null, null);
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
	}
}