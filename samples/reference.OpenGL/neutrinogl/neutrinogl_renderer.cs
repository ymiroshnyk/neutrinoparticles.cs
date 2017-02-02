using OpenGL;
using System;
using System.Runtime.InteropServices;

partial class NeutrinoGl
{
	public class RendererGl
	{
		MaterialsGl materials_;
		RenderBufferGl renderBuffer_;
		Neutrino.System system_;
		Neutrino.NMath.vec3 position_;

		Texture[] textures_;

		public RendererGl(MaterialsGl materials, Neutrino.System.Impl systemImpl, String texturesPrefix, Neutrino.NMath.vec3 position)
		{
			materials_ = materials;

			renderBuffer_ = new RenderBufferGl();
			Neutrino.NMath.copyv3(out position_, position);

			system_ = new Neutrino.System(systemImpl, renderBuffer_, position_);

			uint numTextures = (uint)systemImpl.textures().Length;
			textures_ = new Texture[numTextures];
			for (uint texIndex = 0; texIndex < numTextures; ++texIndex)
			{
				textures_[texIndex] = new Texture(texturesPrefix + systemImpl.textures()[texIndex]);
			}
		}

		public void shutdown()
		{
			renderBuffer_.shutdown();

			foreach (Texture texture in textures_)
				texture.Dispose();
		}

		public void update(float dt, Neutrino.NMath.vec3 position)
		{
			Neutrino.NMath.copyv3(out position_, position);
			system_.update(dt, position_);
		}

		public void render(ref Matrix4 projMatrix, ref Matrix4 viewMatrix, ref Matrix4 modelMatrix)
		{
			materials_.setup(ref projMatrix, ref viewMatrix, ref modelMatrix);

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
				

			system_.updateRenderBuffer(
				Neutrino.NMath.vec3_(cx[0], cx[1], cx[2]),
				Neutrino.NMath.vec3_(cy[0], cy[1], cy[2]),
				Neutrino.NMath.vec3_(cz[0], cz[1], cz[2]),
				renderModelPosition, renderModelRotation);

			renderBuffer_.updateGlBuffers();

			// bind the vertex positions, UV coordinates and element array
			Gl.EnableVertexAttribArray((uint)materials_.positionAttribLocation());
			Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.positionsId());
			Gl.VertexAttribPointer((uint)materials_.positionAttribLocation(), 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);

			Gl.EnableVertexAttribArray((uint)materials_.colorAttribLocation());
			Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.colorsId());
			Gl.VertexAttribPointer((uint)materials_.colorAttribLocation(), 4, VertexAttribPointerType.UnsignedByte, true, 0, IntPtr.Zero);

			if (renderBuffer_.numTexChannels() > 0)
			{
				Gl.EnableVertexAttribArray((uint)materials_.tex0AttribLocation());
				Gl.BindBuffer(BufferTarget.ArrayBuffer, renderBuffer_.texChannelId(0));
				Gl.VertexAttribPointer((uint)materials_.tex0AttribLocation(), (int)renderBuffer_.texChannelDimensions(0), VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
			}

			Gl.BindBuffer(BufferTarget.ElementArrayBuffer, renderBuffer_.indicesId());

			for (uint callIndex = 0; callIndex < renderBuffer_.numRenderCalls(); ++callIndex)
			{
				Neutrino.RenderCall rc = renderBuffer_.renderCalls()[callIndex];
				Neutrino.RenderStyle style = system_.impl().renderStyles()[rc.renderStyleIndex_];

				uint texIndex = style.textureIndex_[0];
				Gl.BindTexture(textures_[texIndex]);

				uint materialIndex = style.material_;
				Neutrino.RenderMaterial material = system_.impl().materials()[materialIndex];

				switch (material)
				{
					default: materials_.switchToNormal(); break;
					case Neutrino.RenderMaterial.Add: materials_.switchToAdd(); break;
					case Neutrino.RenderMaterial.Multiply: materials_.switchToMultiply(); break;
				}

				Gl.DrawElements(BeginMode.Triangles, (int)rc.numIndices_, DrawElementsType.UnsignedShort, (IntPtr)((uint)rc.startIndex_ * Marshal.SizeOf(typeof(ushort))));
			}
		}
	}
}