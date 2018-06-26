Shader "Hidden/JPixelArtSimple"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			uniform sampler2D _MainTex;
			uniform float _scaleFactor;

			float4  frag(v2f_img i): COLOR
			{
				float4 c= tex2D(_MainTex,i.uv); //i -> pantalla uvmapped
				return c;
			}
			ENDCG
		}
	}
}
