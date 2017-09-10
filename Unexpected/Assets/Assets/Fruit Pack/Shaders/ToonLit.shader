Shader "Toon/Lit"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Treshold ("Cel treshold", Range(1., 20.)) = 5.
		_Ambient ("Ambient intensity", Range(0., 1)) = 0.1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "LightMode"="ForwardBase" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fwdbase

			#include "UnityCG.cginc"
			#include "AutoLight.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
				float4 color : COLOR;
				LIGHTING_COORDS(4, 5)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert (appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.worldNormal = mul(v.normal.xyz, (float3x3) unity_WorldToObject);
				o.color = v.color;
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}

			float _Treshold;
			fixed4 _LightColor0;
			half _Ambient;

			float LightToonShading(float3 normal, float3 lightDir)
			{
				float NdotL = max(0.0, dot(normalize(normal), normalize(lightDir)));
				return floor(NdotL * _Treshold) / (_Treshold - 0.5);
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb *= saturate(LightToonShading(i.worldNormal, _WorldSpaceLightPos0.xyz) + _Ambient) * _LightColor0.rgb * 1.25;
				fixed atten = LIGHT_ATTENUATION(i);
				return col * atten;
			}
			ENDCG
		}
	}

	Fallback "VertexLit"
}