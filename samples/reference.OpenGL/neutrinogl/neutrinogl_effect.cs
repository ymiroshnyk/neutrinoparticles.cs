using OpenGL;
using System;
using System.Runtime.InteropServices;

namespace NeutrinoGl
{
	public class Effect
	{
		EffectModel model_;
		RenderBuffers renderBuffer_;
		Neutrino._math.vec3 position_;
		Neutrino._math.quat rotation_;
		Neutrino.Effect neutrinoEffect_;

		public Effect(EffectModel model, Neutrino._math.vec3? position, Neutrino._math.quat? rotation)
		{
			model_ = model;

			if (position != null)
				Neutrino._math.copyv3(out position_, position.Value);
			else
				Neutrino._math.setv3(out position_, 0, 0, 0);

			if (rotation != null)
				Neutrino._math.copyq(out rotation_, rotation.Value);
			else
				Neutrino._math.copyq(out rotation_, Neutrino._math.quat_(1, 0, 0, 0));

			renderBuffer_ = new RenderBuffers(model_.context());
			neutrinoEffect_ = new Neutrino.Effect(model_.neutrinoEffectModel(), renderBuffer_, position, rotation);
		}

		public void shutdown()
		{
			renderBuffer_.shutdown();
		}

		Neutrino.Effect neutrinoEffect()
		{
			return neutrinoEffect_;
		}

		public void update(float dt, Neutrino._math.vec3? position, Neutrino._math.quat? rotation)
		{
			if (position != null)
				Neutrino._math.copyv3(out position_, position.Value);

			if (rotation != null)
				Neutrino._math.copyq(out rotation_, rotation.Value);

			neutrinoEffect_.update(dt, position, rotation);
		}

		public void render(ref Matrix4 projMatrix, ref Matrix4 viewMatrix, ref Matrix4 modelMatrix)
		{
			Materials materials = model_.context().materials();

			materials.setup(ref projMatrix, ref viewMatrix, ref modelMatrix);

			Matrix4 cameraMatrix = viewMatrix.Inverse();

			Neutrino._math.vec3? renderModelPosition = null;
			Neutrino._math.quat? renderModelRotation = null;

			if (!modelMatrix.Equals(Matrix4.Identity))
			{
				renderModelPosition = Neutrino._math.vec3_(
					modelMatrix[3].x, modelMatrix[3].y, modelMatrix[3].z);

				renderModelRotation = Neutrino._math.axes2quat_(
					Neutrino._math.vec3_(modelMatrix[0].x, modelMatrix[0].y, modelMatrix[0].z),
					Neutrino._math.vec3_(modelMatrix[1].x, modelMatrix[1].y, modelMatrix[1].z),
					Neutrino._math.vec3_(modelMatrix[2].x, modelMatrix[2].y, modelMatrix[2].z));
			}

			Vector4 cx = cameraMatrix[0];
			Vector4 cy = cameraMatrix[1];
			Vector4 cz = -cameraMatrix[2];

			neutrinoEffect_.updateRenderBuffer(
					Neutrino._math.vec3_(cx[0], cx[1], cx[2]), // camera right vector
					Neutrino._math.vec3_(cy[0], cy[1], cy[2]), // camera up vector
					Neutrino._math.vec3_(cz[0], cz[1], cz[2]), // camera direction vector

					renderModelPosition, renderModelRotation // position and rotation which will be used on render
					);

			renderBuffer_.updateGlBuffers();
			renderBuffer_.bind();			

			for (uint callIndex = 0; callIndex < renderBuffer_.numRenderCalls(); ++callIndex)
			{
				Neutrino.RenderCall rc = renderBuffer_.renderCalls()[callIndex];
				Neutrino.RenderStyle style = neutrinoEffect_.model().renderStyles()[rc.renderStyleIndex_];

				uint texIndex = style.textureIndex_[0];
				Gl.BindTexture(model_.textures()[texIndex]);

				uint materialIndex = style.material_;
				Neutrino.RenderMaterial material = neutrinoEffect_.model().materials()[materialIndex];

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