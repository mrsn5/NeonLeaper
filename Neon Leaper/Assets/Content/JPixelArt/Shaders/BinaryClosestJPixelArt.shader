Shader "Hidden/BinaryClosestJPixelArt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color1 ("Color 1", Color)= (1,1,1,1)
		_Color2 ("Color 2", Color)= (0,0,0,1)
		_Color1Weight ("Color1 Wight",Float)=1
		_Color2Weight ("Color2 Weight", Float)=1
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			uniform sampler2D _MainTex;
			uniform float _Color1Weight;
			uniform float _Color2Weight;
			uniform float4 _Color1;
			uniform float4 _Color2;

			float4  frag(v2f_img i): COLOR
			{
				float4 c= tex2D(_MainTex,i.uv);
				float dist1= abs(c-_Color1)/_Color1Weight;
				float dist2= abs(c-_Color2)/_Color2Weight;
				if ( dist1<dist2)
				{
					return _Color1; 
				}
				else
				{
					return _Color2;
				}

			}
			ENDCG
		}
	}
}
