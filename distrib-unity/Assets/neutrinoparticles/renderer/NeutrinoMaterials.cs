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

		public void LoadTextures(string[] fileNames, Neutrino.RenderStyle[] renderStyles, int[] textureChannels)
		{
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

				materials[i] = new Material(standard);
				materials[i].name = filename;
				materials[i].SetTexture("_MainTex", texture);
			}
		}

		public void switchToNormal(uint index)
		{
			if (materials[index].shader != standard)
				materials[index].shader = standard;
		}

		public void switchToAdd(uint index)
		{
			if (materials[index].shader != additive)
				materials[index].shader = additive;
		}

		public void switchToMultiply(uint index)
		{
			if (materials[index].shader != multiply)
				materials[index].shader = multiply;
		}
		#endregion
	}
}