using UnityEngine;
using System.Collections;
using System.IO;

namespace Neutrino.Unity3D
{
	public class NeutrinoMaterials : MonoBehaviour
	{
		#region Fields
		private const int DEFAULT_TEXTURE_CHANNEL = 0;

		[HideInInspector]
		public Material[] materials;

		private Shader standard;
		private Shader multiply;
		private Shader additive;
		#endregion

		#region Methods
		void Awake()
		{
			standard = Shader.Find("Neutrino/Neutrino - AlphaBlended");
			multiply = Shader.Find("Neutrino/Neutrino - Multiply");
			additive = Shader.Find("Neutrino/Neutrino - Additive");
		}

		public void LoadTextures(string[] fileNames, Neutrino.System.Impl systemImpl, int[] textureChannels)
		{
			RenderStyle[] renderStyles = systemImpl.renderStyles();
			
			materials = new Material[renderStyles.Length];

			for (int i = 0; i < renderStyles.Length; ++i)
			{
				string filename = Path.GetFileNameWithoutExtension(
					fileNames[renderStyles[i].textureIndex_[textureChannels[DEFAULT_TEXTURE_CHANNEL]]]);
				if (string.IsNullOrEmpty(filename))
				{
					Debug.LogError("Texture file name is empty or incorrect " +
						fileNames[renderStyles[i].textureIndex_[textureChannels[DEFAULT_TEXTURE_CHANNEL]]]);
					return;
				}

				Texture texture = Resources.Load(filename) as Texture;
				if (texture == null)
				{
					Debug.LogError("Unable to load texture from Resources: " + filename);
					return;
				}

				Material material;

				switch (systemImpl.materials()[renderStyles[i].material_])
				{
					default:
						material = new Material(standard);
						break;

					case Neutrino.RenderMaterial.Add:
						material = new Material(additive);
						break;

					case Neutrino.RenderMaterial.Multiply:
						material = new Material(multiply);
						break;
				}

				
				material.name = filename;
				material.SetTexture("_MainTex", texture);

				materials[i] = material;
			}
		}

		#endregion
	}
}