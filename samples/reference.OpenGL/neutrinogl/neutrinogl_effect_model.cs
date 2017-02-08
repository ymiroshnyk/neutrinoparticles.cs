using OpenGL;
using System;

namespace NeutrinoGl
{
	public class EffectModel
	{
		Context context_;

		Neutrino.EffectModel neutrinoEffectModel_;
		Texture[] textures_;

		public EffectModel(Context context, Neutrino.EffectModel effectModel)
		{
			context_ = context;
			neutrinoEffectModel_ = effectModel;

			uint numTextures = (uint)effectModel.textures().Length;
			textures_ = new Texture[numTextures];
			for (uint texIndex = 0; texIndex < numTextures; ++texIndex)
			{
				textures_[texIndex] = new Texture(context_.texturesBasePath() + effectModel.textures()[texIndex]);
			}
		}

		public void shutdown()
		{
			foreach (Texture texture in textures_)
				texture.Dispose();
		}

		public Context context() { return context_; }

		public Neutrino.EffectModel neutrinoEffectModel() { return neutrinoEffectModel_; }

		public Texture[] textures() { return textures_; }
	}
}