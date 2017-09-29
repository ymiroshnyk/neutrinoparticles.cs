// 07729bdd-a07b-46d3-ba6c-2c94f9bbeb24

#pragma warning disable 219

using System;
namespace Neutrino
{
	public class Effect_params_test : EffectModel
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
				public _math.vec3 color_;
				public override _math.vec3 color() { return color_; }
				public override float alpha() { return 1; }
				public override float gridIndex() { return 0; }
				public override AttachedEmitter[] attachedEmitters() { return null; }

			}


			public class EmitterData
			{
				public _math.vec3 _Color = _math.vec3_(0F,0F,0F);
			}

			public class GeneratorImpl : GeneratorPeriodic.Impl
			{
				public float burst() { return 1F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 50F; }
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
				_math.vec3 randvec_ = _math.randv3gen_(100F, emitter.random());
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
				_math.vec3 randvec_ = _math.randv3gen_(100F, emitter.random());
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
				_math.vec3 move_ = _math.addv3_(particleImpl._Position, _math.mulv3scalar_(particleImpl._Velocity, dt));
				particleImpl._Position = move_;
				particle.position_ = particleImpl._Position;
				float value_ = 2F;
				if (particleImpl._lifetime > value_) 
				{
					particle.dead_ = true;
				}
				float value_a = 30F;
				particleImpl.size1_ = value_a;
				particleImpl.color_ = emitterData._Color;
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
				addProperty("Color", PropertyType.VEC3,
					(object emitterData) =>
					{
						return ((EmitterData)emitterData)._Color;
					}, 
					(object emitterData, object value) => 
					{
						_math.copyv3(out ((EmitterData)emitterData)._Color, (_math.vec3)value);
					});
			}
		}

		public Effect_params_test()
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
			randomGeneratorCreator_ = () => { return _math.rand_; };
		}
	}
}

#pragma warning restore 219
