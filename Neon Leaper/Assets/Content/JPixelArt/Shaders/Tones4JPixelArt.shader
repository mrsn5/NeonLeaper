Shader "Hidden/Tones4JPixelArt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color1 ("Color 1", Color)= (1,1,1,1)
		_Color2 ("Color 2", Color)= (0,0,0,1)
		_Color3 ("Color 3", Color)= (0,0,0,1)
		_Color4 ("Color 4", Color)= (0,0,0,1)
		_Offset ("Threshold offset",Float)=0
		_Factor ("Average factor", Float)=1
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			uniform sampler2D _MainTex;
			uniform float _Offset;
			uniform float _Factor;
			uniform float4 _Color1;
			uniform float4 _Color2;
			uniform float4 _Color3;
			uniform float4 _Color4;

			float4  frag(v2f_img i): COLOR
			{
				float4 c= tex2D(_MainTex,i.uv);
				float currentGray=((0.29*c.r + 0.58*c.g + 0.11*c.b) / 3) *_Factor+_Offset ;
				if (0<currentGray<=0.25)
					c=_Color1;
				else if (0.5>=currentGray>0.25)
					c=_Color2;
				else if(0.75>=currentGray>0.5)
					c=_Color3;
				else if( currentGray>0.75)
					c=_Color4;
				return c;

			}
			ENDCG
		}
	}
}
