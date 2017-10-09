// 35899246-c13d-4dbd-acc3-717c19bec032

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_Magic01 : NeutrinoRenderer
	{
		public class Model : EffectModel
		{
			public class Emitter_DefaultEmitter : EmitterModel
			{
				public class ParticleImpl : Particle
				{
					public float _lifetime;
					public _math.vec3 _Position;
					public float _Angle;
					public float _Color;
					public float _Rot__speed;
					public override _math.vec2 origin() { return _math.vec2_(0.6F,0.6F); }
					public override float angle() { return _Angle; }
					public override _math.quat rotation() { return _math.quat_(1, 0, 0, 0); }
					public float size1_;
					public override float size1() { return size1_; }
					public override _math.vec2 size2() { return _math.vec2_(0, 0); }
					public _math.vec3 color_;
					public override _math.vec3 color() { return color_; }
					public float alpha_;
					public override float alpha() { return alpha_; }
					public override float gridIndex() { return 0; }
					public override AttachedEmitter[] attachedEmitters() { return null; }

				}


				public class EmitterData
				{
					public _math.vec3 _Color1 = _math.vec3_(0.65F,0.27F,0.75F);
					public _math.vec3 _Color2 = _math.vec3_(1F,0.55F,0.75F);
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 1F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return null; }
					public float startPhase() { return 1F; }
					public float rate() { return 10F; }
				}

				float [][][] _plot = 
				{
					new float[][] { new float[]{ 0F,0.021076F,0.0476271F,0.0797259F,0.117482F,0.161046F,0.210616F,0.266445F,0.328851F,0.398229F,0.475073F,0.560002F,0.653796F,0.757454F,0.872276F,1F,1F }}
				};

				float [][][] _plota = 
				{
					new float[][] { new float[]{ 1F,1F,1F }, new float[]{ 1F,0F,0F }}
				};

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
					float rnd_ = 0F + emitter.random()() * (360F - 0F);
					particleImpl._Angle = rnd_;
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					particleImpl._Color = rnd_a;
					float rnd_b = 0F + emitter.random()() * (-90F - 0F);
					particleImpl._Rot__speed = rnd_b;
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
					float rnd_ = 0F + emitter.random()() * (360F - 0F);
					particleImpl._Angle = rnd_;
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					particleImpl._Color = rnd_a;
					float rnd_b = 0F + emitter.random()() * (-90F - 0F);
					particleImpl._Rot__speed = rnd_b;
					particle.position_ = particleImpl._Position;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					float move_ = particleImpl._Angle + particleImpl._Rot__speed * dt;
					particleImpl._Angle = move_;
					particle.position_ = particleImpl._Position;
					float value_ = 4F;
					if (particleImpl._lifetime > value_) 
					{
						particle.dead_ = true;
					}
					float value_a = 120F;
					float expr_ = (particleImpl._lifetime / value_);
					float _plot_out;
					float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*15F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float expr_a = (value_a * _plot_out);
					_math.vec3 expr_b = _math.addv3_(emitterData._Color1, _math.mulv3scalar_(_math.subv3_(emitterData._Color2, emitterData._Color1), particleImpl._Color));
					float _plota_out;
					float _plota_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
					_math.PathRes _plota_srch0 = _plota_in0<0.4?_math.pathRes(0,(_plota_in0-0F)*2.5F):_math.pathRes(1,(_plota_in0-0.4F)*1.66667F);
					_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
					particleImpl.size1_ = expr_a;
					particleImpl.color_ = expr_b;
					particleImpl.alpha_ = _plota_out;
				}
				public Emitter_DefaultEmitter()
				{
					addProperty("Color1", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._Color1; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color1, (_math.vec3)value); });
					addProperty("Color2", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._Color2; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color2, (_math.vec3)value); });
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
				textures_ = new string[] { "magic01.png" };
				materials_ = new RenderMaterial[] { RenderMaterial.Normal };
				renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
				frameTime_ = 0.0333333F;
				presimulateTime_ = 4F;
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

		return modelInstance_;
	}
	}
}

#pragma warning restore 219
