# Neutrino Particles for Unity

This set of files implements renderer for [NeutrinoParticles](https://neutrinoparticles.com/) effects in the [Unity](https://unity3d.com/) engine.

TO DO
* **Currently only Main camera supported.** Geometry should be constructed for each camera before rendering, so all faced particles will look to the camera.
* Add resetting position of effect, to be able to jump by trailing effects.
* Add interface for changing properties of emitters.
* Add correct scaling of effects.

## Directory structure

* **/Assets/Plugins** - contains Neutrino.dll - the NeutrinoParticles library for C#. This is cross-platform system-independent library which can simulate effects, create generic geometry and give rendering instructions for that geometry.
* **/Assets/neutrinoparticles/neutrinoparticles.npproj** - project file for NeutrinoParticles Editor.
* **/Assets/neutrinoparticles/Resources** - your textures for effects.
* **/Assets/neutrinoparticles/export_unity** - exported effects will be here.
* **/Assets/neutrinoparticles/particles** - effects in the NeutrinoParticles Editor format.
* **/Assets/neutrinoparticles/renderer** - NeutrinoParticles renderer component files. These files implement wrapper around generic Neutrino effect, translate geometry to Unity's mesh and setup shaders for rendering.

## How to use

*You can find sample Unity project in /samples/unity directory of the repository.*

### Copy files

Copy content of this directory to your project's root directory.

### Create effects

In the *Assets/neutrinoparticles* directory you will find project file for NeutrinoParticles Editor. Open it in the Editor and create effects for your project.

You might want to learn [video tutorials](https://neutrinoparticles.com/editor-video-tutorials/) before you start creating effects. 

### Export effects

After you created effect, you need to export it. Please, refer to [this tutorial]() on how to export effects.

After effect exported, you will find file *Effect_your_effect_name.cs* in the */Assets/neutrinoparticles/export_unity* directory.

### Add effect to the scene

Open you project in Unity editor. 

Then create new empty object in the scene.

And drag your exported effect file from Project window of the Unity editor to your newly created object in the scene.

After that you should be able to see the effect in the scene.



