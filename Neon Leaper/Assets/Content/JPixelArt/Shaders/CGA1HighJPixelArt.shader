Shader "Hidden/CGA1HighJPixelArt"
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
				float4 colors[4]={float4(0,0,0,1),float4(85,255,255,255)/255,float4(255,85,255,255)/255,float4(255,255,255,255)/255};
				float4 c= tex2D(_MainTex,i.uv);
				int currentMinIndex=0;
				float minDistance=10000;
				int j;
				float d;
				for (j=0;j<4;j++)
				{
					d=distance(c,colors[j])*_Factor+_Offset;
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
