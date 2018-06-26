Shader "Hidden/AppleIIDarkJPixelArt"
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
				float4 colors[7]={float4(133,59,81,255)/255,float4(80,71,137,255)/255,float4(234,93,240,255)/255,float4(0,104,82,255)/255,float4(146,146,146,255)/255, float4(0,168,241,255)/255,float4(114,159,207,255)/255};
				float4 c= tex2D(_MainTex,i.uv);
				if ((c.r+c.g+c.b)/3<0.15)
					return float4(0,0,0,1);
				
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
