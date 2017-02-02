// c4cbd69a-590a-4496-9d79-5aa391fc6fbd

#pragma warning disable 219

using System;
namespace Neutrino
{
	[UnityEngine.RequireComponent(typeof(Neutrino.Unity3D.NeutrinoRenderer))]
	public class Effect_Fire : UnityEngine.MonoBehaviour, Neutrino.System.Impl
	{
		public class Emitter_Fire : Emitter.Impl
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public NMath.vec3 _Position;
				public NMath.vec3 _Velocity;
				public float _Angle;
				public float _Tex__index;
				public override NMath.vec2 origin() { return NMath.vec2_(0.5F,0.5F); }
				public override float angle() { return _Angle; }
				public override NMath.quat rotation() { return NMath.quat_(1, 0, 0, 0); }
				public float size1_;
				public override float size1() { return size1_; }
				public override NMath.vec2 size2() { return NMath.vec2_(0, 0); }
				public override NMath.vec3 color() { return NMath.vec3_(1F,1F,1F); }
				public float alpha_;
				public override float alpha() { return alpha_; }
				public override float gridIndex() { return _Tex__index; }
				public override AttachedEmitter[] attachedEmitters() { return null; }

			}

			public Particle createParticle(Neutrino.System system)
			{
				return new ParticleImpl();
			}

			public class EmitterData
			{
			}

