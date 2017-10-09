// ecf2ab82-fa15-4ebf-942d-92515ebbe48e

#pragma warning disable 219

using System;

namespace Neutrino
{
	public class Effect_Magic02 : EffectModel
	{
		public class Emitter_Sparks : EmitterModel
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public _math.vec3 _Position;
				public _math.vec3 _Velocity;
				public float _Angle;
				public float _Size;
				public float _Color;
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
				public _math.vec3 _Color1 = _math.vec3_(1F,1F,1F);
				public _math.vec3 _Color2 = _math.vec3_(1F,1F,1F);
			}

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return 1F; }
				public float startPhase() { return 1F; }
				public float rate() { return 5F; }
			}

			float [][][] _plot = 
			{
				new float[][] { new float[]{ 1F,0F,0F }}
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
				float rnd_ = 100F + emitter.random()() * (300F - 100F);
				_math.vec3 randvec_ = _math.randv3gen_(rnd_, emitter.random());
				particleImpl._Velocity = randvec_;
				particleImpl._Angle = 0F;
				float rnd_a = 10F + emitter.random()() * (20F - 10F);
				particleImpl._Size = rnd_a;
				float rnd_b = 0F + emitter.random()() * (1F - 0F);
				particleImpl._Color = rnd_b;
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
				float rnd_ = 100F + emitter.random()() * (300F - 100F);
				_math.vec3 randvec_ = _math.randv3gen_(rnd_, emitter.random());
				particleImpl._Velocity = randvec_;
				particleImpl._Angle = 0F;
				float rnd_a = 10F + emitter.random()() * (20F - 10F);
				particleImpl._Size = rnd_a;
				float rnd_b = 0F + emitter.random()() * (1F - 0F);
				particleImpl._Color = rnd_b;
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
				_math.vec3 noise_i = _math.mulv3scalar_(noise_a, 1.0F / 500F); 
				_math.vec3 noise = _math.noisePixelLinear3_(noise_i);
				_math.mulv3(out noise, noise, _math.vec3_(0.0078125F,0.0078125F,0.0078125F));
				_math.addv3(out noise, noise, _math.vec3_(-1F,-1F,-1F));
				_math.mulv3scalar(out noise, noise, 600F);
				_math.vec3 fmove_fs = noise;
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
				particle.position_ = particleImpl._Position;
				float value_ = 2F;
				if (particleImpl._lifetime > value_) 
				{
					particle.dead_ = true;
				}
				float expr_ = (particleImpl._lifetime / value_);
				float _plot_out;
				float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*1F);
				_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float expr_a = (particleImpl._Size * _plot_out);
				_math.vec3 expr_b = _math.addv3_(emitterData._Color1, _math.mulv3scalar_(_math.subv3_(emitterData._Color2, emitterData._Color1), particleImpl._Color));
				particleImpl.size1_ = expr_a;
				particleImpl.color_ = expr_b;
			}
			public Emitter_Sparks()
			{
				addProperty("Color1", PropertyType.VEC3, 
					(object emitterData) => { return ((EmitterData)emitterData)._Color1; }, 
					(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color1, (_math.vec3)value); });
				addProperty("Color2", PropertyType.VEC3, 
					(object emitterData) => { return ((EmitterData)emitterData)._Color2; }, 
					(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color2, (_math.vec3)value); });
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "Sparks";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_Splash : EmitterModel
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public _math.vec3 _Position;
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
				public AttachedEmitter[] attachedEmitters_;
				public override AttachedEmitter[] attachedEmitters() { return attachedEmitters_; }

			}


			public class EmitterData
			{
				public _math.vec3 _Color = _math.vec3_(1F,1F,0F);
				public _math.vec3 _SparksColor1 = _math.vec3_(1F,0F,0F);
				public _math.vec3 _SparksColor2 = _math.vec3_(1F,1F,0F);
			}

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 0.5F; }
			}

			float [][][] _plot = 
			{
				new float[][] { new float[]{ 0F,1F,1F }, new float[]{ 1F,0.986912F,0.950467F,0.89382F,0.820641F,0.734959F,0.640978F,0.542886F,0.444666F,0.349964F,0.261977F,0.183403F,0.116434F,0.0627696F,0.0236687F,0F,0F }}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 1; }
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
				particleImpl._Angle = 0F;
				particle.position_ = particleImpl._Position;
				particleImpl.attachedEmitters_[0].emitter_.reset(particle.position_, null);
				particleImpl.attachedEmitters_[0].emitter_.start();
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color1 = emitterData._SparksColor1;
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color2 = emitterData._SparksColor2;
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
				particleImpl._Angle = 0F;
				particle.position_ = particleImpl._Position;
				particleImpl.attachedEmitters_[0].emitter_.reset(particle.position_, null);
				particleImpl.attachedEmitters_[0].emitter_.start();
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color1 = emitterData._SparksColor1;
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color2 = emitterData._SparksColor2;
			}

			public override void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime += dt;
				particle.position_ = particleImpl._Position;
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color1 = emitterData._SparksColor1;
				((Emitter_Sparks.EmitterData)particleImpl.attachedEmitters_[0].emitter_.data())._Color2 = emitterData._SparksColor2;
				particleImpl.attachedEmitters_[0].emitter_.update(dt, particle.position_, null);
				float value_ = 0.3F;
				if (particleImpl._lifetime > value_) 
				{
					particle.dead_ = true;
					particleImpl.attachedEmitters_[0].emitter_.stop();
				}
				float value_a = 100F;
				float expr_ = (particleImpl._lifetime / value_);
				float _plot_out;
				float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plot_srch0 = _plot_in0<0.0292826?_math.pathRes(0,(_plot_in0-0F)*34.15F):_math.pathRes(1,(_plot_in0-0.0292826F)*15.4525F);
				_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float expr_a = (value_a * _plot_out);
				particleImpl.size1_ = expr_a;
				particleImpl.color_ = emitterData._Color;
			}
			public Emitter_Splash()
			{
				addProperty("Color", PropertyType.VEC3, 
					(object emitterData) => { return ((EmitterData)emitterData)._Color; }, 
					(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color, (_math.vec3)value); });
				addProperty("SparksColor1", PropertyType.VEC3, 
					(object emitterData) => { return ((EmitterData)emitterData)._SparksColor1; }, 
					(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._SparksColor1, (_math.vec3)value); });
				addProperty("SparksColor2", PropertyType.VEC3, 
					(object emitterData) => { return ((EmitterData)emitterData)._SparksColor2; }, 
					(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._SparksColor2, (_math.vec3)value); });
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "Splash";
				maxNumParticles_ = 2;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { 
					ParticleImpl particle = new ParticleImpl();
					particle.attachedEmitters_ = new AttachedEmitter[]
					{
						new AttachedEmitter(new Emitter(effect, effect.model().emitterModels()[0]), AttachedEmitter.DrawOrder.After, AttachedEmitter.ActivationMode.OnCreate)
					};
					return particle;
				};
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public Effect_Magic02()
		{
			textures_ = new string[] { "glowing_dot.png","flare.png" };
			materials_ = new RenderMaterial[] { RenderMaterial.Normal };
			renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}),new RenderStyle(0,new uint[] {1}) };
			frameTime_ = 0.0333333F;
			presimulateTime_ = 0F;
			maxNumRenderCalls_ = 202;
			maxNumParticles_ = 202;
			emitterModels_ = new EmitterModel[]{ new Emitter_Sparks(), new Emitter_Splash() };
			activeEmitterModels_ = new uint[] { 1 };
			randomGeneratorCreator_ = () => { return _math.rand_; };
		}
	}
}

#pragma warning restore 219
