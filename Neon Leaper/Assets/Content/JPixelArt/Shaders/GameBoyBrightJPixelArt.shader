Shader "Hidden/GameBoyBrightJPixelArt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
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

			float4  frag(v2f_img i): COLOR
			{
				float4 c= tex2D(_MainTex,i.uv);
				float currentGray=(0.29*c.r + 0.58*c.g + 0.11*c.b) / 3 *_Factor + _Offset;
				if (currentGray<=0.25)
				{
					c=float4 (15,56,15,255)/255;
				}
				else if (0.5>=currentGray>0.25)
				{
					c=float4 (41,90,41,255)/255;
				}
				else if (0.75>=currentGray>0.5)
				{
					c=float4 (139,172,15,255)/255;
				}
				else if (currentGray>0.75)
				{
					c=float4 (155,188,15,255)/255;
				}
				else
				{
					c=c;
				}
				return c;
			}
			ENDCG
		}
	}
}
