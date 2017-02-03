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
			Neutrino.NMath.copyv3(out position_, position);

			renderBuffer_ = new RenderBuffers(model_.context());
			neutrinoEffect_ = new Neutrino.System(model_.systemImpl(), renderBuffer_, position_);
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

			Neutrino.NMath.vec3? renderModelPosition = null;
			Neutrino.NMath.quat? renderModelRotation = null;

			if (!modelMatrix.Equals(Matrix4.Identity))
			{
				renderModelPosition = Neutrino.NMath.vec3_(
					modelMatrix[3].x, modelMatrix[3].y, modelMatrix[3].z);

				renderModelRotation = Neutrino.NMath.axes2quat_(
					Neutrino.NMath.vec3_(modelMatrix[0].x, modelMatrix[0].y, modelMatrix[0].z),
					Neutrino.NMath.vec3_(modelMatrix[1].x, modelMatrix[1].y, modelMatrix[1].z),
					Neutrino.NMath.vec3_(modelMatrix[2].x, modelMatrix[2].y, modelMatrix[2].z));
			}

			Vector4 cx = cameraMatrix[0];
			Vector4 cy = cameraMatrix[1];
			Vector4 cz = -cameraMatrix[2];

			neutrinoEffect_.updateRenderBuffer(
					Neutrino.NMath.vec3_(cx[0], cx[1], cx[2]), // camera right vector
					Neutrino.NMath.vec3_(cy[0], cy[1], cy[2]), // camera up vector
					Neutrino.NMath.vec3_(cz[0], cz[1], cz[2]), // camera direction vector

					renderModelPosition, renderModelRotation // position and rotation which will be used on render
					);

			renderBuffer_.updateGlBuffers();
			renderBuffer_.bind();			

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