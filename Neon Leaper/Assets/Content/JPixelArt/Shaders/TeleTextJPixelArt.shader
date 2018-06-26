Shader "Hidden/TeleTextJPixelArt"
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
				float4 colors[7]={float4(255,253,51,255)/255, float4(0,252,254,255)/255,float4(0,249,44,255)/255,float4(255,63,252,255)/255,float4(255,48,22,255)/255,float4(0,39,251,255)/255, float4(0,0,0,1)};
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
