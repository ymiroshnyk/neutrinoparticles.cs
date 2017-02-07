# neutrinoparticles.cs
This library allows you to load and simulate particle effects exported from [NeutrinoParticles Editor](https://neutrinoparticles.com/).

The library is designed to be integrated in any engine/framework with C# environment and it doesn't use any system-dependent features. 

The library is distributed with a single Neutrino.dll file.

Below you will find samples on how to use it with clean OpenGL API.

Currently available integrations:
* [Unity3D official plugin](/distrib-unity/) ([https://unity3d.com/](https://unity3d.com/))

## Introduction
NeutrinoParticles Editor export effects to generic .cs file, which contains effect's properties and algorithms of particles' behaviour.

Neutrino.dll library contains all the code shared between effects (like mathematics and some algorithms).

Exported effect file has no textures inside it, but only their file names. All images loading you will need to handle on the application side. Usually, for that you will use capabilities of the framework/engine where you integrate this library.

Effect is divided into two parts: model and instance. Model is described as a class in exported from the editor .cs file. So, in general, to render effect you need to make next steps:

1. Attach effect's .cs file to the project in any suitable way.
2. Create object of the effect's model.
3. Load textures described in the model.
4. Create effect's instances. Each instance has own position and life time and will be simulated independently.
5. On each frame, update and render the effect's instances.

To make fully fledged integration of Neutrino effect to any engine/framework you will need to write custom code which makes these steps above.

As a reference, you can use sample reference.OpenGL, it shows you how to make such code for clean OpenGL environment (without any external texture loader, shaders loader etc.). You can find this sample in /samples/reference.OpenGL directory of the repository. And below you can find it's description.

## samples/reference.OpenGL

This sample uses OpenGL to render effects. It is based on the OpenGLTutorial6 code from [here](https://github.com/giawa/opengl4tutorials). There you can find video tutorial and source code for OpenGL programming on C#. It shows you how to load textures, create shaders and render geometry with loaded textures.

To create, update and render effect, several additional classes was made. They make all that five steps from above.

* *NeutrinoGl.Materials* - manages shaders and switches OpenGL state between different materials (blending modes).
* *NeutrinoGl.Context* - shared context for all effects. Holds single object of Materials and prefix path for textures.
* *NeutrinoGl.RenderBuffers* - inherits from Neutrino.RenderBuffer interface and receives geometry from effect. Before the rendering udpates OpenGL geometry buffers with received geometry.
* *NeutrinoGl.EffectModel* - wraps generic Neutrino.EffectModel and loads textures for it.
* *NeutrinoGl.Effect* - wraps generic Neutrino.Effect. Contains RenderBuffers which is passed to Neutrino.Effect to receive geometry.







