using UnityEngine;
using UnityEngine.Rendering;

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Neutrino.Unity3D
{
	[RequireComponent(typeof(NeutrinoRenderBuffer))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteInEditMode]
	public class NeutrinoRenderer : MonoBehaviour
	{
		#region Fields
		public bool simulateInWorldSpace = true;

		private Neutrino.System.Impl neutrinoSystemImpl_;
		private Neutrino.System neutrinoSystem_;

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
				if (c is Neutrino.System.Impl)
					neutrinoSystemImpl_ = c as Neutrino.System.Impl;
			}

			renderBuffer_ = GetComponent<NeutrinoRenderBuffer>();
			neutrinoSystem_ = new Neutrino.System(neutrinoSystemImpl_, renderBuffer_,
				simulateInWorldSpace ? 
					Neutrino.NMath.vec3_(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) :
					Neutrino.NMath.vec3_(0, 0, 0));

			// preparing materials
			{
				string[] textures = neutrinoSystemImpl_.textures();
				RenderStyle[] renderStyles = neutrinoSystemImpl_.renderStyles();

				materials_ = new Material[renderStyles.Length];

				for (int i = 0; i < renderStyles.Length; ++i)
				{
					Material material;

					switch (neutrinoSystemImpl_.materials()[renderStyles[i].material_])
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

			Neutrino.NMath.vec3 cameraRight =
				Neutrino.NMath.vec3_(camTrans.right.x, camTrans.right.y, camTrans.right.z);
			Neutrino.NMath.vec3 cameraUp = 
				Neutrino.NMath.vec3_(camTrans.up.x, camTrans.up.y, camTrans.up.z);
			Neutrino.NMath.vec3 cameraDir =
				Neutrino.NMath.vec3_(camTrans.forward.x, camTrans.forward.y, camTrans.forward.z);

			Neutrino.NMath.quat rot = Neutrino.NMath.quat_(transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z);

			if (simulateInWorldSpace)
			{
				Neutrino.NMath.vec3 pos = Neutrino.NMath.vec3_(transform.position.x, transform.position.y, transform.position.z);

				neutrinoSystem_.update(Time.deltaTime, pos);
				neutrinoSystem_.updateRenderBuffer(cameraRight, cameraUp, cameraDir, pos, rot);
			}
			else
			{
				Neutrino.NMath.quat invRot = Neutrino.NMath.inverseq_(rot);
				Neutrino.NMath.vec3 localCameraRight = Neutrino.NMath.applyv3quat_(cameraRight, invRot);
				Neutrino.NMath.vec3 localCameraUp = Neutrino.NMath.applyv3quat_(cameraUp, invRot);
				Neutrino.NMath.vec3 localCameraDir = Neutrino.NMath.applyv3quat_(cameraDir, invRot);

				neutrinoSystem_.update(Time.deltaTime, Neutrino.NMath.vec3_(0, 0, 0));
				neutrinoSystem_.updateRenderBuffer(localCameraRight, localCameraUp, localCameraDir, null, null);
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