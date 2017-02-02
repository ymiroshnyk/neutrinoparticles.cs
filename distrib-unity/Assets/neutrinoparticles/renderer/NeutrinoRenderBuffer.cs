//#define CACHE_TESTING
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Neutrino.Unity3D
{
	public class NeutrinoRenderBuffer : MonoBehaviour, Neutrino.RenderBuffer
	{
		#region Fields
		[Tooltip("Activate the mechanism that will free memory used for indices cache. Might add some noticeable CPU overhead on complex effects")]
		public bool autoReleaseMemory = true;
		private List<Vector3> vertices;
		private List<Vector2> uv;
		private int[] allIndices;
		private List<int> indices;
		private List<Color> colors;

		private int vertexCount;
		private Mesh mesh;

		private RenderCall[] renderCalls;
		private int renderCallsCount;
		private Bounds bounds = new Bounds();
		#endregion

		#region Properties
		public Mesh Mesh
		{
			get
			{
				return mesh;
			}
		}

		public RenderCall[] RenderCalls
		{
			get
			{
				return renderCalls;
			}
		}

		public int RenderCallsCount
		{
			get
			{
				return renderCallsCount;
			}
		}
		#endregion

		#region Methods
		public void cleanup()
		{
			renderCallsCount = 0;
			vertexCount = 0;

			vertices.Clear();
			colors.Clear();
			uv.Clear();
		}

		public void initialize(uint maxNumVertices, uint[] texChannels, ushort[] indices, uint maxNumRenderCalls)
		{
			renderCallsCount = 0;
			vertexCount = 0;

			mesh = new Mesh();
			vertices = new List<Vector3>((int)maxNumVertices);
			uv = new List<Vector2>((int)maxNumVertices);
			colors = new List<Color>((int)maxNumVertices);

			mesh.MarkDynamic();
			gameObject.AddComponent<MeshFilter>().mesh = mesh;

			this.allIndices = Array.ConvertAll(indices, (ushort s) => { return (int)s; });
			this.indices = new List<int>(indices.Length);

			renderCalls = new RenderCall[maxNumRenderCalls];
		}

		public void pushRenderCall(ref RenderCall rc)
		{
			renderCalls[renderCallsCount++] = rc;
		}

		public void pushVertex(ref RenderVertex v)
		{
			Vector3 v3;
			v3.x = v.position_.x;
			v3.y = v.position_.y;
			v3.z = v.position_.z;
			vertices.Add(v3);

			Vector2 v2;
			v2.x = v.texCoords_[0][0];
			v2.y = v.texCoords_[0][1];
			uv.Add(v2);

			Color c;
			c.a = ((float)((v.color_ & 0xff000000) >> 24)) / 255f;
			c.r = ((float)(v.color_ & 0x000000ff)) / 255f;
			c.g = ((float)((v.color_ & 0x0000ff00) >> 8)) / 255f; 
			c.b = ((float)((v.color_ & 0x00ff0000) >> 16)) / 255f;
			colors.Add(c);

			++vertexCount;
		}

		public void updateIndices(int startingIndex, int indexCount, int subMeshId)
		{
			this.indices.Clear();
			int endIndex = startingIndex + indexCount;
			for (int i = startingIndex; i < endIndex; ++i)
				this.indices.Add(this.allIndices[i]);

			mesh.SetTriangles(this.indices, subMeshId);

			//seems like those calls are not required
			//mesh.RecalculateBounds();
			//mesh.RecalculateNormals(); //expensive call - uncomment only if needed
		}

		public void update(int subMeshCount)
		{
			if (vertexCount == 0)
				return;

			mesh.Clear(true);

			mesh.SetVertices(vertices);
			mesh.SetColors(colors);
			mesh.SetUVs(0, uv);
			mesh.subMeshCount = subMeshCount;


#if UNITY_EDITOR
			if (mesh.bounds.center != Vector3.zero)
			{
				bounds.SetMinMax(mesh.bounds.min, mesh.bounds.max);
				bounds.center = Vector3.zero;
				mesh.bounds = bounds;
			}
#endif
		}
	#endregion
	}
}