Shader "Hidden/Colors5PaletteJPixelArt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color1 ("Color 1",Color)=(1,1,1,1)
		_Color2 ("Color 2",Color)=(1,1,1,1)
		_Color3 ("Color 3",Color)=(1,1,1,1)
		_Color4 ("Color 4",Color)=(1,1,1,1)
		_Color5 ("Color 5",Color)=(1,1,1,1)
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"
			uniform sampler2D _MainTex;
			uniform float4 _Color1;
			uniform float4 _Color2;
			uniform float4 _Color3;
			uniform float4 _Color4;
			uniform float4 _Color5;


			float4  frag(v2f_img i): COLOR
			{
				float4 colors[5]={_Color1,_Color2,_Color3,_Color4,_Color5};
				float4 c= tex2D(_MainTex,i.uv);
				if ((c.r+c.g+c.b)/3<0.15)
					return float4(0,0,0,1);
				int currentMinIndex=0;
				float minDistance=10000;
				int j;
				float d;
				for (j=0;j<5;j++)
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
