Shader "Hidden/SuperMarioOverJPixelArt"
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

			float4  frag(v2f_img i): COLOR
			{
				float4 colors[7]={float4(214,39,1,1),float4(204,75,9,255)/255,float4(255,186,170,255)/255,float4(93,148,251,255)/255,float4(18,124,34,255)/255,float4(219,253,255,255)/255,float4(248,154,56,255)/255};
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
