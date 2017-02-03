//#define CACHE_TESTING
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Neutrino.Unity3D
{
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class NeutrinoRenderBuffer : MonoBehaviour, Neutrino.RenderBuffer
	{
		#region Fields
		private Mesh mesh_;

		private List<Vector3> vertices_;
		private List<Vector2> uv_;
		private int[] allIndices_;
		private List<int> indices_;
		private List<Color> colors_;

		private int vertexCount_;

		private RenderCall[] renderCalls_;
		private int renderCallsCount_;

#if UNITY_EDITOR
		private Bounds bounds_ = new Bounds();
#endif
		#endregion

		#region Properties
		public Mesh Mesh
		{
			get
			{
				return mesh_;
			}
		}

		public RenderCall[] RenderCalls
		{
			get
			{
				return renderCalls_;
			}
		}

		public int RenderCallsCount
		{
			get
			{
				return renderCallsCount_;
			}
		}
		#endregion

		#region Methods

		void Start()
		{
			mesh_ = new Mesh();
			mesh_.MarkDynamic();
			gameObject.GetComponent<MeshFilter>().mesh = mesh_;
		}

		public void initialize(uint maxNumVertices, uint[] texChannels, ushort[] indices, uint maxNumRenderCalls)
		{
			renderCallsCount_ = 0;
			vertexCount_ = 0;

			vertices_ = new List<Vector3>((int)maxNumVertices);
			uv_ = new List<Vector2>((int)maxNumVertices);
			colors_ = new List<Color>((int)maxNumVertices);

			this.allIndices_ = Array.ConvertAll(indices, (ushort s) => { return (int)s; });
			this.indices_ = new List<int>(indices.Length);

			renderCalls_ = new RenderCall[maxNumRenderCalls];
		}

		public void cleanup()
		{
			renderCallsCount_ = 0;
			vertexCount_ = 0;

			vertices_.Clear();
			colors_.Clear();
			uv_.Clear();
		}

		public void pushRenderCall(ref RenderCall rc)
		{
			renderCalls_[renderCallsCount_++] = rc;
		}

		public void pushVertex(ref RenderVertex v)
		{
			Vector3 v3;
			v3.x = v.position_.x;
			v3.y = v.position_.y;
			v3.z = v.position_.z;
			vertices_.Add(v3);

			Vector2 v2;
			v2.x = v.texCoords_[0][0];
			v2.y = v.texCoords_[0][1];
			uv_.Add(v2);

			Color c;
			c.a = ((float)((v.color_ & 0xff000000) >> 24)) / 255f;
			c.r = ((float)(v.color_ & 0x000000ff)) / 255f;
			c.g = ((float)((v.color_ & 0x0000ff00) >> 8)) / 255f; 
			c.b = ((float)((v.color_ & 0x00ff0000) >> 16)) / 255f;
			colors_.Add(c);

			++vertexCount_;
		}

			//seems like those calls are not required
			//mesh.RecalculateBounds();
			//mesh.RecalculateNormals(); //expensive call - uncomment only if needed

		public void updateMesh()
		{
			if (vertexCount_ == 0)
				return;

			mesh_.Clear(true);

			mesh_.SetVertices(vertices_);
			mesh_.SetColors(colors_);
			mesh_.SetUVs(0, uv_);

			mesh_.subMeshCount = renderCallsCount_;

			for (uint renderCallIndex = 0; renderCallIndex < renderCallsCount_; ++renderCallIndex)
			{
				RenderCall rc = renderCalls_[renderCallIndex];

				this.indices_.Clear();
				int endIndex = rc.startIndex_ + rc.numIndices_;
				for (int i = rc.startIndex_; i < endIndex; ++i)
					this.indices_.Add(this.allIndices_[i]);

				mesh_.SetTriangles(this.indices_, (int)renderCallIndex);
			}


#if UNITY_EDITOR
			if (mesh_.bounds.center != Vector3.zero)
			{
				bounds_.SetMinMax(mesh_.bounds.min, mesh_.bounds.max);
				bounds_.center = Vector3.zero;
				mesh_.bounds = bounds_;
			}
#endif
		}
	#endregion
	}
}