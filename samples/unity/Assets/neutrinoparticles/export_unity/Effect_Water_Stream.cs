// e2a8473c-43d2-4d2c-80a8-bc3ea46e53a0

#pragma warning disable 219

using System;
namespace Neutrino
{
	[UnityEngine.RequireComponent(typeof(Neutrino.Unity3D.NeutrinoRenderer))]
	public class Effect_Water_Stream : UnityEngine.MonoBehaviour, EffectModel
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
				public float rate() { return 25F; }
			}

			public Generator createGenerator(Emitter emitter)
			{
				return new GeneratorPeriodic(emitter, new GeneratorImpl());
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
				float rnd_ = 0F + _math.rand_() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				float rnd_a = 0F + _math.rand_() * (360F - 0F);
				particleImpl._Angle = rnd_a;
				float rnd_b = 0F + _math.rand_() * (4F - 0F);
				particleImpl._Tex__index = rnd_b;
				float rnd_c = -180F + _math.rand_() * (180F - -180F);
				particleImpl._Rot__speed = rnd_c;
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
				float rnd_ = 0F + _math.rand_() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Velocity = _math.applyv3quat_(conv3d_, emitter.rotation());
				particleImpl._Velocity = _math.addv3_(particleImpl._Velocity, emitter.velocity());
				float rnd_a = 0F + _math.rand_() * (360F - 0F);
				particleImpl._Angle = rnd_a;
				float rnd_b = 0F + _math.rand_() * (4F - 0F);
				particleImpl._Tex__index = rnd_b;
				float rnd_c = -180F + _math.rand_() * (180F - -180F);
				particleImpl._Rot__speed = rnd_c;
				particle.position_ = particleImpl._Position;
			}

			public void updateParticle(Emitter emitter, Particle particle, float dt)
			{
				ParticleImpl particleImpl = (ParticleImpl)particle;
				EmitterData emitterData = (EmitterData)emitter.data();

				GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
				GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
				particleImpl._lifetime += dt;
				_math.vec3 value_ = _math.vec3_(0F, -300F, 0F);
				_math.vec3 fmove_fs = value_;
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
		}

		string[] textures_ = new string[] { "water2x3_white.png" };
		public string[] textures() { return textures_; }

		RenderMaterial[] materials_ = new RenderMaterial[] { RenderMaterial.Normal };
		public RenderMaterial[] materials() { return materials_; }

		RenderStyle[] renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
		public RenderStyle[] renderStyles() { return renderStyles_; }

		public float frameTime() { return 0.0333333F; }

		public float presimulateTime() { return 0F; }

		public uint maxNumRenderCalls() { return 100; }

		public uint maxNumParticles() { return 100; }

		EmitterModel[] emitterModels_ = new EmitterModel[]{ new Emitter_DefaultEmitter() };
		public EmitterModel[] emitterModels() { return emitterModels_; }

		uint[] activeEmitterModels_ = new uint[] { 0 };
		public uint[] activeEmitterModels() { return activeEmitterModels_; }

	}
}

#pragma warning restore 219
