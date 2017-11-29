Shader "Neutrino/Multiply"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		//_Color ("Color", Color) = (0.5, 0.5, 0.5, 1)
	}
	SubShader
	{
		
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
		//LOD 100

		Pass
		{
			Blend SrcAlpha SrcColor
			// Dont write to the depth buffer
			ZWrite off
			// Don't write pixels we have already written.
			ZTest Less
			//To disable backface culling
			Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				//UNITY_FOG_COORDS(1)
				fixed4 color : COLOR;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.color = v.color;
				//UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed3 rgb = col.rgb * i.color.rgb;
				float a = col.a * i.color.a;

				fixed4 res = fixed4(lerp(fixed3(1,1,1), rgb, a), 1);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
					//vec3 rgb = color.rgb * texel.rgb;
					//float a = color.a * texel.a;
					//gl_FragColor = vec4(mix(vec3(1, 1, 1), rgb, a), 1);
				return res;
			}
			ENDCG
		}
	}
}
