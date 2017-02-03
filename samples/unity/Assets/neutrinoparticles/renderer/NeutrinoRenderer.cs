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
		new Neutrino.System particleSystem;
		Neutrino.System.Impl particleSytemImpl;
		Neutrino.NMath.vec3 pos;
		private NMath.quat rot;

		Material[] materials;

		private Shader standard;
		private Shader multiply;
		private Shader additive;

		NeutrinoRenderBuffer renderBuffer;
		#endregion

		#region Methods

		void Awake()
		{
			standard = Shader.Find("Neutrino/Neutrino - AlphaBlended");
			multiply = Shader.Find("Neutrino/Neutrino - Multiply");
			additive = Shader.Find("Neutrino/Neutrino - Additive");
		}

		void Start()
		{
			if (simulateInWorldSpace)
				Neutrino.NMath.setv3(out pos, gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			else
			{
				Neutrino.NMath.setv3(out pos, 0f, 0f, 0f);
				Neutrino.NMath.setq(out rot, 0f, 0f, 0f, 0f);
			}

			Component[] components = GetComponents<MonoBehaviour>();
			foreach (Component c in components)
			{
				if (c is Neutrino.System.Impl)
					particleSytemImpl = c as Neutrino.System.Impl;
			}

			renderBuffer = GetComponent<NeutrinoRenderBuffer>();
			particleSystem = new Neutrino.System(particleSytemImpl, renderBuffer, pos);

			// preparing materials
			{
				string[] textures = particleSytemImpl.textures();
				RenderStyle[] renderStyles = particleSytemImpl.renderStyles();

				materials = new Material[renderStyles.Length];

				for (int i = 0; i < renderStyles.Length; ++i)
				{
					Material material;

					switch (particleSytemImpl.materials()[renderStyles[i].material_])
					{
						default:
							material = new Material(standard);
							break;

						case Neutrino.RenderMaterial.Add:
							material = new Material(additive);
							break;

						case Neutrino.RenderMaterial.Multiply:
							material = new Material(multiply);
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

					materials[i] = material;
				}
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (simulateInWorldSpace)
			{
				//Workaround for flipped moving effects
				//Mathf.Sign(transform.localScale.x) * transform.position.x,
				//	Mathf.Sign(transform.localScale.y) * transform.position.y,
				//	Mathf.Sign(transform.localScale.z) * transform.position.z);
				Neutrino.NMath.setv3(out pos, transform.position.x, transform.position.y, transform.position.z);
				Neutrino.NMath.setq(out rot, transform.rotation.w, transform.rotation.x, transform.rotation.y, transform.rotation.z);
			}

			particleSystem.update(Time.deltaTime, pos);

			//TODO: to support multiple cameras rendering - will probably require to switch rendering routine to CommandBuffer
			Transform camTrans = Camera.main.transform;

			if (simulateInWorldSpace)
			{
				particleSystem.updateRenderBuffer(
					Neutrino.NMath.vec3_(camTrans.right.x, camTrans.right.y, camTrans.right.z),
					Neutrino.NMath.vec3_(camTrans.up.x, camTrans.up.y, camTrans.up.z),
					Neutrino.NMath.vec3_(camTrans.forward.x, camTrans.forward.y, camTrans.forward.z),
					pos, rot);
			}
			else
			{
				//Neutrino.NMath.setv3(out pos, 0f, 0f, 0f);
				particleSystem.updateRenderBuffer(
					Neutrino.NMath.vec3_(camTrans.right.x, camTrans.right.y, camTrans.right.z),
					Neutrino.NMath.vec3_(camTrans.up.x, camTrans.up.y, camTrans.up.z),
					Neutrino.NMath.vec3_(camTrans.forward.x, camTrans.forward.y, camTrans.forward.z), pos);
			}

			renderBuffer.updateMesh();

			Material[] subMeshMaterials = new Material[renderBuffer.RenderCallsCount];

			for (uint renderCallIndex = 0; renderCallIndex < renderBuffer.RenderCallsCount; ++renderCallIndex)
			{
				subMeshMaterials[renderCallIndex] = materials[renderBuffer.RenderCalls[renderCallIndex].renderStyleIndex_];
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