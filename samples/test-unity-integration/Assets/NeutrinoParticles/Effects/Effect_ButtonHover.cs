// f87dfcb7-eb51-4b81-966f-3dc5bf3d5928

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_ButtonHover : NeutrinoRenderer
	{
		public class Model : EffectModel
		{
			public class Emitter_DefaultEmitter : EmitterModel
			{
				public class ParticleImpl : Particle
				{
					public float _lifetime;
					public float _Max_Life;
					public _math.vec3 _Position;
					public _math.vec3 _Velocity;
					public float _Angle;
					public float _Size;
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
					public _math.vec3 _BottomLeft = _math.vec3_(-100F,0F,0F);
					public _math.vec3 _BottomRight = _math.vec3_(100F,0F,0F);
					public float _MaxLife = 1;
					public _math.vec3 _Color = _math.vec3_(0F,0.8F,1F);
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 50F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return 1F; }
					public float startPhase() { return 1F; }
					public float rate() { return 5F; }
				}

				float [][][] _plot = 
				{
					new float[][] { new float[]{ 0F,1F,1F }, new float[]{ 1F,0F,0F }}
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
					particleImpl._Max_Life = emitterData._MaxLife;
					float rnd_ = 0F + emitter.random()() * (1F - 0F);
					_math.vec3 expr_ = _math.addv3_(emitterData._BottomLeft, _math.mulv3scalar_(_math.subv3_(emitterData._BottomRight, emitterData._BottomLeft), rnd_));
					particleImpl._Position = _math.addv3_(expr_, emitter.position());
					float rnd_a = -10F + emitter.random()() * (10F - -10F);
					float rnd_b = 0F + emitter.random()() * (30F - 0F);
					float rnd_c = 0F + emitter.random()() * (0F - 0F);
					_math.vec3 value_ = _math.vec3_(rnd_a, rnd_b, rnd_c);
					particleImpl._Velocity = value_;
					particleImpl._Angle = 0F;
					float rnd_d = 10F + emitter.random()() * (20F - 10F);
					particleImpl._Size = rnd_d;
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
					particleImpl._Max_Life = emitterData._MaxLife;
					float rnd_ = 0F + emitter.random()() * (1F - 0F);
					_math.vec3 expr_ = _math.addv3_(emitterData._BottomLeft, _math.mulv3scalar_(_math.subv3_(emitterData._BottomRight, emitterData._BottomLeft), rnd_));
					particleImpl._Position = _math.addv3_(expr_, emitter.position());
					float rnd_a = -10F + emitter.random()() * (10F - -10F);
					float rnd_b = 0F + emitter.random()() * (30F - 0F);
					float rnd_c = 0F + emitter.random()() * (0F - 0F);
					_math.vec3 value_ = _math.vec3_(rnd_a, rnd_b, rnd_c);
					particleImpl._Velocity = value_;
					particleImpl._Angle = 0F;
					float rnd_d = 10F + emitter.random()() * (20F - 10F);
					particleImpl._Size = rnd_d;
					particle.position_ = particleImpl._Position;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					_math.vec3 move_ = _math.addv3_(particleImpl._Position, _math.mulv3scalar_(particleImpl._Velocity, dt));
					particleImpl._Position = move_;
					particle.position_ = particleImpl._Position;
					if (particleImpl._lifetime > particleImpl._Max_Life) 
					{
						particle.dead_ = true;
					}
					float expr_ = (particleImpl._lifetime / particleImpl._Max_Life);
					float _plot_out;
					float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
					_math.PathRes _plot_srch0 = _plot_in0<0.0400778?_math.pathRes(0,(_plot_in0-0F)*24.9515F):_math.pathRes(1,(_plot_in0-0.0400778F)*1.04175F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float expr_a = (particleImpl._Size * _plot_out);
					particleImpl.size1_ = expr_a;
					particleImpl.color_ = emitterData._Color;
				}
				public Emitter_DefaultEmitter()
				{
					addProperty("BottomLeft", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._BottomLeft; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._BottomLeft, (_math.vec3)value); });
					addProperty("BottomRight", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._BottomRight; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._BottomRight, (_math.vec3)value); });
					addProperty("MaxLife", PropertyType.FLOAT, 
						(object emitterData) => { return ((EmitterData)emitterData)._MaxLife; }, 
						(object emitterData, object value) => { ((EmitterData)emitterData)._MaxLife = (float)value; });
					addProperty("Color", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._Color; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color, (_math.vec3)value); });
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
				textures_ = new string[] { "smoke01_white_blurred.png" };
				materials_ = new RenderMaterial[] { RenderMaterial.Add };
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

		return modelInstance_;
	}
	}
}

#pragma warning restore 219
