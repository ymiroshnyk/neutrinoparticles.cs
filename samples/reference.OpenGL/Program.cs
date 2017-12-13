using System;
using Tao.FreeGlut;
using OpenGL;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace OpenGLTutorial6
{
	class Program
	{
		private static int width = 1280, height = 720;
		private static System.Diagnostics.Stopwatch watch;
		private static NeutrinoGl.Context context_;
		private static NeutrinoGl.EffectModel effectModel_;
		private static NeutrinoGl.Effect effect_;
		private static float time_;
		private static float displace = 200.0f;

		static void Main(string[] args)
		{
			// create an OpenGL window
			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
			Glut.glutInitWindowSize(width, height);
			Glut.glutCreateWindow("OpenGL Tutorial");
			
			// provide the Glut callbacks that are necessary for running this tutorial
			Glut.glutIdleFunc(OnRenderFrame);
			Glut.glutDisplayFunc(OnDisplay);
			Glut.glutCloseFunc(OnClose);
			Glut.glutKeyboardFunc(OnKeyboard);

			time_ = 0;
			Matrix4 modelMatrix = CreateModelMatrix(time_);

			context_ = new NeutrinoGl.Context("..\\..\\effects\\textures\\");
			effectModel_ = new NeutrinoGl.EffectModel(context_, new Neutrino.Effect_params_test());
			effect_ = new NeutrinoGl.Effect(effectModel_, Neutrino._math.vec3_(modelMatrix[3].x, modelMatrix[3].y, modelMatrix[3].z), null);
			effect_.neutrinoEffect().setEmitterPropertyValue(null, "Color", Neutrino._math.vec3_(1, 1, 0));

			// load a crate texture
			watch = System.Diagnostics.Stopwatch.StartNew();

			Glut.glutMainLoop();
		}

		private static void OnClose()
		{
			effect_.shutdown();
			effectModel_.shutdown();
			context_.shutdown();
		}

		private static void OnDisplay()
		{

		}

		private static void OnRenderFrame()
		{
			// calculate how much time has elapsed since the last frame
			watch.Stop();
			float deltaTime = (float)watch.ElapsedTicks / System.Diagnostics.Stopwatch.Frequency;
			watch.Restart();

			Matrix4 modelMatrix = CreateModelMatrix(time_);

			time_ += deltaTime;
			effect_.update(deltaTime, Neutrino._math.vec3_(modelMatrix[3].x, modelMatrix[3].y, modelMatrix[3].z), null);
			
			// set up the OpenGL viewport and clear both the color and depth bits
			Gl.Viewport(0, 0, width, height);
			//Gl.ClearColor(0.5F, 0.5F, 0.5F, 0.0F);
			Gl.ClearColor(0.4F, 0.4F, 0.4F, 0.0F);
			Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			Matrix4 projMatrix = Matrix4.CreatePerspectiveFieldOfView(60F * (float)Math.PI / 180F, (float)width / height, 1F, 10000F); //.CreateOrthographic(width, height, 1F, 10000F);
			Matrix4 viewMatrix = Matrix4.LookAt(new Vector3(0, 0, 1000), Vector3.Zero, Vector3.Up);
			
			effect_.render(ref projMatrix, ref viewMatrix, ref modelMatrix);
			
			Glut.glutSwapBuffers();
		}

		private static bool paused = false;
		private static bool pausedGenerators = false;

		private static void OnKeyboard(byte key, int x, int y)
		{
			if (key == 13)
			{
				effect_.neutrinoEffect().reset(null, null);
			}
			else if (key == ' ')
			{
				if (!paused)
					effect_.neutrinoEffect().pause(null);
				else
				{
					effect_.neutrinoEffect().unpause(null);
				}

				paused = !paused;
			}
			else if (key == 'G')
			{
				if (!pausedGenerators)
					effect_.neutrinoEffect().pauseGenerators(null);
				else
				{
					effect_.neutrinoEffect().unpauseGenerators(null);
				}

				pausedGenerators = !pausedGenerators;
			}
		}

		private static Matrix4 CreateModelMatrix(float time_)
		{
			Matrix4 modelTranslationMatrix = Matrix4.CreateTranslation(new Vector3(displace, 0, 0));
			Matrix4 modelRotationMatrix = Matrix4.CreateRotationZ(time_);
			return modelTranslationMatrix * modelRotationMatrix;
		}
	}
}