			public object createEmitterData() { return new EmitterData(); }

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float salvo() { return 1F; }
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
				public NMath.vec2 gridSize() { return NMath.vec2_(5, 1); }
				public ushort renderStyleIndex() { return 0; }
			}

			public Constructor createConstructor(Emitter emitter)
			{
				return new ConstructorQuads(emitter, new ConstructorImpl());
			}

			public uint maxNumParticles() { return 100; }

			public Emitter.Sorting sorting() { return Emitter.Sorting.OldToYoung; }

			public void updateEmitter(Emitter emitter)
			{
				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
			}

			public void initParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime = 0F;
				NMath.vec3 value_ = NMath.vec3_(0F, 0F, 0F);
				particleImpl._Position = NMath.addv3_(value_, emitter.position());
				NMath.vec3 randvec_ = NMath.randv3_(100F);
				NMath.vec3 expr_ = NMath.addv3_(emitter.velocity(), randvec_);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_ = 0F + NMath.rand_() * (5F - 0F);
				particleImpl._Tex__index = rnd_;
				particle.position_ = particleImpl._Position;
			}

			public void initSalvoParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime = 0F;
				NMath.vec3 value_ = NMath.vec3_(0F, 0F, 0F);
				particleImpl._Position = NMath.addv3_(value_, emitter.position());
				NMath.vec3 randvec_ = NMath.randv3_(100F);
				NMath.vec3 expr_ = NMath.addv3_(emitter.velocity(), randvec_);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_ = 0F + NMath.rand_() * (5F - 0F);
				particleImpl._Tex__index = rnd_;
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime += dt;
				NMath.vec3 value_ = NMath.vec3_(0F, 400F, 0F);
				NMath.vec3 noise_a = NMath.mulv3scalar_(NMath.vec3_(100F,50F,30F), emitter.system().time());
				NMath.addv3(out noise_a, noise_a, particleImpl._Position);
				NMath.vec3 noise_i = NMath.mulv3scalar_(noise_a, 1.0F / 1000F); 
				NMath.vec3 noise = NMath.noisePixelLinear3_(noise_i);
				NMath.mulv3(out noise, noise, NMath.vec3_(0.0078125F,0.0078125F,0.0078125F));
				NMath.addv3(out noise, noise, NMath.vec3_(-1F,-1F,-1F));
				NMath.mulv3scalar(out noise, noise, 200F);
				NMath.vec3 fmove_fs = value_;
				NMath.addv3(out fmove_fs, fmove_fs, noise);
				NMath.vec3 fmove_iv = particleImpl._Velocity;
				NMath.vec3 fmove_vs = NMath.vec3_(0F,0F,0F);
				NMath.vec3 fmove_rw = NMath.subv3_(fmove_vs, fmove_iv);
				float fmove_rwl = NMath.lengthv3sq_(fmove_rw);
				if (fmove_rwl > 0.0001F) {
					fmove_rwl = (float)Math.Sqrt(fmove_rwl);
					NMath.vec3 fmove_rwn = NMath.divv3scalar_(fmove_rw, fmove_rwl);
					float fmove_df = 0.01F * 1F * fmove_rwl;
					if (fmove_df * dt < 1F) {
						NMath.mulv3scalar(out fmove_rwn, fmove_rwn, fmove_rwl * fmove_df);
						NMath.addv3(out fmove_fs, fmove_fs, fmove_rwn);
					} else {
						NMath.addv3(out fmove_iv, fmove_iv, fmove_rw);
					}
				}
				NMath.mulv3scalar(out fmove_fs, fmove_fs, dt);
				NMath.addv3(out fmove_fs, fmove_fs, fmove_iv);
				NMath.vec3 fmove_p = NMath.mulv3scalar_(fmove_fs, dt);
				NMath.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				particleImpl._Velocity = fmove_fs;
				float value_a = 1.5F;
				float expr_ = (particleImpl._lifetime / value_a);
				float _plot_out;
				float _plot_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				NMath.PathRes _plot_srch0 = NMath.pathRes(0,(_plot_in0-0F)*15F);
				NMath.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float move_ = particleImpl._Angle + _plot_out * dt;
				particleImpl._Angle = move_;
				particle.position_ = particleImpl._Position;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 40F;
				float _plota_out;
				float _plota_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				NMath.PathRes _plota_srch0 = _plota_in0<0.2?NMath.pathRes(0,(_plota_in0-0F)*75F):NMath.pathRes(1,(_plota_in0-0.2F)*18.75F);
				NMath.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
				float expr_a = (value_b * _plota_out);
				float _plotb_out;
				float _plotb_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				NMath.PathRes _plotb_srch0 = _plotb_in0<0.1?NMath.pathRes(0,(_plotb_in0-0F)*10F):NMath.pathRes(1,(_plotb_in0-0.1F)*16.6667F);
				NMath.funcLerp(out _plotb_out, this._plotb[0][_plotb_srch0.s],_plotb_srch0.i);
				particleImpl.size1_ = expr_a;
				particleImpl.alpha_ = _plotb_out;
			}
		}

		public class Emitter_Sparks : Emitter.Impl
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public NMath.vec3 _Position;
				public NMath.vec3 _Velocity;
				public float _Angle;
				public float _Max_Life;
				public override NMath.vec2 origin() { return NMath.vec2_(0.5F,0.5F); }
				public override float angle() { return _Angle; }
				public override NMath.quat rotation() { return NMath.quat_(1, 0, 0, 0); }
				public override float size1() { return 0; }
				public NMath.vec2 size2_;
				public override NMath.vec2 size2() { return size2_; }
				public override NMath.vec3 color() { return NMath.vec3_(1F,1F,1F); }
				public float alpha_;
				public override float alpha() { return alpha_; }
				public override float gridIndex() { return 0; }
				public override AttachedEmitter[] attachedEmitters() { return null; }

			}

			public Particle createParticle(Neutrino.System system)
			{
				return new ParticleImpl();
			}

			public class EmitterData
			{
			}

			public object createEmitterData() { return new EmitterData(); }

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float salvo() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 15F; }
			}

			public Generator createGenerator(Emitter emitter)
			{
				return new GeneratorPeriodic(emitter, new GeneratorImpl());
			}

			NMath.vec2 [][,] _path = 
			{
				new NMath.vec2[,] {{NMath.vec2_(-82.4F,66F)},{NMath.vec2_(58.4F,73.2F)},{NMath.vec2_(58.4F,73.2F)}}
			};

			NMath.vec2 [][,] _patha = 
			{
				new NMath.vec2[,] {{NMath.vec2_(63.6F,230.8F)},{NMath.vec2_(-52.4F,229.2F)},{NMath.vec2_(-52.4F,229.2F)}}
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
				public NMath.vec2 gridSize() { return NMath.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 1; }
			}

			public Constructor createConstructor(Emitter emitter)
			{
				return new ConstructorQuads(emitter, new ConstructorImpl());
			}

			public uint maxNumParticles() { return 100; }

			public Emitter.Sorting sorting() { return Emitter.Sorting.OldToYoung; }

			public void updateEmitter(Emitter emitter)
			{
				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
			}

			public void initParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime = 0F;
				float rnd_ = 0F + NMath.rand_() * (1F - 0F);
				float _path_in = NMath.clamp_(rnd_, 0, 1);
				NMath.PathRes _path_srch = NMath.pathRes(0,(_path_in-0F)*1F);
				NMath.vec2 _path_pos;
				NMath.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				NMath.vec3 conv3d_ = NMath.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = NMath.addv3_(conv3d_, emitter.position());
				float rnd_a = 0F + NMath.rand_() * (1F - 0F);
				float _patha_in = NMath.clamp_(rnd_a, 0, 1);
				NMath.PathRes _patha_srch = NMath.pathRes(0,(_patha_in-0F)*1F);
				NMath.vec2 _patha_pos;
				NMath.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
				NMath.vec3 conv3d_a = NMath.vec3_(_patha_pos.x, _patha_pos.y, 0F);
				NMath.vec3 expr_ = NMath.addv3_(emitter.velocity(), conv3d_a);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_b = 0F + NMath.rand_() * (2F - 0F);
				particleImpl._Max_Life = rnd_b;
				particle.position_ = particleImpl._Position;
			}

			public void initSalvoParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime = 0F;
				float rnd_ = 0F + NMath.rand_() * (1F - 0F);
				float _path_in = NMath.clamp_(rnd_, 0, 1);
				NMath.PathRes _path_srch = NMath.pathRes(0,(_path_in-0F)*1F);
				NMath.vec2 _path_pos;
				NMath.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				NMath.vec3 conv3d_ = NMath.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = NMath.addv3_(conv3d_, emitter.position());
				float rnd_a = 0F + NMath.rand_() * (1F - 0F);
				float _patha_in = NMath.clamp_(rnd_a, 0, 1);
				NMath.PathRes _patha_srch = NMath.pathRes(0,(_patha_in-0F)*1F);
				NMath.vec2 _patha_pos;
				NMath.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
				NMath.vec3 conv3d_a = NMath.vec3_(_patha_pos.x, _patha_pos.y, 0F);
				NMath.vec3 expr_ = NMath.addv3_(emitter.velocity(), conv3d_a);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_b = 0F + NMath.rand_() * (2F - 0F);
				particleImpl._Max_Life = rnd_b;
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generatorImpl = (GeneratorPeriodic)emitter.generator();
				particleImpl._lifetime += dt;
				NMath.vec3 value_ = NMath.vec3_(0F, 800F, 0F);
				NMath.vec3 noise_a = NMath.mulv3scalar_(NMath.vec3_(100F,50F,30F), emitter.system().time());
				NMath.addv3(out noise_a, noise_a, particleImpl._Position);
				NMath.vec3 noise_i = NMath.mulv3scalar_(noise_a, 1.0F / 1000F); 
				NMath.vec3 noise = NMath.noisePixelLinear3_(noise_i);
				NMath.mulv3(out noise, noise, NMath.vec3_(0.0078125F,0.0078125F,0.0078125F));
				NMath.addv3(out noise, noise, NMath.vec3_(-1F,-1F,-1F));
				NMath.mulv3scalar(out noise, noise, 1200F);
				NMath.vec3 fmove_fs = value_;
				NMath.addv3(out fmove_fs, fmove_fs, noise);
				NMath.vec3 fmove_iv = particleImpl._Velocity;
				NMath.vec3 fmove_vs = NMath.vec3_(0F,0F,0F);
				NMath.vec3 fmove_rw = NMath.subv3_(fmove_vs, fmove_iv);
				float fmove_rwl = NMath.lengthv3sq_(fmove_rw);
				if (fmove_rwl > 0.0001F) {
					fmove_rwl = (float)Math.Sqrt(fmove_rwl);
					NMath.vec3 fmove_rwn = NMath.divv3scalar_(fmove_rw, fmove_rwl);
					float fmove_df = 0.01F * 1F * fmove_rwl;
					if (fmove_df * dt < 1F) {
						NMath.mulv3scalar(out fmove_rwn, fmove_rwn, fmove_rwl * fmove_df);
						NMath.addv3(out fmove_fs, fmove_fs, fmove_rwn);
					} else {
						NMath.addv3(out fmove_iv, fmove_iv, fmove_rw);
					}
				}
				NMath.mulv3scalar(out fmove_fs, fmove_fs, dt);
				NMath.addv3(out fmove_fs, fmove_fs, fmove_iv);
				NMath.vec3 fmove_p = NMath.mulv3scalar_(fmove_fs, dt);
				NMath.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				particleImpl._Velocity = fmove_fs;
				particle.position_ = particleImpl._Position;
				if (particleImpl._lifetime > particleImpl._Max_Life) 
				{
					particle.dead_ = true;
				}
				NMath.vec2 value_a = NMath.vec2_(6F, 6F);
				float _plot_out;
				float _plot_in0=(particleImpl._lifetime<0F?0F:(particleImpl._lifetime>1.35236F?(0F+((particleImpl._lifetime-0F)%1.35236F)):particleImpl._lifetime));
				NMath.PathRes _plot_srch0 = _plot_in0<0.739748?_plot_in0<0.4?_plot_in0<0.1?NMath.pathRes(0,(_plot_in0-0F)*10F):NMath.pathRes(1,(_plot_in0-0.1F)*3.33333F):_plot_in0<0.558348?NMath.pathRes(2,(_plot_in0-0.4F)*6.3152F):NMath.pathRes(3,(_plot_in0-0.558348F)*5.51269F):_plot_in0<1.03367?_plot_in0<0.833292?NMath.pathRes(4,(_plot_in0-0.739748F)*10.6901F):NMath.pathRes(5,(_plot_in0-0.833292F)*4.99066F):_plot_in0<1.2?NMath.pathRes(6,(_plot_in0-1.03367F)*6.01203F):NMath.pathRes(7,(_plot_in0-1.2F)*6.56334F);
				NMath.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
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

		Emitter.Impl[] emitterImpls_ = new Emitter.Impl[]{ new Emitter_Fire(), new Emitter_Sparks() };
		public Emitter.Impl[] emitterImpls() { return emitterImpls_; }

		uint[] activeEmitterImpls_ = new uint[] { 0, 1 };
		public uint[] activeEmitterImpls() { return activeEmitterImpls_; }

	}
}

#pragma warning restore 219
