// caa7b29f-9cd3-4ba4-b2cd-61a5ed791cad

#pragma warning disable 219

using System;

namespace Neutrino
{
	public class Effect_random_test : EffectModel
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
				public override _math.vec3 color() { return _math.vec3_(1F,1F,1F); }
				public override float alpha() { return 1; }
				public override float gridIndex() { return 0; }
				public override AttachedEmitter[] attachedEmitters() { return null; }

			}


			public class EmitterData
			{
			}

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 10F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 0.5F; }
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
				_math.vec3 randvec_ = _math.randv3gen_(1000F, emitter.random());
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
				_math.vec3 randvec_ = _math.randv3gen_(1000F, emitter.random());
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
				_math.vec3 value_ = _math.vec3_(0F, 100F, 0F);
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
				particle.position_ = particleImpl._Position;
				float value_a = 2F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
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

		public Effect_random_test()
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
			randomGeneratorCreator_ = () => { Taus88 taus88 = new Taus88(100); return taus88.rand; };
		}
	}
}

#pragma warning restore 219
