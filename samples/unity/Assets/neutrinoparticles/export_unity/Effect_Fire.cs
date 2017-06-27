// 9fe69019-94fd-404c-819e-2ed42f40fdb5

#pragma warning disable 219

using System;
namespace Neutrino
{
	[UnityEngine.RequireComponent(typeof(Neutrino.Unity3D.NeutrinoRenderer))]
	public class Effect_Fire : UnityEngine.MonoBehaviour, EffectModel
	{
		public class Emitter_Fire : EmitterModel
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public _math.vec3 _Position;
				public float _Angle;
				public float _Tex__index;
				public _math.vec3 _Velocity;
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

			public Particle createParticle(Effect effect)
			{
				return new ParticleImpl();
			}

			public class EmitterData
			{
			}

			public object createEmitterData() { return new EmitterData(); }

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 50F; }
			}

			public Generator createGenerator(Emitter emitter)
			{
				return new GeneratorPeriodic(emitter, new GeneratorImpl());
			}

			float [][][] _plot = 
			{
				new float[][] { new float[]{ 100F,98.7056F,95.0816F,89.5077F,82.3522F,73.9754F,64.731F,54.9678F,45.032F,35.2689F,26.0243F,17.6477F,10.4923F,4.91833F,1.29439F,0F,0F }}
			};

			float [][][] _plota = 
			{
				new float[][] { new float[]{ 1F,1.33476F,1.52189F,1.6464F,1.73598F,1.80316F,1.8547F,1.89467F,1.92574F,1.94973F,1.96795F,1.98139F,1.99078F,1.99672F,1.99967F,2F,2F }, new float[]{ 2F,1.98711F,1.95736F,1.91344F,1.85776F,1.79245F,1.71948F,1.64068F,1.55776F,1.47239F,1.38617F,1.30072F,1.21766F,1.13866F,1.06549F,1F,1F }}
			};

			float [][][] _plotb = 
			{
				new float[][] { new float[]{ 0F,1F,1F }, new float[]{ 1F,0.857426F,0.748759F,0.657986F,0.57883F,0.508059F,0.443753F,0.384662F,0.329923F,0.278916F,0.23118F,0.186365F,0.144202F,0.104484F,0.0670548F,0.0317972F,0.0317972F }}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.Grid; }
				public _math.vec2 gridSize() { return _math.vec2_(5, 1); }
				public ushort renderStyleIndex() { return 0; }
			}

			public Constructor createConstructor(Emitter emitter)
			{
				return new ConstructorQuads(emitter, new ConstructorImpl());
			}

			public void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.quat value)
			{
			}

			string name_ = "Fire";
			public string name() { return name_; }

			public uint maxNumParticles() { return 100; }

			public Emitter.Sorting sorting() { return Emitter.Sorting.OldToYoung; }

			public void updateEmitter(Emitter emitter)
			{
				EmitterData emitterData = (EmitterData)emitter.data();
				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
			}

			public void initParticle(Emitter emitter, Particle particle)
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
				particleImpl._Angle = 0F;
				float rnd_ = 0F + _math.rand_() * (5F - 0F);
				particleImpl._Tex__index = rnd_;
				_math.vec3 randvec_ = _math.randv3_(100F);
				particleImpl._Velocity = _math.applyv3quat_(randvec_, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				particle.position_ = particleImpl._Position;
			}

			public void initBurstParticle(Emitter emitter, Particle particle)
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
				particleImpl._Angle = 0F;
				float rnd_ = 0F + _math.rand_() * (5F - 0F);
				particleImpl._Tex__index = rnd_;
				_math.vec3 randvec_ = _math.randv3_(100F);
				particleImpl._Velocity = _math.applyv3quat_(randvec_, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime += dt;
				_math.vec3 value_ = _math.vec3_(0F, 400F, 0F);
				_math.vec3 noise_a = _math.mulv3scalar_(_math.vec3_(100F,50F,30F), emitter.effect().time());
				_math.addv3(out noise_a, noise_a, particleImpl._Position);
				_math.vec3 noise_i = _math.mulv3scalar_(noise_a, 1.0F / 1000F); 
				_math.vec3 noise = _math.noisePixelLinear3_(noise_i);
				_math.mulv3(out noise, noise, _math.vec3_(0.0078125F,0.0078125F,0.0078125F));
				_math.addv3(out noise, noise, _math.vec3_(-1F,-1F,-1F));
				_math.mulv3scalar(out noise, noise, 200F);
				_math.vec3 fmove_fs = value_;
				_math.addv3(out fmove_fs, fmove_fs, noise);
				_math.vec3 fmove_iv = particleImpl._Velocity;
				_math.vec3 fmove_vs = _math.vec3_(0F,0F,0F);
				_math.vec3 fmove_rw = _math.subv3_(fmove_vs, fmove_iv);
				float fmove_rwl = _math.lengthv3sq_(fmove_rw);
				if (fmove_rwl > 0.0001F) {
					fmove_rwl = (float)Math.Sqrt(fmove_rwl);
					_math.vec3 fmove_rwn = _math.divv3scalar_(fmove_rw, fmove_rwl);
					float fmove_df = 0.01F * 1F * fmove_rwl;
					if (fmove_df * dt < 1F) {
						_math.mulv3scalar(out fmove_rwn, fmove_rwn, fmove_rwl * fmove_df);
						_math.addv3(out fmove_fs, fmove_fs, fmove_rwn);
					} else {
						_math.addv3(out fmove_iv, fmove_iv, fmove_rw);
					}
				}
				_math.mulv3scalar(out fmove_fs, fmove_fs, dt);
				_math.addv3(out fmove_fs, fmove_fs, fmove_iv);
				_math.vec3 fmove_p = _math.mulv3scalar_(fmove_fs, dt);
				_math.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				float value_a = 1.5F;
				float expr_ = (particleImpl._lifetime / value_a);
				float _plot_out;
				float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*15F);
				_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float move_ = particleImpl._Angle + _plot_out * dt;
				particleImpl._Angle = move_;
				particleImpl._Velocity = fmove_fs;
				particle.position_ = particleImpl._Position;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 40F;
				float _plota_out;
				float _plota_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plota_srch0 = _plota_in0<0.2?_math.pathRes(0,(_plota_in0-0F)*75F):_math.pathRes(1,(_plota_in0-0.2F)*18.75F);
				_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
				float expr_a = (value_b * _plota_out);
				float _plotb_out;
				float _plotb_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plotb_srch0 = _plotb_in0<0.1?_math.pathRes(0,(_plotb_in0-0F)*10F):_math.pathRes(1,(_plotb_in0-0.1F)*16.6667F);
				_math.funcLerp(out _plotb_out, this._plotb[0][_plotb_srch0.s],_plotb_srch0.i);
				particleImpl.size1_ = expr_a;
				particleImpl.alpha_ = _plotb_out;
			}
		}

		public class Emitter_Sparks : EmitterModel
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public _math.vec3 _Position;
				public float _Angle;
				public float _Max_Life;
				public _math.vec3 _Velocity;
				public override _math.vec2 origin() { return _math.vec2_(0.5F,0.5F); }
				public override float angle() { return _Angle; }
				public override _math.quat rotation() { return _math.quat_(1, 0, 0, 0); }
				public override float size1() { return 0; }
				public _math.vec2 size2_;
				public override _math.vec2 size2() { return size2_; }
				public override _math.vec3 color() { return _math.vec3_(1F,1F,1F); }
				public float alpha_;
				public override float alpha() { return alpha_; }
				public override float gridIndex() { return 0; }
				public override AttachedEmitter[] attachedEmitters() { return null; }

			}

			public Particle createParticle(Effect effect)
			{
				return new ParticleImpl();
			}

			public class EmitterData
			{
			}

			public object createEmitterData() { return new EmitterData(); }

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 15F; }
			}

			public Generator createGenerator(Emitter emitter)
			{
				return new GeneratorPeriodic(emitter, new GeneratorImpl());
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(-82.4F,66F)},{_math.vec2_(58.4F,73.2F)},{_math.vec2_(58.4F,73.2F)}}
			};

			_math.vec2 [][,] _patha = 
			{
				new _math.vec2[,] {{_math.vec2_(63.6F,230.8F)},{_math.vec2_(-52.4F,229.2F)},{_math.vec2_(-52.4F,229.2F)}}
			};

			float [][][] _plot = 
			{
				new float[][] { new float[]{ 0F,1F,1F }, new float[]{ 1F,0.3F,0.3F }, new float[]{ 0.3F,0.747257F,0.747257F }, new float[]{ 0.747257F,0.342896F,0.342896F }, new float[]{ 0.342896F,0.72018F,0.72018F }, new float[]{ 0.72018F,0F,0F }, new float[]{ 0F,1F,1F }, new float[]{ 1F,0F,0F }}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Rect; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 1; }
			}

			public Constructor createConstructor(Emitter emitter)
			{
				return new ConstructorQuads(emitter, new ConstructorImpl());
			}

			public void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public void setPropertyValue(object emitterData, string name, _math.quat value)
			{
			}

			string name_ = "Sparks";
			public string name() { return name_; }

			public uint maxNumParticles() { return 100; }

			public Emitter.Sorting sorting() { return Emitter.Sorting.OldToYoung; }

			public void updateEmitter(Emitter emitter)
			{
				EmitterData emitterData = (EmitterData)emitter.data();
				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
			}

			public void initParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime = 0F;
				float rnd_ = 0F + _math.rand_() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.applyv3quat_(conv3d_, emitter.rotation());
				particleImpl._Position = _math.addv3_(particleImpl._Position, emitter.position());
				particleImpl._Angle = 0F;
				float rnd_a = 0F + _math.rand_() * (2F - 0F);
				particleImpl._Max_Life = rnd_a;
				float rnd_b = 0F + _math.rand_() * (1F - 0F);
				float _patha_in = _math.clamp_(rnd_b, 0, 1);
				_math.PathRes _patha_srch = _math.pathRes(0,(_patha_in-0F)*1F);
				_math.vec2 _patha_pos;
				_math.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
				_math.vec3 conv3d_a = _math.vec3_(_patha_pos.x, _patha_pos.y, 0F);
				particleImpl._Velocity = _math.applyv3quat_(conv3d_a, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				particle.position_ = particleImpl._Position;
			}

			public void initBurstParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime = 0F;
				float rnd_ = 0F + _math.rand_() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.applyv3quat_(conv3d_, emitter.rotation());
				particleImpl._Position = _math.addv3_(particleImpl._Position, emitter.position());
				particleImpl._Angle = 0F;
				float rnd_a = 0F + _math.rand_() * (2F - 0F);
				particleImpl._Max_Life = rnd_a;
				float rnd_b = 0F + _math.rand_() * (1F - 0F);
				float _patha_in = _math.clamp_(rnd_b, 0, 1);
				_math.PathRes _patha_srch = _math.pathRes(0,(_patha_in-0F)*1F);
				_math.vec2 _patha_pos;
				_math.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
				_math.vec3 conv3d_a = _math.vec3_(_patha_pos.x, _patha_pos.y, 0F);
				particleImpl._Velocity = _math.applyv3quat_(conv3d_a, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime += dt;
				_math.vec3 value_ = _math.vec3_(0F, 800F, 0F);
				_math.vec3 noise_a = _math.mulv3scalar_(_math.vec3_(100F,50F,30F), emitter.effect().time());
				_math.addv3(out noise_a, noise_a, particleImpl._Position);
				_math.vec3 noise_i = _math.mulv3scalar_(noise_a, 1.0F / 1000F); 
				_math.vec3 noise = _math.noisePixelLinear3_(noise_i);
				_math.mulv3(out noise, noise, _math.vec3_(0.0078125F,0.0078125F,0.0078125F));
				_math.addv3(out noise, noise, _math.vec3_(-1F,-1F,-1F));
				_math.mulv3scalar(out noise, noise, 1200F);
				_math.vec3 fmove_fs = value_;
				_math.addv3(out fmove_fs, fmove_fs, noise);
				_math.vec3 fmove_iv = particleImpl._Velocity;
				_math.vec3 fmove_vs = _math.vec3_(0F,0F,0F);
				_math.vec3 fmove_rw = _math.subv3_(fmove_vs, fmove_iv);
				float fmove_rwl = _math.lengthv3sq_(fmove_rw);
				if (fmove_rwl > 0.0001F) {
					fmove_rwl = (float)Math.Sqrt(fmove_rwl);
					_math.vec3 fmove_rwn = _math.divv3scalar_(fmove_rw, fmove_rwl);
					float fmove_df = 0.01F * 1F * fmove_rwl;
					if (fmove_df * dt < 1F) {
						_math.mulv3scalar(out fmove_rwn, fmove_rwn, fmove_rwl * fmove_df);
						_math.addv3(out fmove_fs, fmove_fs, fmove_rwn);
					} else {
						_math.addv3(out fmove_iv, fmove_iv, fmove_rw);
					}
				}
				_math.mulv3scalar(out fmove_fs, fmove_fs, dt);
				_math.addv3(out fmove_fs, fmove_fs, fmove_iv);
				_math.vec3 fmove_p = _math.mulv3scalar_(fmove_fs, dt);
				_math.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				particleImpl._Velocity = fmove_fs;
				particle.position_ = particleImpl._Position;
				if (particleImpl._lifetime > particleImpl._Max_Life) 
				{
					particle.dead_ = true;
				}
				_math.vec2 value_a = _math.vec2_(6F, 6F);
				float _plot_out;
				float _plot_in0=(particleImpl._lifetime<0F?0F:(particleImpl._lifetime>1.35236F?(0F+((particleImpl._lifetime-0F)%1.35236F)):particleImpl._lifetime));
				_math.PathRes _plot_srch0 = _plot_in0<0.739748?_plot_in0<0.4?_plot_in0<0.1?_math.pathRes(0,(_plot_in0-0F)*10F):_math.pathRes(1,(_plot_in0-0.1F)*3.33333F):_plot_in0<0.558348?_math.pathRes(2,(_plot_in0-0.4F)*6.3152F):_math.pathRes(3,(_plot_in0-0.558348F)*5.51269F):_plot_in0<1.03367?_plot_in0<0.833292?_math.pathRes(4,(_plot_in0-0.739748F)*10.6901F):_math.pathRes(5,(_plot_in0-0.833292F)*4.99066F):_plot_in0<1.2?_math.pathRes(6,(_plot_in0-1.03367F)*6.01203F):_math.pathRes(7,(_plot_in0-1.2F)*6.56334F);
				_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				particleImpl.size2_ = value_a;
				particleImpl.alpha_ = _plot_out;
			}
		}

		string[] textures_ = new string[] { "fire5x1.png","fire_spark.png" };
		public string[] textures() { return textures_; }

		RenderMaterial[] materials_ = new RenderMaterial[] { RenderMaterial.Add };
		public RenderMaterial[] materials() { return materials_; }

		RenderStyle[] renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}),new RenderStyle(0,new uint[] {1}) };
		public RenderStyle[] renderStyles() { return renderStyles_; }

		public float frameTime() { return 0.0333333F; }

		public float presimulateTime() { return 0F; }

		public uint maxNumRenderCalls() { return 200; }

		public uint maxNumParticles() { return 200; }

		EmitterModel[] emitterModels_ = new EmitterModel[]{ new Emitter_Fire(), new Emitter_Sparks() };
		public EmitterModel[] emitterModels() { return emitterModels_; }

		uint[] activeEmitterModels_ = new uint[] { 0, 1 };
		public uint[] activeEmitterModels() { return activeEmitterModels_; }

	}
}

#pragma warning restore 219
