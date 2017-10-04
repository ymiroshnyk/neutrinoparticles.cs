// 7c20261d-f5ef-45c9-94fb-882a80e3f1c9

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_Params_test : NeutrinoRenderer
	{
		public class Model : EffectModel
		{
			public class Emitter_DefaultEmitter : EmitterModel
			{
				public class ParticleImpl : Particle
				{
					public float _lifetime;
					public _math.vec3 _Position;
					public _math.vec3 _Velocity;
					public float _Angle;
					public override _math.vec2 origin() { return _math.vec2_(0.5F,0.5F); }
					public override float angle() { return _Angle; }
					public override _math.quat rotation() { return _math.quat_(1, 0, 0, 0); }
					public float size1_;
					public override float size1() { return size1_; }
					public override _math.vec2 size2() { return _math.vec2_(0, 0); }
					public _math.vec3 color_;
					public override _math.vec3 color() { return color_; }
					public override float alpha() { return 1; }
					public override float gridIndex() { return 0; }
					public override AttachedEmitter[] attachedEmitters() { return null; }

				}


				public class EmitterData
				{
					public _math.vec3 _Color = _math.vec3_(1F,1F,1F);
					public float _Turbulence = 200;
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 1F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return null; }
					public float startPhase() { return 1F; }
					public float rate() { return 25F; }
				}

				public class ConstructorImpl : ConstructorQuads.Impl
				{
					public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
					public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
					public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
					public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
					public ushort renderStyleIndex() { return 0; }
				}


				public override void updateEmitter(Emitter emitter)
				{
					EmitterData emitterData = (EmitterData)emitter.data();
					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				}

				public override void initParticle(Emitter emitter, Particle particle)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					float dt = 0;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime = 0F;
					_math.vec3 value_ = _math.vec3_(0F, 0F, 0F);
					particleImpl._Position = _math.addv3_(value_, emitter.position());
					_math.vec3 randvec_ = _math.randv3gen_(100F, emitter.random());
					particleImpl._Velocity = randvec_;
					particleImpl._Angle = 0F;
					particle.position_ = particleImpl._Position;
				}

				public override void initBurstParticle(Emitter emitter, Particle particle)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					float dt = 0;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime = 0F;
					_math.vec3 value_ = _math.vec3_(0F, 0F, 0F);
					particleImpl._Position = _math.addv3_(value_, emitter.position());
					_math.vec3 randvec_ = _math.randv3gen_(100F, emitter.random());
					particleImpl._Velocity = randvec_;
					particleImpl._Angle = 0F;
					particle.position_ = particleImpl._Position;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					_math.vec3 noise_a = _math.mulv3scalar_(_math.vec3_(100F,50F,30F), emitter.effect().time());
					_math.addv3(out noise_a, noise_a, particleImpl._Position);
					_math.vec3 noise_i = _math.mulv3scalar_(noise_a, 1.0F / 1000F); 
					_math.vec3 noise = _math.noisePixelLinear3_(noise_i);
					_math.mulv3(out noise, noise, _math.vec3_(0.0078125F,0.0078125F,0.0078125F));
					_math.addv3(out noise, noise, _math.vec3_(-1F,-1F,-1F));
					_math.mulv3scalar(out noise, noise, emitterData._Turbulence);
					_math.vec3 fmove_fs = noise;
					_math.vec3 fmove_vs = _math.vec3_(0F,0F,0F);
					_math.vec3 fmove_v = _math.addv3_(particleImpl._Velocity, _math.mulv3scalar_(fmove_fs, dt));
					_math.vec3 fmove_p = _math.mulv3scalar_(fmove_v, dt);
					_math.addv3(out fmove_p, fmove_p, particleImpl._Position);
					particleImpl._Position = fmove_p;
					particleImpl._Velocity = fmove_v;
					particle.position_ = particleImpl._Position;
					float value_ = 3F;
					if (particleImpl._lifetime > value_) 
					{
						particle.dead_ = true;
					}
					float value_a = 30F;
					particleImpl.size1_ = value_a;
					particleImpl.color_ = emitterData._Color;
				}
				public Emitter_DefaultEmitter()
				{
					addProperty("Color", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._Color; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color, (_math.vec3)value); });
					addProperty("Turbulence", PropertyType.FLOAT, 
						(object emitterData) => { return ((EmitterData)emitterData)._Turbulence; }, 
						(object emitterData, object value) => { ((EmitterData)emitterData)._Turbulence = (float)value; });
					generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
					constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
					name_ = "DefaultEmitter";
					maxNumParticles_ = 100;
					sorting_ = Emitter.Sorting.OldToYoung;
					particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
					emitterDataCreator_ = () => { return new EmitterData(); };
				}
			}

			public Model()
			{
				textures_ = new string[] { "star_glow_white.png" };
				materials_ = new RenderMaterial[] { RenderMaterial.Normal };
				renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
				frameTime_ = 0.0333333F;
				presimulateTime_ = 0F;
				maxNumRenderCalls_ = 100;
				maxNumParticles_ = 100;
				emitterModels_ = new EmitterModel[]{ new Emitter_DefaultEmitter() };
				activeEmitterModels_ = new uint[] { 0 };
				randomGeneratorCreator_ = () => { return _math.rand_; };
			}
		}
	static Model modelInstance_ = null;

	public override EffectModel createModel()
	{
		if (modelInstance_ == null)
			modelInstance_ = new Model();

		NeutrinoContext.Instance.ensureNoiseIsGeneratedAndGenerateIfNecessary();

		return modelInstance_;
	}
	}
}

#pragma warning restore 219
