Shader "Unlit/TransparentArray Fade"
{
    Properties
    {
        _MainTex ("Texture", 2DArray) = "black" {}
		_F ("flame Index", Int) = 0
		_T ("fader", Range(0,1)) = 1
    }
    SubShader
    {
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

			UNITY_DECLARE_TEX2DARRAY(_MainTex);
            float4 _MainTex_ST;
			float _T;
			int _F;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // sample the texture
				half4 col = UNITY_SAMPLE_TEX2DARRAY(_MainTex, float3(i.uv, _F));
				col.a *= _T;
                return col;
            }
            ENDCG
        }
    }
}
