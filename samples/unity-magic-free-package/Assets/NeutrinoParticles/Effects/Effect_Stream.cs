// 7d505858-0d9e-4dee-bd56-390198f95d43

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_Stream : NeutrinoRenderer
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
					public _math.vec3 _Color;
					public float _Colora;
					public override _math.vec2 origin() { return _math.vec2_(0.5F,0.5F); }
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
					public _math.vec3 _Color1 = _math.vec3_(0F,0F,1F);
					public _math.vec3 _Color2 = _math.vec3_(0F,1F,1F);
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 1F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return null; }
					public float startPhase() { return 1F; }
					public float rate() { return 100F; }
				}

				float [][][] _plot = 
				{
					new float[][] { new float[]{ 0F,0.19159F,0.290298F,0.355081F,0.401548F,0.436788F,0.464891F,0.488638F,0.510213F,0.531602F,0.554907F,0.582751F,0.619006F,0.670675F,0.755057F,1F,1F }}
				};

				_math.vec2 [][,] _path = 
				{
					new _math.vec2[,] {{_math.vec2_(403F,43F)},{_math.vec2_(400F,-43F)},{_math.vec2_(400F,-43F)}}
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
					float rnd_ = 1F + emitter.random()() * (3F - 1F);
					particleImpl._Max_Life = rnd_;
					_math.vec3 value_ = _math.vec3_(0F, 0F, 0F);
					particleImpl._Position = _math.addv3_(value_, emitter.position());
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					float _plot_out;
					float _plot_in0=(rnd_a<0F?0F:(rnd_a>1F?1F:rnd_a));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*15F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float _path_in = _math.clamp_(_plot_out, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
					particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
					particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
					particleImpl._Angle = 0F;
					particleImpl._Color = emitterData._Color1;
					float rnd_b = 0F + emitter.random()() * (1F - 0F);
					particleImpl._Colora = rnd_b;
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
					float rnd_ = 1F + emitter.random()() * (3F - 1F);
					particleImpl._Max_Life = rnd_;
					_math.vec3 value_ = _math.vec3_(0F, 0F, 0F);
					particleImpl._Position = _math.addv3_(value_, emitter.position());
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					float _plot_out;
					float _plot_in0=(rnd_a<0F?0F:(rnd_a>1F?1F:rnd_a));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*15F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float _path_in = _math.clamp_(_plot_out, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
					particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
					particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
					particleImpl._Angle = 0F;
					particleImpl._Color = emitterData._Color1;
					float rnd_b = 0F + emitter.random()() * (1F - 0F);
					particleImpl._Colora = rnd_b;
					particle.position_ = particleImpl._Position;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					_math.vec3 value_ = _math.vec3_(0F, -100F, 0F);
					_math.vec3 fmove_fs = value_;
					_math.vec3 fmove_vs = _math.vec3_(0F,0F,0F);
					float fmove_dtl = dt;
					_math.vec3 fmove_v = particleImpl._Velocity;
					_math.vec3 fmove_p = particleImpl._Position;
					while (fmove_dtl > 0.0001F) {
						float fmove_dtp = fmove_dtl;
						_math.vec3 fmove_fsd = fmove_fs;
						_math.vec3 fmove_rw = _math.subv3_(fmove_vs, fmove_v);
						float fmove_rwl = _math.lengthv3sq_(fmove_rw);
						if (fmove_rwl > 0.0001F) {
							fmove_rwl = (float)Math.Sqrt(fmove_rwl);
							_math.vec3 fmove_rwn = _math.divv3scalar_(fmove_rw, fmove_rwl);
							float fmove_df = 0.01F * 0.3F * fmove_rwl;
							if (fmove_df * fmove_dtp > 0.2F)
								fmove_dtp = 0.2F / fmove_df;
							_math.addv3(out fmove_fsd, fmove_fsd, _math.mulv3scalar_(fmove_rwn, fmove_rwl * fmove_df));
						}
						_math.addv3(out fmove_v, fmove_v, _math.mulv3scalar_(fmove_fsd, fmove_dtp));
						_math.addv3(out fmove_p, fmove_p, _math.mulv3scalar_(fmove_v, fmove_dtp));
						fmove_dtl -= fmove_dtp;
					}
					particleImpl._Position = fmove_p;
					particleImpl._Velocity = fmove_v;
					particle.position_ = particleImpl._Position;
					if (particleImpl._lifetime > particleImpl._Max_Life) 
					{
						particle.dead_ = true;
					}
					float value_a = 30F;
					_math.vec3 expr_ = _math.addv3_(particleImpl._Color, _math.mulv3scalar_(_math.subv3_(emitterData._Color2, particleImpl._Color), particleImpl._Colora));
					float expr_a = (particleImpl._lifetime / particleImpl._Max_Life);
					float _plota_out;
					float _plota_in0=(expr_a<0F?0F:(expr_a>1F?1F:expr_a));
					_math.PathRes _plota_srch0 = _plota_in0<0.79269?_math.pathRes(0,(_plota_in0-0F)*1.26153F):_math.pathRes(1,(_plota_in0-0.79269F)*4.82369F);
					_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
					particleImpl.size1_ = value_a;
					particleImpl.color_ = expr_;
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
					maxNumParticles_ = 200;
					sorting_ = Emitter.Sorting.OldToYoung;
					particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
					emitterDataCreator_ = () => { return new EmitterData(); };
				}
			}

			public Model()
			{
				textures_ = new string[] { "glowing_dot.png" };
				materials_ = new RenderMaterial[] { RenderMaterial.Add };
				renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
				frameTime_ = 0.0333333F;
				presimulateTime_ = 0F;
				maxNumRenderCalls_ = 200;
				maxNumParticles_ = 200;
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
