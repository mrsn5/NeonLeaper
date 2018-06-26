Shader "Hidden/AppleIILightJPixelArt"
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
				float4 colors[7]={float4(81,92,15,255)/255,float4(235,127,35,255)/255,float4(146,146,146,255)/255,float4(246,185,202,255)/255,float4(0,202,41,255)/255, float4(203,211,155,255)/255,float4(154,220,203,255)/255};
				float4 c= tex2D(_MainTex,i.uv);
				if ((c.r+c.g+c.b)/3>0.9)
					return float4(1,1,1,1);
				
				int currentMinIndex=0;
				float minDistance=10000;
				int j;
				float d;
				for (j=0;j<7;j++)
				{
					d=distance(c,colors[j]);
					if (d<minDistance)
					{
						currentMinIndex=j;
						minDistance=d;
					}
					else{}
				}
				return colors[currentMinIndex]; 
			}	
			ENDCG
		}
	}
}
