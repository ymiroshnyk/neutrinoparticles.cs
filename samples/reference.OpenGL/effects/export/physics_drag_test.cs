// f9cbf8ae-d128-461b-8c0b-8caa968ba8e0

#pragma warning disable 219

using System;
namespace Neutrino
{
	public class Effect_physics_drag_test : EffectModel
	{
		public class Emitter_drag0 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(135.5F,100F)},{_math.vec2_(135.5F,100F)},{_math.vec2_(135.5F,100F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				_math.vec3 fmove_v = _math.addv3_(particleImpl._Velocity, _math.mulv3scalar_(fmove_fs, dt));
				_math.vec3 fmove_p = _math.mulv3scalar_(fmove_v, dt);
				_math.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				particleImpl._Velocity = fmove_v;
				particle.position_ = particleImpl._Position;
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag0()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag0";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag0_wind : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(225.5F,203F)},{_math.vec2_(225.5F,203F)},{_math.vec2_(225.5F,203F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				_math.vec3 fmove_v = _math.addv3_(particleImpl._Velocity, _math.mulv3scalar_(fmove_fs, dt));
				_math.vec3 fmove_p = _math.mulv3scalar_(fmove_v, dt);
				_math.addv3(out fmove_p, fmove_p, particleImpl._Position);
				particleImpl._Position = fmove_p;
				particleImpl._Velocity = fmove_v;
				particle.position_ = particleImpl._Position;
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag0_wind()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag0_wind";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag1 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(357.5F,101F)},{_math.vec2_(357.5F,101F)},{_math.vec2_(357.5F,101F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag1()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag1";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag2 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(646.5F,105F)},{_math.vec2_(646.5F,105F)},{_math.vec2_(646.5F,105F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
						float fmove_df = 0.01F * 2F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag2()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag2";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag3 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(144.5F,319F)},{_math.vec2_(144.5F,319F)},{_math.vec2_(144.5F,319F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
						float fmove_df = 0.01F * 3F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag3()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag3";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag4 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(303.5F,318F)},{_math.vec2_(303.5F,318F)},{_math.vec2_(303.5F,318F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
						float fmove_df = 0.01F * 4F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag4()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag4";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag10 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(456.5F,328F)},{_math.vec2_(456.5F,328F)},{_math.vec2_(456.5F,328F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
						float fmove_df = 0.01F * 10F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag10()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag10";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag20 : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(624.5F,329F)},{_math.vec2_(624.5F,329F)},{_math.vec2_(624.5F,329F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
						float fmove_df = 0.01F * 20F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag20()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag20";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public class Emitter_drag20_wind : EmitterModel
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
				public float burst() { return 100F; }
				public float? fixedTime() { return null; }
				public float? fixedShots() { return null; }
				public float startPhase() { return 1F; }
				public float rate() { return 2F; }
			}

			_math.vec2 [][,] _path = 
			{
				new _math.vec2[,] {{_math.vec2_(674.5F,344F)},{_math.vec2_(674.5F,344F)},{_math.vec2_(674.5F,344F)}}
			};

			public class ConstructorImpl : ConstructorQuads.Impl
			{
				public ConstructorQuads.RotationType rotationType() { return ConstructorQuads.RotationType.Faced; }
				public ConstructorQuads.SizeType sizeType() { return ConstructorQuads.SizeType.Quad; }
				public ConstructorQuads.TexMapType texMapType() { return ConstructorQuads.TexMapType.WholeRect; }
				public _math.vec2 gridSize() { return _math.vec2_(0, 0); }
				public ushort renderStyleIndex() { return 0; }
			}

			public override void setPropertyValue(object emitterData, string name, float value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec2 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.vec3 value)
			{
			}

			public override void setPropertyValue(object emitterData, string name, _math.quat value)
			{
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				float rnd_ = 0F + emitter.random()() * (1F - 0F);
				float _path_in = _math.clamp_(rnd_, 0, 1);
				_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
				_math.vec2 _path_pos;
				_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
				_math.vec3 conv3d_ = _math.vec3_(_path_pos.x, _path_pos.y, 0F);
				particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
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
				_math.vec3 fmove_vs = _math.vec3_(100F,0F,0F);
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
						float fmove_df = 0.01F * 20F * fmove_rwl;
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
				float value_a = 1F;
				if (particleImpl._lifetime > value_a) 
				{
					particle.dead_ = true;
				}
				float value_b = 30F;
				particleImpl.size1_ = value_b;
			}
			public Emitter_drag20_wind()
			{
				generatorCreator_ = (Emitter emitter) => { return new GeneratorPeriodic(emitter, new GeneratorImpl()); };
				constructorCreator_ = (Emitter emitter) => { return new ConstructorQuads(emitter, new ConstructorImpl()); };
				name_ = "drag20_wind";
				maxNumParticles_ = 100;
				sorting_ = Emitter.Sorting.OldToYoung;
				particleCreator_ = (Effect effect) => { return new ParticleImpl(); };
				emitterDataCreator_ = () => { return new EmitterData(); };
			}
		}

		public Effect_physics_drag_test()
		{
			textures_ = new string[] { "star_glow_white.png" };
			materials_ = new RenderMaterial[] { RenderMaterial.Normal };
			renderStyles_ = new RenderStyle[] { new RenderStyle(0,new uint[] {0}) };
			frameTime_ = 0.0333333F;
			presimulateTime_ = 0F;
			maxNumRenderCalls_ = 900;
			maxNumParticles_ = 900;
			emitterModels_ = new EmitterModel[]{ new Emitter_drag0(), new Emitter_drag0_wind(), new Emitter_drag1(), new Emitter_drag2(), new Emitter_drag3(), new Emitter_drag4(), new Emitter_drag10(), new Emitter_drag20(), new Emitter_drag20_wind() };
			activeEmitterModels_ = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			randomGeneratorCreator_ = () => { return _math.rand_; };
		}
	}
}

#pragma warning restore 219
