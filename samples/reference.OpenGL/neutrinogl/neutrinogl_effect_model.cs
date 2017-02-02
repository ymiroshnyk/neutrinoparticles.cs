using OpenGL;
using System;

namespace NeutrinoGl
{
	public class EffectModel
	{
		Context context_;

		Neutrino.System.Impl systemImpl_;
		Texture[] textures_;

		public EffectModel(Context context, Neutrino.System.Impl systemImpl)
		{
			context_ = context;
			systemImpl_ = systemImpl;

			uint numTextures = (uint)systemImpl.textures().Length;
			textures_ = new Texture[numTextures];
			for (uint texIndex = 0; texIndex < numTextures; ++texIndex)
			{
				textures_[texIndex] = new Texture(context_.texturesBasePath() + systemImpl.textures()[texIndex]);
			}
		}

		public void shutdown()
		{
			foreach (Texture texture in textures_)
				texture.Dispose();
		}

		public Context context() { return context_; }

		public Neutrino.System.Impl systemImpl() { return systemImpl_; }

		public Texture[] textures() { return textures_; }
	}
}