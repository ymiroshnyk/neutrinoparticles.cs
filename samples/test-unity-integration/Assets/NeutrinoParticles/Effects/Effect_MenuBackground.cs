// c2b3ed97-f943-4f68-a431-c163de73e2bd

#pragma warning disable 219

using System;
using Neutrino.Unity3D;

namespace Neutrino
{
	public class Effect_MenuBackground : NeutrinoRenderer
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
					public float _Graph_shift;
					public _math.quat _Emitter_rot_;
					public float _Angle;
					public float _Size;
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
					public _math.vec3 _Color = _math.vec3_(0F,0.7F,1F);
				}

				public class GeneratorImpl : GeneratorPeriodic.Impl
				{
					public float burst() { return 1F; }
					public float? fixedTime() { return null; }
					public float? fixedShots() { return null; }
					public float startPhase() { return 1F; }
					public float rate() { return 5F; }
				}

				_math.vec2 [][,] _path = 
				{
					new _math.vec2[,] {{_math.vec2_(-200F,197F)},{_math.vec2_(-200F,-200F)},{_math.vec2_(-200F,-200F)}}
				};

				_math.vec2 [][,] _patha = 
				{
					new _math.vec2[,] {{_math.vec2_(201F,202F)},{_math.vec2_(201F,-200F)},{_math.vec2_(201F,-200F)}}
				};

				float [][][] _plot = 
				{
					new float[][] { new float[]{ 0F,1F,1F }}
				};

				_math.vec2 [][,] _pathb = 
				{
					new _math.vec2[,] {{_math.vec2_(0.0424471F,-0.860121F),_math.vec2_(0.944671F,0.32802F)},{_math.vec2_(1.49895F,-0.354377F),_math.vec2_(0.91439F,0.404833F)},{_math.vec2_(2.90919F,0.269986F),_math.vec2_(0.891589F,0.452845F)},{_math.vec2_(4.28441F,0.968471F),_math.vec2_(0.876226F,0.481901F)},{_math.vec2_(5.636F,1.71181F),_math.vec2_(0.86765F,0.497176F)},{_math.vec2_(6.97439F,2.47873F),_math.vec2_(0.865382F,0.501113F)},{_math.vec2_(8.30928F,3.25172F),_math.vec2_(0.869285F,0.494311F)},{_math.vec2_(9.65019F,4.01421F),_math.vec2_(0.879591F,0.47573F)},{_math.vec2_(11.007F,4.74802F),_math.vec2_(0.896856F,0.442324F)},{_math.vec2_(12.3903F,5.43027F),_math.vec2_(0.921689F,0.387931F)},{_math.vec2_(13.8117F,6.02854F),_math.vec2_(0.953635F,0.300964F)},{_math.vec2_(15.2819F,6.49253F),_math.vec2_(0.986953F,0.161008F)},{_math.vec2_(16.8023F,6.74057F),_math.vec2_(0.998286F,-0.0585276F)},{_math.vec2_(18.3377F,6.65055F),_math.vec2_(0.93608F,-0.351787F)},{_math.vec2_(19.7752F,6.11033F),_math.vec2_(0.779684F,-0.626173F)},{_math.vec2_(20.9736F,5.14788F),_math.vec2_(0.779684F,-0.626173F)},{_math.vec2_(20.9736F,5.14788F),_math.vec2_(0.779684F,-0.626173F)}},
					new _math.vec2[,] {{_math.vec2_(20.9736F,5.14789F),_math.vec2_(0.582319F,-0.81296F)},{_math.vec2_(21.9966F,3.71964F),_math.vec2_(0.394938F,-0.918708F)},{_math.vec2_(22.6913F,2.10359F),_math.vec2_(0.245686F,-0.969349F)},{_math.vec2_(23.1238F,0.397425F),_math.vec2_(0.126921F,-0.991913F)},{_math.vec2_(23.3472F,-1.34893F),_math.vec2_(0.0284008F,-0.999597F)},{_math.vec2_(23.3972F,-3.10911F),_math.vec2_(-0.0577408F,-0.998332F)},{_math.vec2_(23.2955F,-4.86719F),_math.vec2_(-0.137309F,-0.990528F)},{_math.vec2_(23.0537F,-6.61155F),_math.vec2_(-0.214912F,-0.976633F)},{_math.vec2_(22.6753F,-8.33144F),_math.vec2_(-0.294829F,-0.95555F)},{_math.vec2_(22.1561F,-10.0141F),_math.vec2_(-0.381679F,-0.924295F)},{_math.vec2_(21.484F,-11.6416F),_math.vec2_(-0.481101F,-0.876665F)},{_math.vec2_(20.6371F,-13.1849F),_math.vec2_(-0.59987F,-0.800097F)},{_math.vec2_(19.5816F,-14.5927F),_math.vec2_(-0.742688F,-0.669638F)},{_math.vec2_(18.2763F,-15.7696F),_math.vec2_(-0.895326F,-0.445412F)},{_math.vec2_(16.7057F,-16.5509F),_math.vec2_(-0.993374F,-0.114928F)},{_math.vec2_(14.9656F,-16.7523F),_math.vec2_(-0.993374F,-0.114928F)},{_math.vec2_(14.9656F,-16.7523F),_math.vec2_(-0.993374F,-0.114928F)}},
					new _math.vec2[,] {{_math.vec2_(14.9656F,-16.7523F),_math.vec2_(-0.988942F,0.148301F)},{_math.vec2_(12.7818F,-16.4248F),_math.vec2_(-0.952591F,0.304253F)},{_math.vec2_(10.678F,-15.7528F),_math.vec2_(-0.898438F,0.4391F)},{_math.vec2_(8.69334F,-14.7829F),_math.vec2_(-0.835477F,0.549525F)},{_math.vec2_(6.84741F,-13.5687F),_math.vec2_(-0.77043F,0.637524F)},{_math.vec2_(5.14495F,-12.16F),_math.vec2_(-0.707026F,0.707188F)},{_math.vec2_(3.58241F,-10.5971F),_math.vec2_(-0.646755F,0.762698F)},{_math.vec2_(2.15297F,-8.91139F),_math.vec2_(-0.589813F,0.80754F)},{_math.vec2_(0.849328F,-7.1265F),_math.vec2_(-0.53572F,0.844396F)},{_math.vec2_(-0.334805F,-5.26009F),_math.vec2_(-0.483664F,0.875253F)},{_math.vec2_(-1.40389F,-3.32543F),_math.vec2_(-0.432638F,0.901568F)},{_math.vec2_(-2.3602F,-1.33259F),_math.vec2_(-0.381456F,0.924387F)},{_math.vec2_(-3.20338F,0.710687F),_math.vec2_(-0.328678F,0.944442F)},{_math.vec2_(-3.92989F,2.7983F),_math.vec2_(-0.27244F,0.962173F)},{_math.vec2_(-4.53209F,4.92506F),_math.vec2_(-0.21013F,0.977673F)},{_math.vec2_(-4.99653F,7.08595F),_math.vec2_(-0.21013F,0.977673F)},{_math.vec2_(-4.99653F,7.08595F),_math.vec2_(-0.21013F,0.977673F)}},
					new _math.vec2[,] {{_math.vec2_(-4.99653F,7.08595F),_math.vec2_(0.00217852F,0.999998F)},{_math.vec2_(-4.99391F,8.28607F),_math.vec2_(0.354119F,0.9352F)},{_math.vec2_(-4.5686F,9.40929F),_math.vec2_(0.609535F,0.792759F)},{_math.vec2_(-3.83488F,10.3636F),_math.vec2_(0.760117F,0.649786F)},{_math.vec2_(-2.91868F,11.1468F),_math.vec2_(0.847797F,0.53032F)},{_math.vec2_(-1.89621F,11.7864F),_math.vec2_(0.901995F,0.431746F)},{_math.vec2_(-0.80815F,12.3072F),_math.vec2_(0.937727F,0.347373F)},{_math.vec2_(0.323193F,12.7263F),_math.vec2_(0.962432F,0.271522F)},{_math.vec2_(1.48441F,13.0539F),_math.vec2_(0.979859F,0.199692F)},{_math.vec2_(2.66667F,13.2948F),_math.vec2_(0.991775F,0.127995F)},{_math.vec2_(3.8633F,13.4492F),_math.vec2_(0.998621F,0.052507F)},{_math.vec2_(5.06814F,13.5126F),_math.vec2_(0.999505F,-0.0314683F)},{_math.vec2_(6.27396F,13.4746F),_math.vec2_(0.991467F,-0.130355F)},{_math.vec2_(7.4699F,13.3174F),_math.vec2_(0.967309F,-0.2536F)},{_math.vec2_(8.63628F,13.0116F),_math.vec2_(0.910162F,-0.414252F)},{_math.vec2_(9.73278F,12.5125F),_math.vec2_(0.910162F,-0.414252F)},{_math.vec2_(9.73278F,12.5125F),_math.vec2_(0.910162F,-0.414252F)}},
					new _math.vec2[,] {{_math.vec2_(9.73278F,12.5125F),_math.vec2_(0.786889F,-0.617094F)},{_math.vec2_(10.5282F,11.8887F),_math.vec2_(0.604466F,-0.796631F)},{_math.vec2_(11.1395F,11.0832F),_math.vec2_(0.413321F,-0.910585F)},{_math.vec2_(11.5578F,10.1616F),_math.vec2_(0.246582F,-0.969122F)},{_math.vec2_(11.8075F,9.18015F),_math.vec2_(0.111513F,-0.993763F)},{_math.vec2_(11.9205F,8.17333F),_math.vec2_(0.00298893F,-0.999996F)},{_math.vec2_(11.9235F,7.15997F),_math.vec2_(-0.0861099F,-0.996286F)},{_math.vec2_(11.8362F,6.15027F),_math.vec2_(-0.161713F,-0.986838F)},{_math.vec2_(11.6723F,5.15006F),_math.vec2_(-0.228281F,-0.973595F)},{_math.vec2_(11.4409F,4.16324F),_math.vec2_(-0.289208F,-0.957266F)},{_math.vec2_(11.1478F,3.19295F),_math.vec2_(-0.347249F,-0.937773F)},{_math.vec2_(10.7958F,2.24243F),_math.vec2_(-0.404911F,-0.914356F)},{_math.vec2_(10.3854F,1.31565F),_math.vec2_(-0.464815F,-0.885408F)},{_math.vec2_(9.91429F,0.418232F),_math.vec2_(-0.530139F,-0.847911F)},{_math.vec2_(9.37702F,-0.441089F),_math.vec2_(-0.60522F,-0.796058F)},{_math.vec2_(8.76375F,-1.24774F),_math.vec2_(-0.60522F,-0.796058F)},{_math.vec2_(8.76375F,-1.24774F),_math.vec2_(-0.60522F,-0.796058F)}},
					new _math.vec2[,] {{_math.vec2_(8.76375F,-1.24773F),_math.vec2_(-0.658241F,-0.752807F)},{_math.vec2_(7.77758F,-2.37558F),_math.vec2_(-0.679202F,-0.733951F)},{_math.vec2_(6.75994F,-3.47524F),_math.vec2_(-0.69947F,-0.714662F)},{_math.vec2_(5.71195F,-4.546F),_math.vec2_(-0.720135F,-0.693834F)},{_math.vec2_(4.63298F,-5.58556F),_math.vec2_(-0.741982F,-0.67042F)},{_math.vec2_(3.52131F,-6.59002F),_math.vec2_(-0.765729F,-0.643164F)},{_math.vec2_(2.37407F,-7.55362F),_math.vec2_(-0.792121F,-0.610365F)},{_math.vec2_(1.18734F,-8.46806F),_math.vec2_(-0.821996F,-0.569493F)},{_math.vec2_(-0.0441217F,-9.32123F),_math.vec2_(-0.85624F,-0.516579F)},{_math.vec2_(-1.32679F,-10.0951F),_math.vec2_(-0.89551F,-0.445042F)},{_math.vec2_(-2.66806F,-10.7617F),_math.vec2_(-0.939085F,-0.343685F)},{_math.vec2_(-4.0741F,-11.2762F),_math.vec2_(-0.980994F,-0.19404F)},{_math.vec2_(-5.54183F,-11.5665F),_math.vec2_(-0.999636F,0.0269884F)},{_math.vec2_(-7.03535F,-11.5262F),_math.vec2_(-0.948609F,0.316449F)},{_math.vec2_(-8.45052F,-11.0541F),_math.vec2_(-0.80216F,0.59711F)},{_math.vec2_(-9.64789F,-10.1628F),_math.vec2_(-0.80216F,0.59711F)},{_math.vec2_(-9.64789F,-10.1628F),_math.vec2_(-0.80216F,0.59711F)}},
					new _math.vec2[,] {{_math.vec2_(-9.64789F,-10.1628F),_math.vec2_(-0.645666F,0.76362F)},{_math.vec2_(-10.8847F,-8.70009F),_math.vec2_(-0.518247F,0.855231F)},{_math.vec2_(-11.8776F,-7.06152F),_math.vec2_(-0.394476F,0.918906F)},{_math.vec2_(-12.6336F,-5.30056F),_math.vec2_(-0.280532F,0.959845F)},{_math.vec2_(-13.1713F,-3.46079F),_math.vec2_(-0.178148F,0.984004F)},{_math.vec2_(-13.5128F,-1.57453F),_math.vec2_(-0.0865288F,0.996249F)},{_math.vec2_(-13.6787F,0.335402F),_math.vec2_(-0.00385502F,0.999993F)},{_math.vec2_(-13.6861F,2.25262F),_math.vec2_(0.0719276F,0.99741F)},{_math.vec2_(-13.5482F,4.16495F),_math.vec2_(0.142805F,0.989751F)},{_math.vec2_(-13.2744F,6.06263F),_math.vec2_(0.210624F,0.977567F)},{_math.vec2_(-12.8705F,7.93696F),_math.vec2_(0.277122F,0.960835F)},{_math.vec2_(-12.3392F,9.77922F),_math.vec2_(0.344004F,0.938968F)},{_math.vec2_(-11.6796F,11.5795F),_math.vec2_(0.413029F,0.910718F)},{_math.vec2_(-10.8877F,13.3256F),_math.vec2_(0.48607F,0.87392F)},{_math.vec2_(-9.95589F,15.001F),_math.vec2_(0.565092F,0.825028F)},{_math.vec2_(-8.87266F,16.5825F),_math.vec2_(0.565092F,0.825028F)},{_math.vec2_(-8.87266F,16.5825F),_math.vec2_(0.565092F,0.825028F)}},
					new _math.vec2[,] {{_math.vec2_(-8.87266F,16.5825F),_math.vec2_(0.711684F,0.702499F)},{_math.vec2_(-7.82249F,17.6191F),_math.vec2_(0.844904F,0.534918F)},{_math.vec2_(-6.57378F,18.4097F),_math.vec2_(0.914171F,0.405329F)},{_math.vec2_(-5.22185F,19.0091F),_math.vec2_(0.952875F,0.303363F)},{_math.vec2_(-3.81228F,19.4578F),_math.vec2_(0.975823F,0.218562F)},{_math.vec2_(-2.3686F,19.7812F),_math.vec2_(0.989638F,0.143583F)},{_math.vec2_(-0.904409F,19.9936F),_math.vec2_(0.997326F,0.0730848F)},{_math.vec2_(0.571167F,20.1018F),_math.vec2_(0.999996F,0.0026389F)},{_math.vec2_(2.05069F,20.1057F),_math.vec2_(0.99738F,-0.0723453F)},{_math.vec2_(3.52624F,19.9986F),_math.vec2_(0.987492F,-0.157672F)},{_math.vec2_(4.98701F,19.7654F),_math.vec2_(0.96504F,-0.262104F)},{_math.vec2_(6.41426F,19.3778F),_math.vec2_(0.916461F,-0.400123F)},{_math.vec2_(7.76871F,18.7864F),_math.vec2_(0.805215F,-0.592983F)},{_math.vec2_(8.95643F,17.9117F),_math.vec2_(0.547422F,-0.836856F)},{_math.vec2_(9.76011F,16.6831F),_math.vec2_(0.113498F,-0.993538F)},{_math.vec2_(9.92659F,15.2258F),_math.vec2_(0.113498F,-0.993538F)},{_math.vec2_(9.92659F,15.2258F),_math.vec2_(0.113498F,-0.993538F)}},
					new _math.vec2[,] {{_math.vec2_(9.92659F,15.2258F),_math.vec2_(-0.258839F,-0.965921F)},{_math.vec2_(9.48698F,13.5853F),_math.vec2_(-0.556908F,-0.830574F)},{_math.vec2_(8.54111F,12.1747F),_math.vec2_(-0.762936F,-0.646474F)},{_math.vec2_(7.24266F,11.0744F),_math.vec2_(-0.868896F,-0.494994F)},{_math.vec2_(5.76187F,10.2308F),_math.vec2_(-0.919366F,-0.393404F)},{_math.vec2_(4.19418F,9.56001F),_math.vec2_(-0.943676F,-0.33087F)},{_math.vec2_(2.58469F,8.99569F),_math.vec2_(-0.954994F,-0.296624F)},{_math.vec2_(0.955779F,8.48975F),_math.vec2_(-0.958733F,-0.284307F)},{_math.vec2_(-0.679534F,8.0048F),_math.vec2_(-0.956664F,-0.291193F)},{_math.vec2_(-2.31131F,7.50811F),_math.vec2_(-0.948304F,-0.317362F)},{_math.vec2_(-3.92876F,6.96682F),_math.vec2_(-0.930832F,-0.365448F)},{_math.vec2_(-5.5162F,6.34358F),_math.vec2_(-0.897725F,-0.440555F)},{_math.vec2_(-7.04682F,5.59244F),_math.vec2_(-0.835856F,-0.548949F)},{_math.vec2_(-8.47116F,4.657F),_math.vec2_(-0.722922F,-0.69093F)},{_math.vec2_(-9.70191F,3.48072F),_math.vec2_(-0.537977F,-0.842959F)},{_math.vec2_(-10.6169F,2.04698F),_math.vec2_(-0.537977F,-0.842959F)},{_math.vec2_(-10.6169F,2.04698F),_math.vec2_(-0.537977F,-0.842959F)}},
					new _math.vec2[,] {{_math.vec2_(-10.6169F,2.04698F),_math.vec2_(-0.342974F,-0.939345F)},{_math.vec2_(-11.0862F,0.761712F),_math.vec2_(-0.200166F,-0.979762F)},{_math.vec2_(-11.3602F,-0.579401F),_math.vec2_(-0.0792696F,-0.996853F)},{_math.vec2_(-11.4687F,-1.94423F),_math.vec2_(0.0242468F,-0.999706F)},{_math.vec2_(-11.4355F,-3.31313F),_math.vec2_(0.115253F,-0.993336F)},{_math.vec2_(-11.2777F,-4.67342F),_math.vec2_(0.197877F,-0.980227F)},{_math.vec2_(-11.0067F,-6.01581F),_math.vec2_(0.275474F,-0.961308F)},{_math.vec2_(-10.6294F,-7.3323F),_math.vec2_(0.350817F,-0.936444F)},{_math.vec2_(-10.149F,-8.61474F),_math.vec2_(0.426317F,-0.904574F)},{_math.vec2_(-9.5652F,-9.85349F),_math.vec2_(0.504149F,-0.863617F)},{_math.vec2_(-8.87483F,-11.0361F),_math.vec2_(0.586215F,-0.810156F)},{_math.vec2_(-8.07218F,-12.1454F),_math.vec2_(0.673761F,-0.738949F)},{_math.vec2_(-7.14982F,-13.157F),_math.vec2_(0.766279F,-0.642509F)},{_math.vec2_(-6.10109F,-14.0363F),_math.vec2_(0.859125F,-0.511765F)},{_math.vec2_(-4.92572F,-14.7365F),_math.vec2_(0.940315F,-0.340304F)},{_math.vec2_(-3.63988F,-15.2018F),_math.vec2_(0.940315F,-0.340304F)},{_math.vec2_(-3.63988F,-15.2018F),_math.vec2_(0.940315F,-0.340304F)}},
					new _math.vec2[,] {{_math.vec2_(-3.63988F,-15.2018F),_math.vec2_(0.984152F,-0.177325F)},{_math.vec2_(-1.92689F,-15.5105F),_math.vec2_(0.998219F,-0.0596582F)},{_math.vec2_(-0.18909F,-15.6143F),_math.vec2_(0.999036F,0.0439011F)},{_math.vec2_(1.55028F,-15.5379F),_math.vec2_(0.990762F,0.13561F)},{_math.vec2_(3.27542F,-15.3018F),_math.vec2_(0.97594F,0.21804F)},{_math.vec2_(4.97482F,-14.9221F),_math.vec2_(0.955942F,0.293556F)},{_math.vec2_(6.63945F,-14.4109F),_math.vec2_(0.931321F,0.364201F)},{_math.vec2_(8.26123F,-13.7767F),_math.vec2_(0.902021F,0.431693F)},{_math.vec2_(9.83198F,-13.025F),_math.vec2_(0.86747F,0.49749F)},{_math.vec2_(11.3426F,-12.1586F),_math.vec2_(0.826595F,0.562797F)},{_math.vec2_(12.7819F,-11.1786F),_math.vec2_(0.77776F,0.628561F)},{_math.vec2_(14.1362F,-10.0842F),_math.vec2_(0.718674F,0.695347F)},{_math.vec2_(15.3875F,-8.87347F),_math.vec2_(0.646314F,0.763071F)},{_math.vec2_(16.5127F,-7.545F),_math.vec2_(0.557008F,0.830507F)},{_math.vec2_(17.4823F,-6.09931F),_math.vec2_(0.447002F,0.894533F)},{_math.vec2_(18.2603F,-4.54244F),_math.vec2_(0.447002F,0.894533F)},{_math.vec2_(18.2603F,-4.54244F),_math.vec2_(0.447002F,0.894533F)}},
					new _math.vec2[,] {{_math.vec2_(18.2603F,-4.54245F),_math.vec2_(0.219342F,0.975648F)},{_math.vec2_(18.5533F,-3.23896F),_math.vec2_(-0.0797593F,0.996814F)},{_math.vec2_(18.4466F,-1.9046F),_math.vec2_(-0.296973F,0.954886F)},{_math.vec2_(18.0485F,-0.624599F),_math.vec2_(-0.445925F,0.89507F)},{_math.vec2_(17.4503F,0.576016F),_math.vec2_(-0.552248F,0.83368F)},{_math.vec2_(16.7093F,1.6946F),_math.vec2_(-0.633256F,0.773942F)},{_math.vec2_(15.8595F,2.73319F),_math.vec2_(-0.699149F,0.714976F)},{_math.vec2_(14.9213F,3.69271F),_math.vec2_(-0.75603F,0.654537F)},{_math.vec2_(13.9066F,4.57113F),_math.vec2_(-0.807738F,0.589542F)},{_math.vec2_(12.8226F,5.3623F),_math.vec2_(-0.856752F,0.515728F)},{_math.vec2_(11.6729F,6.05437F),_math.vec2_(-0.904376F,0.426736F)},{_math.vec2_(10.4595F,6.62696F),_math.vec2_(-0.94995F,0.312403F)},{_math.vec2_(9.18525F,7.046F),_math.vec2_(-0.987704F,0.156333F)},{_math.vec2_(7.86125F,7.25556F),_math.vec2_(-0.997973F,-0.0636331F)},{_math.vec2_(6.52529F,7.17038F),_math.vec2_(-0.935522F,-0.353268F)},{_math.vec2_(5.27522F,6.69834F),_math.vec2_(-0.935522F,-0.353268F)},{_math.vec2_(5.27522F,6.69834F),_math.vec2_(-0.935522F,-0.353268F)}},
					new _math.vec2[,] {{_math.vec2_(5.27523F,6.69834F),_math.vec2_(-0.815313F,-0.579021F)},{_math.vec2_(3.86278F,5.69524F),_math.vec2_(-0.724289F,-0.689497F)},{_math.vec2_(2.60734F,4.50011F),_math.vec2_(-0.642621F,-0.766184F)},{_math.vec2_(1.49325F,3.1718F),_math.vec2_(-0.568676F,-0.822562F)},{_math.vec2_(0.507244F,1.74559F),_math.vec2_(-0.499586F,-0.866264F)},{_math.vec2_(-0.35903F,0.243507F),_math.vec2_(-0.432465F,-0.901651F)},{_math.vec2_(-1.10893F,-1.31998F),_math.vec2_(-0.364467F,-0.931216F)},{_math.vec2_(-1.74093F,-2.93473F),_math.vec2_(-0.292541F,-0.956253F)},{_math.vec2_(-2.24819F,-4.59285F),_math.vec2_(-0.213035F,-0.977045F)},{_math.vec2_(-2.61757F,-6.28693F),_math.vec2_(-0.121165F,-0.992632F)},{_math.vec2_(-2.82763F,-8.00785F),_math.vec2_(-0.0103704F,-0.999946F)},{_math.vec2_(-2.8456F,-9.74108F),_math.vec2_(0.12804F,-0.991769F)},{_math.vec2_(-2.62376F,-11.4595F),_math.vec2_(0.302875F,-0.95303F)},{_math.vec2_(-2.09936F,-13.1095F),_math.vec2_(0.512802F,-0.858507F)},{_math.vec2_(-1.21241F,-14.5944F),_math.vec2_(0.725952F,-0.687746F)},{_math.vec2_(0.0424437F,-15.7832F),_math.vec2_(0.725952F,-0.687746F)},{_math.vec2_(0.0424437F,-15.7832F),_math.vec2_(0.725952F,-0.687746F)}},
					new _math.vec2[,] {{_math.vec2_(0.0424471F,-15.7832F),_math.vec2_(0.858918F,-0.512113F)},{_math.vec2_(2.052F,-16.9814F),_math.vec2_(0.922278F,-0.386527F)},{_math.vec2_(4.21042F,-17.886F),_math.vec2_(0.961867F,-0.273517F)},{_math.vec2_(6.46192F,-18.5262F),_math.vec2_(0.985021F,-0.172432F)},{_math.vec2_(8.76789F,-18.9299F),_math.vec2_(0.996716F,-0.0809823F)},{_math.vec2_(11.1014F,-19.1195F),_math.vec2_(0.999994F,0.00345007F)},{_math.vec2_(13.4427F,-19.1114F),_math.vec2_(0.996521F,0.0833427F)},{_math.vec2_(15.7759F,-18.9163F),_math.vec2_(0.986962F,0.160956F)},{_math.vec2_(18.0867F,-18.5394F),_math.vec2_(0.971177F,0.23836F)},{_math.vec2_(20.3605F,-17.9813F),_math.vec2_(0.94825F,0.317526F)},{_math.vec2_(22.5806F,-17.2379F),_math.vec2_(0.916372F,0.400328F)},{_math.vec2_(24.7259F,-16.3007F),_math.vec2_(0.8726F,0.488436F)},{_math.vec2_(26.7686F,-15.1574F),_math.vec2_(0.812537F,0.58291F)},{_math.vec2_(28.6704F,-13.793F),_math.vec2_(0.7302F,0.683233F)},{_math.vec2_(30.3791F,-12.1942F),_math.vec2_(0.618836F,0.78552F)},{_math.vec2_(31.8267F,-10.3566F),_math.vec2_(0.618836F,0.78552F)},{_math.vec2_(31.8267F,-10.3566F),_math.vec2_(0.618836F,0.78552F)}},
					new _math.vec2[,] {{_math.vec2_(31.8267F,-10.3566F),_math.vec2_(0.464919F,0.885353F)},{_math.vec2_(32.8537F,-8.40098F),_math.vec2_(0.298114F,0.95453F)},{_math.vec2_(33.5125F,-6.29148F),_math.vec2_(0.151151F,0.988511F)},{_math.vec2_(33.8467F,-4.10616F),_math.vec2_(0.025635F,0.999671F)},{_math.vec2_(33.9034F,-1.89559F),_math.vec2_(-0.0819154F,0.996639F)},{_math.vec2_(33.7222F,0.308526F),_math.vec2_(-0.175998F,0.984391F)},{_math.vec2_(33.333F,2.48573F),_math.vec2_(-0.260675F,0.965427F)},{_math.vec2_(32.7564F,4.62112F),_math.vec2_(-0.339345F,0.940662F)},{_math.vec2_(32.0058F,6.70175F),_math.vec2_(-0.414806F,0.90991F)},{_math.vec2_(31.0883F,8.71436F),_math.vec2_(-0.489458F,0.872027F)},{_math.vec2_(30.0057F,10.6431F),_math.vec2_(-0.565393F,0.824821F)},{_math.vec2_(28.7552F,12.4673F),_math.vec2_(-0.644347F,0.764733F)},{_math.vec2_(27.3303F,14.1585F),_math.vec2_(-0.727293F,0.686328F)},{_math.vec2_(25.7222F,15.6761F),_math.vec2_(-0.813274F,0.581881F)},{_math.vec2_(23.9244F,16.9623F),_math.vec2_(-0.896964F,0.442103F)},{_math.vec2_(21.9426F,17.9391F),_math.vec2_(-0.896964F,0.442103F)},{_math.vec2_(21.9426F,17.9391F),_math.vec2_(-0.896964F,0.442103F)}},
					new _math.vec2[,] {{_math.vec2_(21.9426F,17.9391F),_math.vec2_(-0.946596F,0.322422F)},{_math.vec2_(18.9617F,18.9545F),_math.vec2_(-0.966146F,0.257995F)},{_math.vec2_(15.9189F,19.767F),_math.vec2_(-0.979811F,0.199927F)},{_math.vec2_(12.8331F,20.3966F),_math.vec2_(-0.989457F,0.144827F)},{_math.vec2_(9.71674F,20.8528F),_math.vec2_(-0.995923F,0.0902129F)},{_math.vec2_(6.58011F,21.1369F),_math.vec2_(-0.999422F,0.0339815F)},{_math.vec2_(3.43248F,21.2439F),_math.vec2_(-0.999664F,-0.0259142F)},{_math.vec2_(0.28416F,21.1623F),_math.vec2_(-0.995787F,-0.0916971F)},{_math.vec2_(-2.85181F,20.8735F),_math.vec2_(-0.986133F,-0.165958F)},{_math.vec2_(-5.95715F,20.3509F),_math.vec2_(-0.967791F,-0.251754F)},{_math.vec2_(-9.0044F,19.5583F),_math.vec2_(-0.935846F,-0.352409F)},{_math.vec2_(-11.9506F,18.4488F),_math.vec2_(-0.882418F,-0.470466F)},{_math.vec2_(-14.7277F,16.9682F),_math.vec2_(-0.796448F,-0.604707F)},{_math.vec2_(-17.2332F,15.0659F),_math.vec2_(-0.667288F,-0.7448F)},{_math.vec2_(-19.3314F,12.724F),_math.vec2_(-0.495368F,-0.868683F)},{_math.vec2_(-20.8887F,9.99305F),_math.vec2_(-0.495368F,-0.868683F)},{_math.vec2_(-20.8887F,9.99305F),_math.vec2_(-0.495368F,-0.868683F)}},
					new _math.vec2[,] {{_math.vec2_(-20.8887F,9.99305F),_math.vec2_(-0.23438F,-0.972145F)},{_math.vec2_(-21.5168F,7.38788F),_math.vec2_(0.18504F,-0.982731F)},{_math.vec2_(-21.0222F,4.76107F),_math.vec2_(0.547123F,-0.837052F)},{_math.vec2_(-19.554F,2.51492F),_math.vec2_(0.740986F,-0.67152F)},{_math.vec2_(-17.56F,0.70784F),_math.vec2_(0.83573F,-0.54914F)},{_math.vec2_(-15.3088F,-0.771395F),_math.vec2_(0.886358F,-0.463F)},{_math.vec2_(-12.9204F,-2.01899F),_math.vec2_(0.916315F,-0.400457F)},{_math.vec2_(-10.451F,-3.0982F),_math.vec2_(0.935529F,-0.353251F)},{_math.vec2_(-7.9296F,-4.05026F),_math.vec2_(0.948611F,-0.316444F)},{_math.vec2_(-5.37291F,-4.90314F),_math.vec2_(0.957916F,-0.287048F)},{_math.vec2_(-2.79107F,-5.6768F),_math.vec2_(0.964738F,-0.263212F)},{_math.vec2_(-0.190817F,-6.38624F),_math.vec2_(0.969823F,-0.24381F)},{_math.vec2_(2.42311F,-7.04337F),_math.vec2_(0.973603F,-0.228248F)},{_math.vec2_(5.04733F,-7.65858F),_math.vec2_(0.976289F,-0.216472F)},{_math.vec2_(7.67871F,-8.24204F),_math.vec2_(0.977847F,-0.209319F)},{_math.vec2_(10.3142F,-8.80619F),_math.vec2_(0.977847F,-0.209319F)},{_math.vec2_(10.3142F,-8.80619F),_math.vec2_(0.977847F,-0.209319F)}},
					new _math.vec2[,] {{_math.vec2_(10.3142F,-8.80619F),_math.vec2_(0.999209F,0.0397662F)},{_math.vec2_(11.9564F,-8.74084F),_math.vec2_(-0.248521F,0.968626F)},{_math.vec2_(11.5643F,-7.21234F),_math.vec2_(-0.633033F,0.774125F)},{_math.vec2_(10.4933F,-5.90265F),_math.vec2_(-0.697232F,0.716846F)},{_math.vec2_(9.31313F,-4.6893F),_math.vec2_(-0.727838F,0.685749F)},{_math.vec2_(8.08092F,-3.52835F),_math.vec2_(-0.747103F,0.664708F)},{_math.vec2_(6.81619F,-2.4031F),_math.vec2_(-0.761085F,0.648652F)},{_math.vec2_(5.52771F,-1.30496F),_math.vec2_(-0.77223F,0.635343F)},{_math.vec2_(4.22039F,-0.229382F),_math.vec2_(-0.781779F,0.623556F)},{_math.vec2_(2.89688F,0.826263F),_math.vec2_(-0.790492F,0.612473F)},{_math.vec2_(1.55862F,1.86315F),_math.vec2_(-0.798944F,0.601405F)},{_math.vec2_(0.20608F,2.88127F),_math.vec2_(-0.8077F,0.589594F)},{_math.vec2_(-1.16129F,3.87941F),_math.vec2_(-0.817501F,0.575927F)},{_math.vec2_(-2.54532F,4.85445F),_math.vec2_(-0.829662F,0.558266F)},{_math.vec2_(-3.94988F,5.79956F),_math.vec2_(-0.847369F,0.531005F)},{_math.vec2_(-5.38414F,6.69834F),_math.vec2_(-0.847369F,0.531005F)},{_math.vec2_(-5.38414F,6.69834F),_math.vec2_(-0.847369F,0.531005F)}},
					new _math.vec2[,] {{_math.vec2_(-5.38414F,6.69834F),_math.vec2_(-0.94003F,0.341091F)},{_math.vec2_(-6.00527F,6.92372F),_math.vec2_(-0.218518F,-0.975833F)},{_math.vec2_(-6.13438F,6.34713F),_math.vec2_(0.335875F,-0.941907F)},{_math.vec2_(-5.90943F,5.71629F),_math.vec2_(0.419691F,-0.907667F)},{_math.vec2_(-5.62819F,5.10805F),_math.vec2_(0.457065F,-0.889433F)},{_math.vec2_(-5.32183F,4.51188F),_math.vec2_(0.478957F,-0.877838F)},{_math.vec2_(-5.00081F,3.92352F),_math.vec2_(0.493434F,-0.869783F)},{_math.vec2_(-4.67008F,3.34054F),_math.vec2_(0.50364F,-0.863914F)},{_math.vec2_(-4.33252F,2.7615F),_math.vec2_(0.511054F,-0.859549F)},{_math.vec2_(-3.98997F,2.18537F),_math.vec2_(0.51645F,-0.856318F)},{_math.vec2_(-3.64382F,1.61142F),_math.vec2_(0.520234F,-0.854024F)},{_math.vec2_(-3.29513F,1.039F),_math.vec2_(0.522581F,-0.852589F)},{_math.vec2_(-2.94486F,0.467533F),_math.vec2_(0.523471F,-0.852043F)},{_math.vec2_(-2.59399F,-0.10356F),_math.vec2_(0.522634F,-0.852557F)},{_math.vec2_(-2.24369F,-0.674998F),_math.vec2_(0.519347F,-0.854564F)},{_math.vec2_(-1.89562F,-1.24774F),_math.vec2_(0.519347F,-0.854564F)},{_math.vec2_(-1.89562F,-1.24774F),_math.vec2_(0.519347F,-0.854564F)}}
				};

				float [][][] _plota = 
				{
					new float[][] { new float[]{ 0F,1F,1F }, new float[]{ 1F,1F,1F }, new float[]{ 1F,0F,0F }}
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
					float rnd_ = 0.5F + emitter.random()() * (1F - 0.5F);
					particleImpl._Max_Life = rnd_;
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					float _path_in = _math.clamp_(rnd_a, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					float _patha_in = _math.clamp_(rnd_a, 0, 1);
					_math.PathRes _patha_srch = _math.pathRes(0,(_patha_in-0F)*1F);
					_math.vec2 _patha_pos;
					_math.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
					float rnd_b = 0F + emitter.random()() * (1F - 0F);
					_math.vec2 lrp = _math.lerpv2_(_path_pos, _patha_pos, rnd_b);
					_math.vec3 conv3d_ = _math.vec3_(lrp.x, lrp.y, 0F);
					particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
					float rnd_c = 0F + emitter.random()() * (4F - 0F);
					particleImpl._Graph_shift = rnd_c;
					particleImpl._Emitter_rot_ = emitter.rotation();
					particleImpl._Angle = 0F;
					float rnd_d = 5F + emitter.random()() * (10F - 5F);
					particleImpl._Size = rnd_d;
					float expr_ = (particleImpl._lifetime + particleImpl._Graph_shift);
					float _plot_out;
					float _plot_in0=(expr_<0F?0F:(expr_>6F?(0F+((expr_-0F)%6F)):expr_));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*0.166667F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float _pathb_in = _math.clamp_(_plot_out, 0, 1);
					_math.PathRes _pathb_srch = _pathb_in<0.47202?_pathb_in<0.232473?_pathb_in<0.165747?_pathb_in<0.099272?_pathb_in<0.0463581?_math.pathRes(0,(_pathb_in-0F)*323.568F):_math.pathRes(1,(_pathb_in-0.0463581F)*283.479F):_math.pathRes(2,(_pathb_in-0.099272F)*225.649F):_pathb_in<0.202001?_math.pathRes(3,(_pathb_in-0.165747F)*413.744F):_math.pathRes(4,(_pathb_in-0.202001F)*492.253F):_pathb_in<0.379594?_pathb_in<0.335164?_pathb_in<0.277502?_math.pathRes(5,(_pathb_in-0.232473F)*333.123F):_math.pathRes(6,(_pathb_in-0.277502F)*260.133F):_math.pathRes(7,(_pathb_in-0.335164F)*337.61F):_pathb_in<0.430841?_math.pathRes(8,(_pathb_in-0.379594F)*292.705F):_math.pathRes(9,(_pathb_in-0.430841F)*364.256F):_pathb_in<0.753764?_pathb_in<0.616841?_pathb_in<0.564716?_pathb_in<0.524394?_math.pathRes(10,(_pathb_in-0.47202F)*286.404F):_math.pathRes(11,(_pathb_in-0.524394F)*372.005F):_math.pathRes(12,(_pathb_in-0.564716F)*287.769F):_pathb_in<0.687253?_math.pathRes(13,(_pathb_in-0.616841F)*213.031F):_math.pathRes(14,(_pathb_in-0.687253F)*225.528F):_pathb_in<0.929426?_pathb_in<0.848463?_math.pathRes(15,(_pathb_in-0.753764F)*158.397F):_math.pathRes(16,(_pathb_in-0.848463F)*185.27F):_pathb_in<0.980018?_math.pathRes(17,(_pathb_in-0.929426F)*296.49F):_math.pathRes(18,(_pathb_in-0.980018F)*750.661F);
					_math.vec2 _pathb_pos;
					_math.vec2 _pathb_dir;
					_math.pathLerp2(out _pathb_pos, out _pathb_dir, this._pathb[_pathb_srch.s], _pathb_srch.i);
					_math.vec3 conv3d_a = _math.vec3_(_pathb_pos.x, _pathb_pos.y, 0F);
					_math.vec3 trn3op0 = _math.applyv3quat_(conv3d_a, particleImpl._Emitter_rot_);
					_math.addv3(out trn3op0, trn3op0, _math.vec3_(0F,0F,0F));
					_math.vec3 expr_a = _math.addv3_(particleImpl._Position, trn3op0);
					particle.position_ = expr_a;
				}

				public override void initBurstParticle(Emitter emitter, Particle particle)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					float dt = 0;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime = 0F;
					float rnd_ = 0.5F + emitter.random()() * (1F - 0.5F);
					particleImpl._Max_Life = rnd_;
					float rnd_a = 0F + emitter.random()() * (1F - 0F);
					float _path_in = _math.clamp_(rnd_a, 0, 1);
					_math.PathRes _path_srch = _math.pathRes(0,(_path_in-0F)*1F);
					_math.vec2 _path_pos;
					_math.pathLerp1(out _path_pos, this._path[_path_srch.s], _path_srch.i);
					float _patha_in = _math.clamp_(rnd_a, 0, 1);
					_math.PathRes _patha_srch = _math.pathRes(0,(_patha_in-0F)*1F);
					_math.vec2 _patha_pos;
					_math.pathLerp1(out _patha_pos, this._patha[_patha_srch.s], _patha_srch.i);
					float rnd_b = 0F + emitter.random()() * (1F - 0F);
					_math.vec2 lrp = _math.lerpv2_(_path_pos, _patha_pos, rnd_b);
					_math.vec3 conv3d_ = _math.vec3_(lrp.x, lrp.y, 0F);
					particleImpl._Position = _math.addv3_(conv3d_, emitter.position());
					float rnd_c = 0F + emitter.random()() * (4F - 0F);
					particleImpl._Graph_shift = rnd_c;
					particleImpl._Emitter_rot_ = emitter.rotation();
					particleImpl._Angle = 0F;
					float rnd_d = 5F + emitter.random()() * (10F - 5F);
					particleImpl._Size = rnd_d;
					float expr_ = (particleImpl._lifetime + particleImpl._Graph_shift);
					float _plot_out;
					float _plot_in0=(expr_<0F?0F:(expr_>6F?(0F+((expr_-0F)%6F)):expr_));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*0.166667F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float _pathb_in = _math.clamp_(_plot_out, 0, 1);
					_math.PathRes _pathb_srch = _pathb_in<0.47202?_pathb_in<0.232473?_pathb_in<0.165747?_pathb_in<0.099272?_pathb_in<0.0463581?_math.pathRes(0,(_pathb_in-0F)*323.568F):_math.pathRes(1,(_pathb_in-0.0463581F)*283.479F):_math.pathRes(2,(_pathb_in-0.099272F)*225.649F):_pathb_in<0.202001?_math.pathRes(3,(_pathb_in-0.165747F)*413.744F):_math.pathRes(4,(_pathb_in-0.202001F)*492.253F):_pathb_in<0.379594?_pathb_in<0.335164?_pathb_in<0.277502?_math.pathRes(5,(_pathb_in-0.232473F)*333.123F):_math.pathRes(6,(_pathb_in-0.277502F)*260.133F):_math.pathRes(7,(_pathb_in-0.335164F)*337.61F):_pathb_in<0.430841?_math.pathRes(8,(_pathb_in-0.379594F)*292.705F):_math.pathRes(9,(_pathb_in-0.430841F)*364.256F):_pathb_in<0.753764?_pathb_in<0.616841?_pathb_in<0.564716?_pathb_in<0.524394?_math.pathRes(10,(_pathb_in-0.47202F)*286.404F):_math.pathRes(11,(_pathb_in-0.524394F)*372.005F):_math.pathRes(12,(_pathb_in-0.564716F)*287.769F):_pathb_in<0.687253?_math.pathRes(13,(_pathb_in-0.616841F)*213.031F):_math.pathRes(14,(_pathb_in-0.687253F)*225.528F):_pathb_in<0.929426?_pathb_in<0.848463?_math.pathRes(15,(_pathb_in-0.753764F)*158.397F):_math.pathRes(16,(_pathb_in-0.848463F)*185.27F):_pathb_in<0.980018?_math.pathRes(17,(_pathb_in-0.929426F)*296.49F):_math.pathRes(18,(_pathb_in-0.980018F)*750.661F);
					_math.vec2 _pathb_pos;
					_math.vec2 _pathb_dir;
					_math.pathLerp2(out _pathb_pos, out _pathb_dir, this._pathb[_pathb_srch.s], _pathb_srch.i);
					_math.vec3 conv3d_a = _math.vec3_(_pathb_pos.x, _pathb_pos.y, 0F);
					_math.vec3 trn3op0 = _math.applyv3quat_(conv3d_a, particleImpl._Emitter_rot_);
					_math.addv3(out trn3op0, trn3op0, _math.vec3_(0F,0F,0F));
					_math.vec3 expr_a = _math.addv3_(particleImpl._Position, trn3op0);
					particle.position_ = expr_a;
				}

				public override void updateParticle(Emitter emitter, Particle particle, float dt)
				{
					ParticleImpl particleImpl = (ParticleImpl)particle;
					EmitterData emitterData = (EmitterData)emitter.data();

					GeneratorPeriodic generator = (GeneratorPeriodic)emitter.generator(); 
					GeneratorImpl generatorImpl = (GeneratorImpl)generator.impl();
					particleImpl._lifetime += dt;
					float expr_ = (particleImpl._lifetime + particleImpl._Graph_shift);
					float _plot_out;
					float _plot_in0=(expr_<0F?0F:(expr_>6F?(0F+((expr_-0F)%6F)):expr_));
					_math.PathRes _plot_srch0 = _math.pathRes(0,(_plot_in0-0F)*0.166667F);
					_math.funcLerp(out _plot_out, this._plot[0][_plot_srch0.s],_plot_srch0.i);
					float _pathb_in = _math.clamp_(_plot_out, 0, 1);
					_math.PathRes _pathb_srch = _pathb_in<0.47202?_pathb_in<0.232473?_pathb_in<0.165747?_pathb_in<0.099272?_pathb_in<0.0463581?_math.pathRes(0,(_pathb_in-0F)*323.568F):_math.pathRes(1,(_pathb_in-0.0463581F)*283.479F):_math.pathRes(2,(_pathb_in-0.099272F)*225.649F):_pathb_in<0.202001?_math.pathRes(3,(_pathb_in-0.165747F)*413.744F):_math.pathRes(4,(_pathb_in-0.202001F)*492.253F):_pathb_in<0.379594?_pathb_in<0.335164?_pathb_in<0.277502?_math.pathRes(5,(_pathb_in-0.232473F)*333.123F):_math.pathRes(6,(_pathb_in-0.277502F)*260.133F):_math.pathRes(7,(_pathb_in-0.335164F)*337.61F):_pathb_in<0.430841?_math.pathRes(8,(_pathb_in-0.379594F)*292.705F):_math.pathRes(9,(_pathb_in-0.430841F)*364.256F):_pathb_in<0.753764?_pathb_in<0.616841?_pathb_in<0.564716?_pathb_in<0.524394?_math.pathRes(10,(_pathb_in-0.47202F)*286.404F):_math.pathRes(11,(_pathb_in-0.524394F)*372.005F):_math.pathRes(12,(_pathb_in-0.564716F)*287.769F):_pathb_in<0.687253?_math.pathRes(13,(_pathb_in-0.616841F)*213.031F):_math.pathRes(14,(_pathb_in-0.687253F)*225.528F):_pathb_in<0.929426?_pathb_in<0.848463?_math.pathRes(15,(_pathb_in-0.753764F)*158.397F):_math.pathRes(16,(_pathb_in-0.848463F)*185.27F):_pathb_in<0.980018?_math.pathRes(17,(_pathb_in-0.929426F)*296.49F):_math.pathRes(18,(_pathb_in-0.980018F)*750.661F);
					_math.vec2 _pathb_pos;
					_math.vec2 _pathb_dir;
					_math.pathLerp2(out _pathb_pos, out _pathb_dir, this._pathb[_pathb_srch.s], _pathb_srch.i);
					_math.vec3 conv3d_ = _math.vec3_(_pathb_pos.x, _pathb_pos.y, 0F);
					_math.vec3 trn3op0 = _math.applyv3quat_(conv3d_, particleImpl._Emitter_rot_);
					_math.addv3(out trn3op0, trn3op0, _math.vec3_(0F,0F,0F));
					_math.vec3 expr_a = _math.addv3_(particleImpl._Position, trn3op0);
					particle.position_ = expr_a;
					if (particleImpl._lifetime > particleImpl._Max_Life) 
					{
						particle.dead_ = true;
					}
					float expr_b = (particleImpl._lifetime / particleImpl._Max_Life);
					float _plota_out;
					float _plota_in0=(expr_b<0F?0F:(expr_b>1F?1F:expr_b));
					_math.PathRes _plota_srch0 = _plota_in0<0.9?_plota_in0<0.1?_math.pathRes(0,(_plota_in0-0F)*10F):_math.pathRes(1,(_plota_in0-0.1F)*1.25F):_math.pathRes(2,(_plota_in0-0.9F)*10F);
					_math.funcLerp(out _plota_out, this._plota[0][_plota_srch0.s],_plota_srch0.i);
					float expr_c = (particleImpl._Size * _plota_out);
					particleImpl.size1_ = expr_c;
					particleImpl.color_ = emitterData._Color;
				}
				public Emitter_DefaultEmitter()
				{
					addProperty("Color", PropertyType.VEC3, 
						(object emitterData) => { return ((EmitterData)emitterData)._Color; }, 
						(object emitterData, object value) => { _math.copyv3(out ((EmitterData)emitterData)._Color, (_math.vec3)value); });
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
				textures_ = new string[] { "smoke01_white_blurred.png" };
				materials_ = new RenderMaterial[] { RenderMaterial.Add };
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
