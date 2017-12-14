using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Neutrino.Unity3D
{
	[CustomEditor(typeof(NeutrinoRenderer), true)]
	public class NeutrinoRendererEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			NeutrinoRenderer renderer = (NeutrinoRenderer)target;
			Neutrino.Effect effect = renderer.neutrinoEffect();

			GUILayout.BeginHorizontal ();

			if (GUILayout.Button("Restart")) 
			{
				renderer.reset();
			}

			bool paused = renderer.paused();
			if (GUILayout.Button(paused ? "Unpause" : "Pause")) 
			{
				Undo.RecordObject (renderer, paused ? "Unpause particle effect" : "Pause particles effect");

				if (paused)
					renderer.unpause ();
				else
					renderer.pause ();
			}

			bool generatorsPaused = renderer.generatorsPaused ();
			if (GUILayout.Button(generatorsPaused ? "Unpause generation" : "Pause generation")) 
			{
				Undo.RecordObject (renderer, generatorsPaused ? "Unpause generation in particle effect" : "Pause generation in particles effect");

				if (generatorsPaused)
					renderer.unpauseGenerators();
				else
					renderer.pauseGenerators();
			}

			GUILayout.EndHorizontal();

			for (int emitterIndex = 0; emitterIndex < effect.numEmitters(); ++emitterIndex)
			{
				Neutrino.Emitter emitter = effect.emitter(emitterIndex);

				if (emitter.model().numProperties() == 0)
					continue;

				EditorGUILayout.Space();
				EditorGUILayout.LabelField(emitter.model().name());
				EditorGUI.indentLevel++;

				for (int propIndex = 0; propIndex < emitter.model().numProperties(); ++propIndex)
				{
					string name = emitter.model().propertyName(propIndex);

					switch (emitter.model().propertyType(propIndex))
					{
						case Neutrino.EmitterModel.PropertyType.FLOAT:
							{
								float valueBefore = (float)emitter.propertyValue(propIndex);
								float valueAfter = EditorGUILayout.FloatField(name, valueBefore);
								emitter.setPropertyValue(propIndex, valueAfter);
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC2:
							{
								_math.vec2 valueBefore = (_math.vec2)emitter.propertyValue(propIndex);
								UnityEngine.Vector2 valueAfter = EditorGUILayout.Vector2Field(name,
									new UnityEngine.Vector2(valueBefore.x, valueBefore.y));
								emitter.setPropertyValue(propIndex, _math.vec2_(valueAfter.x, valueAfter.y));
							}
							break;
						case Neutrino.EmitterModel.PropertyType.VEC3:
							{
								_math.vec3 valueBefore = (_math.vec3)emitter.propertyValue(propIndex);
								UnityEngine.Vector3 valueAfter = EditorGUILayout.Vector3Field(name,
									new UnityEngine.Vector3(valueBefore.x, valueBefore.y, valueBefore.z));
								emitter.setPropertyValue(propIndex, _math.vec3_(valueAfter.x, valueAfter.y, valueAfter.z));
							}
							break;
						case Neutrino.EmitterModel.PropertyType.QUAT:
							break;
					}
				}

				EditorGUI.indentLevel--;
			}
		}
	}
}
