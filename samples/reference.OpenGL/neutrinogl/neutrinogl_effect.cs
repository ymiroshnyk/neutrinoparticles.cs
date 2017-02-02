using OpenGL;
using System;
using System.Runtime.InteropServices;

namespace NeutrinoGl
{
	public class Effect
	{
		EffectModel model_;
		RenderBuffers renderBuffer_;
		Neutrino.NMath.vec3 position_;
		Neutrino.System neutrinoEffect_;

		public Effect(EffectModel model, Neutrino.NMath.vec3 position)
		{
			model_ = model;

			renderBuffer_ = new RenderBuffers();
			neutrinoEffect_ = new Neutrino.System(model_.systemImpl(), renderBuffer_, position_);
			Neutrino.NMath.copyv3(out position_, position);
		}

		public void shutdown()
		{
			renderBuffer_.shutdown();
		}

		public void update(float dt, Neutrino.NMath.vec3 position)
		{
			Neutrino.NMath.copyv3(out position_, position);
			neutrinoEffect_.update(dt, position_);
		}

		public void render(ref Matrix4 projMatrix, ref Matrix4 viewMatrix, ref Matrix4 modelMatrix)
		{
			Materials materials = model_.context().materials();

			materials.setup(ref projMatrix, ref viewMatrix, ref modelMatrix);

			Matrix4 cameraMatrix = viewMatrix.Inverse();

			Vector4 cx = cameraMatrix[0];
			Vector4 cy = cameraMatrix[1];
			Vector4 cz = -cameraMatrix[2];

			Neutrino.NMath.vec3 renderModelPosition = Neutrino.NMath.vec3_(
				modelMatrix[3].x, modelMatrix[3].y, modelMatrix[3].z);
			Neutrino.NMath.quat renderModelRotation = Neutrino.NMath.axes2quat_(
				Neutrino.NMath.vec3_(modelMatrix[0].x, modelMatrix[0].y, modelMatrix[0].z),
				Neutrino.NMath.vec3_(modelMatrix[1].x, modelMatrix[1].y, modelMatrix[1].z),
				Neutrino.NMath.vec3_(modelMatrix[2].x, modelMatrix[2].y, modelMatrix[2].z));
				

			neutrinoEffect_.updateRenderBuffer(
				Neutrino.NMath.vec3_(cx[0], cx[1], cx[2]),
				Neutrino.NMath.vec3_(cy[0], cy[1], cy[2]),
				Neutrino.NMath.vec3_(cz[0], cz[1], cz[2]),
				renderModelPosition, renderModelRotation);

			renderBuffer_.updateGlBuffers();

			// bind the vertex positions, UV coordinates and element array
			Gl.EnableVertexAttribArray((uint)materials.positionAttribLocation());
			Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.positionsId());
			Gl.VertexAttribPointer((uint)materials.positionAttribLocation(), 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);

			Gl.EnableVertexAttribArray((uint)materials.colorAttribLocation());
			Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.colorsId());
			Gl.VertexAttribPointer((uint)materials.colorAttribLocation(), 4, VertexAttribPointerType.UnsignedByte, true, 0, IntPtr.Zero);

			if (renderBuffer_.numTexChannels() > 0)
			{
				Gl.EnableVertexAttribArray((uint)materials.tex0AttribLocation());
				Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.texChannelId(0));
				Gl.VertexAttribPointer((uint)materials.tex0AttribLocation(), (int)renderBuffer_.texChannelDimensions(0), VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
			}

			Gl.BindBuffer(BufferTarget.ElementArrayBuffer, renderBuffer_.indicesId());

			for (uint callIndex = 0; callIndex < renderBuffer_.numRenderCalls(); ++callIndex)
			{
				Neutrino.RenderCall rc = renderBuffer_.renderCalls()[callIndex];
				Neutrino.RenderStyle style = neutrinoEffect_.impl().renderStyles()[rc.renderStyleIndex_];

				uint texIndex = style.textureIndex_[0];
				Gl.BindTexture(model_.textures()[texIndex]);

				uint materialIndex = style.material_;
				Neutrino.RenderMaterial material = neutrinoEffect_.impl().materials()[materialIndex];

				switch (material)
				{
					default: materials.switchToNormal(); break;
					case Neutrino.RenderMaterial.Add: materials.switchToAdd(); break;
					case Neutrino.RenderMaterial.Multiply: materials.switchToMultiply(); break;
				}

				Gl.DrawElements(BeginMode.Triangles, (int)rc.numIndices_, DrawElementsType.UnsignedShort, (IntPtr)((uint)rc.startIndex_ * Marshal.SizeOf(typeof(ushort))));
			}
		}
	}
}