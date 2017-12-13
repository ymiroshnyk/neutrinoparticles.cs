// e2a8473c-43d2-4d2c-80a8-bc3ea46e53a0

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_Water_Stream : NeutrinoRenderer
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
					public float _Tex__index;
					public float _Rot__speed;
					public override _math.vec2 origin() { return _math.vec2_(0.5F,0.5F); }
					public override float angle() { return _Angle; }
					public override _math.quat rotation() { return _math.quat_(1, 0, 0, 0); }
					public float size1_;
					public override float size1() { return size1_; }
					public override _math.vec2 size2() { return _math.vec2_(0, 0); }
					public override _math.vec3 color() { return _math.vec3_(1F,1F,1F); }
					public float alpha_;
					public override float alpha() { return alpha_; }
					public override float gridIndex() { return _Tex__index; }
					public override AttachedEmitter[] attachedEmitters() { return null; }

				}


				public class EmitterData
				{
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 1F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return null; }
					public float startPhase() { return 1F; }
					public float rate() { return 25F; }
				}

				_math.vec2 [][,] _path = 
				{
					new _math.vec2[,] {{_math.vec2_(400F,-40F)},{_math.vec2_(401F,36F)},{_math.vec2_(401F,36F)}}
				};

				float [][][] _plot = 
				{
					new float[][] { new float[]{ 1F,2F,2F }}
				};

				float [][][] _plota = 
				{
					new float[][] { new float[]{ 1F,0F,0F }}
				};

				public class ConstructorImpl : ConstructorQuads.Impl
				{
					public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
					public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
					public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.Grid; }
					public _math.vec2 gridSize() { return _math.vec2_(2, 2); }
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
					particleImpl._Position = _math.applyv3quat_(value_, emitter.rotation());
					particleImpl._Position = _math.addv3_(particleImpl._Position, emitter.position());
					float rnd_ = 0F + emitter.random()() * (1F - 0F);
					float _path_in = _math.clamp_(rnd_, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
					particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
					particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
					float rnd_a = 0F + emitter.random()() * (360F - 0F);
					particleImpl._Angle = rnd_a;
					float rnd_b = 0F + emitter.random()() * (4F - 0F);
					particleImpl._Tex__index = rnd_b;
					float rnd_c = -180F + emitter.random()() * (180F - -180F);
					particleImpl._Rot__speed = rnd_c;
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
					particleImpl._Position = _math.applyv3quat_(value_, emitter.rotation());
					particleImpl._Position = _math.addv3_(particleImpl._Position, emitter.position());
					float rnd_ = 0F + emitter.random()() * (1F - 0F);
					float _path_in = _math.clamp_(rnd_, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
					particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
					particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
					float rnd_a = 0F + emitter.random()() * (360F - 0F);
					particleImpl._Angle = rnd_a;
					float rnd_b = 0F + emitter.random()() * (4F - 0F);
					particleImpl._Tex__index = rnd_b;
					float rnd_c = -180F + emitter.random()() * (180F - -180F);
					particleImpl._Rot__speed = rnd_c;
					particle.position_ = particleImpl._Position;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					_math.vec3 value_ = _math.vec3_(0F, -300F, 0F);
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
							float fmove_df = 0.01F * 1F * fmove_rwl;
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
					float move_ = particleImpl._Angle + particleImpl._Rot__speed * dt;
					particleImpl._Angle = move_;
					particle.position_ = particleImpl._Position;
					float value_a = 2F;
					if (particleImpl._lifetime > value_a) 
					{
						particle.dead_ = true;
					}
					float value_b = 30F;
					float _plot_out;
					float _plot_in0=(particleImpl._lifetime<0F?0F:(particleImpl._lifetime>1F?1F:particleImpl._lifetime));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*1F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float expr_ = (value_b * _plot_out);
					float expr_a = (particleImpl._lifetime / value_a);
					float _plota_out;
					float _plota_in0=(expr_a<0F?0F:(expr_a>1F?1F:expr_a));
					_math.PathRes _plota_srch0 = _math.pathRes(0,(_plota_in0-0F)*1F);
					_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
					particleImpl.size1_ = expr_;
					particleImpl.alpha_ = _plota_out;
				}
				public Emitter_DefaultEmitter()
				{
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
				textures_ = new string[] { "water2x3_white.png" };
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

		return modelInstance_;
	}
	}
}

#pragma warning restore 219
