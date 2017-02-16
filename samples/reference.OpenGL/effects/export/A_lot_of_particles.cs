// 16b38154-354c-472b-806f-e9bf7c708997

#pragma warning disable 219

using System;
namespace Neutrino
{
	public class Effect_A_lot_of_particles : EffectModel
	{
		public class Emitter_DefaultEmitter : EmitterModel
		{
			public class ParticleImpl : Particle
			{
				public float _lifetime;
				public _math.vec3 _Position;
				public _math.vec3 _Velocity;
				public float _Angle;
				public float _Size;
				public _math.vec3 _Color;
				public override _math.vec2 origin() { return _math.vec2_(0.5F,0.5F); }
				public override float angle() { return _Angle; }
				public override _math.quat rotation() { return _math.quat_(1, 0, 0, 0); }
				public override float size1() { return _Size; }
				public override _math.vec2 size2() { return _math.vec2_(0, 0); }
				public override _math.vec3 color() { return _Color; }
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
				public float salvo() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 5000F; }
			}

			public Generator createGenerator(Emitter emitter)
			{
				return new GeneratorPeriodic(emitter, new GeneratorImpl());
			}

			float [][][] _plot = 
			{
				new float[][] { new float[]{ 0.8F,1F,1F }, new float[]{ 1F,1F,1F }, new float[]{ 0.8F,1F,1F }},
				new float[][] { new float[]{ 0.8F,1F,1F }, new float[]{ 0.8F,1F,1F }},
				new float[][] { new float[]{ 1F,1F,1F }, new float[]{ 0.8F,1F,1F }, new float[]{ 0.8F,1F,1F }}
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

			string name_ = "DefaultEmitter";
			public string name() { return name_; }

			public uint maxNumParticles() { return 10000; }

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
				particleImpl._Position = _math.addv3_(value_, emitter.position());
				float rnd_ = 0F + _math.rand_() * (800F - 0F);
				_math.vec3 randvec_ = _math.randv3_(rnd_);
				_math.vec3 expr_ = _math.addv3_(emitter.velocity(), randvec_);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_a = 5F + _math.rand_() * (30F - 5F);
				particleImpl._Size = rnd_a;
				float rnd_b = 0F + _math.rand_() * (1F - 0F);
				_math.vec3 _plot_out;
				float _plot_in0=(rnd_b<0F?0F:(rnd_b>0.9F?0.9F:rnd_b));
				_math.PathRes _plot_srch0 = _plot_in0<0.6?_plot_in0<0.3?_math.pathRes(0,(_plot_in0-0F)*3.33333F):_math.pathRes(1,(_plot_in0-0.3F)*3.33333F):_math.pathRes(2,(_plot_in0-0.6F)*3.33333F);
				_math.funcLerp(out _plot_out.x, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float _plot_in1=(rnd_b<0F?0F:(rnd_b>0.6F?0.6F:rnd_b));
				_math.PathRes _plot_srch1 = _plot_in1<0.3?_math.pathRes(0,(_plot_in1-0F)*3.33333F):_math.pathRes(1,(_plot_in1-0.3F)*3.33333F);
				_math.funcLerp(out _plot_out.y, this._plot[1][_plot_srch1.s],_plot_srch1.i);
				float _plot_in2=(rnd_b<0F?0F:(rnd_b>0.9F?0.9F:rnd_b));
				_math.PathRes _plot_srch2 = _plot_in2<0.6?_plot_in2<0.3?_math.pathRes(0,(_plot_in2-0F)*3.33333F):_math.pathRes(1,(_plot_in2-0.3F)*3.33333F):_math.pathRes(2,(_plot_in2-0.6F)*3.33333F);
				_math.funcLerp(out _plot_out.z, this._plot[2][_plot_srch2.s],_plot_srch2.i);
				particleImpl._Color = _plot_out;
				particle.position_ = particleImpl._Position;
			}

			public void initSalvoParticle(Emitter emitter, Particle particle)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				float dt = 0;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime = 0F;
				_math.vec3 value_ = _math.vec3_(0F, 0F, 0F);
				particleImpl._Position = _math.addv3_(value_, emitter.position());
				float rnd_ = 0F + _math.rand_() * (800F - 0F);
				_math.vec3 randvec_ = _math.randv3_(rnd_);
				_math.vec3 expr_ = _math.addv3_(emitter.velocity(), randvec_);
				particleImpl._Velocity = expr_;
				particleImpl._Angle = 0F;
				float rnd_a = 5F + _math.rand_() * (30F - 5F);
				particleImpl._Size = rnd_a;
				float rnd_b = 0F + _math.rand_() * (1F - 0F);
				_math.vec3 _plot_out;
				float _plot_in0=(rnd_b<0F?0F:(rnd_b>0.9F?0.9F:rnd_b));
				_math.PathRes _plot_srch0 = _plot_in0<0.6?_plot_in0<0.3?_math.pathRes(0,(_plot_in0-0F)*3.33333F):_math.pathRes(1,(_plot_in0-0.3F)*3.33333F):_math.pathRes(2,(_plot_in0-0.6F)*3.33333F);
				_math.funcLerp(out _plot_out.x, this._plot[0][_plot_srch0.s],_plot_srch0.i);
				float _plot_in1=(rnd_b<0F?0F:(rnd_b>0.6F?0.6F:rnd_b));
				_math.PathRes _plot_srch1 = _plot_in1<0.3?_math.pathRes(0,(_plot_in1-0F)*3.33333F):_math.pathRes(1,(_plot_in1-0.3F)*3.33333F);
				_math.funcLerp(out _plot_out.y, this._plot[1][_plot_srch1.s],_plot_srch1.i);
				float _plot_in2=(rnd_b<0F?0F:(rnd_b>0.9F?0.9F:rnd_b));
				_math.PathRes _plot_srch2 = _plot_in2<0.6?_plot_in2<0.3?_math.pathRes(0,(_plot_in2-0F)*3.33333F):_math.pathRes(1,(_plot_in2-0.3F)*3.33333F):_math.pathRes(2,(_plot_in2-0.6F)*3.33333F);
				_math.funcLerp(out _plot_out.z, this._plot[2][_plot_srch2.s],_plot_srch2.i);
				particleImpl._Color = _plot_out;
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime += dt;
				_math.vec3 value_ = _math.vec3_(0F, -100F, 0F);
				_math.vec3 noise_a = _math.mulv3scalar_(_math.vec3_(100F,50F,30F), emitter.effect().time());
				_math.addv3(out noise_a, noise_a, particleImpl._Position);
				_math.vec3 noise_i = _math.mulv3scalar_(noise_a, 1.0F / 1000F); 
				_math.vec3 noise = _math.noisePixelLinear3_(noise_i);
				_math.mulv3(out noise, noise, _math.vec3_(0.0078125F,0.0078125F,0.0078125F));
				_math.addv3(out noise, noise, _math.vec3_(-1F,-1F,-1F));
				_math.mulv3scalar(out noise, noise, 400F);
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
				float value_a = 2F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float expr_ = (particleImpl._lifetime / value_a);
				float _plota_out;
				float _plota_in0=(expr_<0F?0F:(expr_>1F?1F:expr_));
				_math.PathRes _plota_srch0 = _plota_in0<0.956383?_math.pathRes(0,(_plota_in0-0F)*1.04561F):_math.pathRes(1,(_plota_in0-0.956383F)*22.9268F);
				_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
				particleImpl.alpha_ = _plota_out;
			}
		}

		string[] textures_ = new string[] { "bubble.png" };
		public string[] textures() { return textures_; }

		RenderMaterial[] materials_ = new RenderMaterial[] { RenderMaterial.Normal };
		public RenderMaterial[] materials() { return materials_; }

		RenderStyle[] renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
		public RenderStyle[] renderStyles() { return renderStyles_; }

		public float frameTime() { return 0.0333333F; }

		public float presimulateTime() { return 0F; }

		public uint maxNumRenderCalls() { return 10000; }

		public uint maxNumParticles() { return 10000; }

		EmitterModel[] emitterModels_ = new EmitterModel[]{ new Emitter_DefaultEmitter() };
		public EmitterModel[] emitterModels() { return emitterModels_; }

		uint[] activeEmitterModels_ = new uint[] { 0 };
		public uint[] activeEmitterModels() { return activeEmitterModels_; }

	}
}

#pragma warning restore 219
