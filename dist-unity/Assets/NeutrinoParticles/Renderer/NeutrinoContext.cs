using UnityEngine;

namespace Neutrino.Unity3D
{
	public class NeutrinoContext : MonoBehaviour
	{
		private static NeutrinoContext instance_ = null;

		private Shader shaderNormal_;
		private Shader shaderAdd_;
		private Shader shaderMultiply_;

		public Shader shaderNormal() { return shaderNormal_; }
		public Shader shaderAdd() { return shaderAdd_; }
		public Shader shaderMultiply() { return shaderMultiply_; }

		private NeutrinoContext()
		{
		}

		public static NeutrinoContext Instance
		{
			get
			{
				if (instance_ == null)
				{
					instance_ = FindObjectOfType<NeutrinoContext>();

					if (instance_ == null)
					{
						GameObject go = new GameObject();
						go.name = "_singleton_NeutrinoContext";
						instance_ = go.AddComponent<NeutrinoContext>();
#if !UNITY_EDITOR
						DontDestroyOnLoad(go);
#endif
					}

					instance_.reinitialize();
				}
				return instance_;
			}
		}

		void Awake()
		{
			if (instance_ == null)
			{
				instance_ = this;
#if !UNITY_EDITOR
				DontDestroyOnLoad(this.gameObject);
#endif
				reinitialize();
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void ensureNoiseIsGeneratedAndGenerateIfNecessary()
		{
			var noiseGenerator = Neutrino.Context.Instance.startNoiseGeneration();
			if (noiseGenerator != null)
			{
				while (!noiseGenerator.step()) { }
			}
			else
			{
				var watcher = Neutrino.Context.Instance.watchNoiseGeneration();
				while (!watcher.finished()) { }
			}
		}

		private void reinitialize()
		{
			shaderNormal_ = Shader.Find("Neutrino/Normal");
			shaderAdd_ = Shader.Find("Neutrino/Add");
			shaderMultiply_ = Shader.Find("Neutrino/Multiply");
		}
	}
}
