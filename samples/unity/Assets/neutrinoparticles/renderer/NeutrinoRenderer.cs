using UnityEngine;
using UnityEngine.Rendering;

using System.Collections;
using System.Collections.Generic;

namespace Neutrino.Unity3D
{
	//[ExecuteInEditMode] <--this feature is not available at the moment
	[RequireComponent(typeof(NeutrinoMaterials))]
	[RequireComponent(typeof(NeutrinoRenderBuffer))]
	public class NeutrinoRenderer : MonoBehaviour
	{
		#region Fields
		public bool simulateInWorldSpace = false;
		new Neutrino.System particleSystem;
		Neutrino.System.Impl particleSytemImpl;
		Neutrino.NMath.vec3 pos;
		private NMath.quat rot;

		NeutrinoMaterials nmaterials;
		NeutrinoRenderBuffer renderBuffer;
		//int layerMask = 1 << 1; //layer mask is: TransparentFX
		#endregion

		#region Methods
		private void RenderParticleSystem(CommandBuffer buf)
		{
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
				subMeshMaterials[renderCallIndex] = nmaterials.materials[renderBuffer.RenderCalls[renderCallIndex].renderStyleIndex_];
			}

			MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
			mr.sharedMaterials = subMeshMaterials;
		}

		// Use this for initialization
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

			nmaterials = GetComponent<NeutrinoMaterials>();
			nmaterials.LoadTextures(particleSytemImpl.textures(), particleSytemImpl, new int[] { 0 }); //simplification while texture channels are unsupported

			gameObject.AddComponent<MeshRenderer>();
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

			particleSystem.update(Time.smoothDeltaTime, pos);
			RenderParticleSystem(null);
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