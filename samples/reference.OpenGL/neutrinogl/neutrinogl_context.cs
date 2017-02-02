using OpenGL;
using System;
using System.Runtime.InteropServices;

namespace NeutrinoGl
{
	public class Context
	{
		Materials materials_;
		String texturesBasePath_;

		public Context(String texturesBasePath)
		{
			materials_ = new Materials();
			texturesBasePath_ = texturesBasePath;
		}

		public void shutdown()
		{
			materials_.shutdown();
		}

		public Materials materials() { return materials_; }

		public String texturesBasePath() { return texturesBasePath_; }
	}
}
