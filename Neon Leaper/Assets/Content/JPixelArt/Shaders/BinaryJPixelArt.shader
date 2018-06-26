Shader "Hidden/BinaryJPixelArt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color1 ("Color 1", Color)= (1,1,1,1)
		_Color2 ("Color 2", Color)= (0,0,0,1)
		_Offset ("Threshold offset",Float)=0
		_Factor ("Average factor", Float)=1
		_MeasureOffset("Measure offset",Float)=0.3
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
			uniform float _MeasureOffset;

			float4  frag(v2f_img i): COLOR
			{
				float4 c= tex2D(_MainTex,i.uv);
				float4 av= (tex2D(_MainTex,float2(0+_MeasureOffset,0+_MeasureOffset))+tex2D(_MainTex,float2(0+_MeasureOffset,1-_MeasureOffset))+tex2D(_MainTex,float2(1-_MeasureOffset,0+_MeasureOffset))+tex2D(_MainTex,float2(1-_MeasureOffset,1-_MeasureOffset))+tex2D(_MainTex,float2(0.5,0.5)))/5;
				float currentGray=(0.29*c.r + 0.58*c.g + 0.11*c.b) / 3 *_Factor ;
				float imagAvGray=((0.29*av.r + 0.58*av.g + 0.11*av.b)/3)+_Offset;
				if (currentGray > imagAvGray)
				{
					c=_Color1;
				}
				else
				{
					c=_Color2;
				}
				return c;

			}
			ENDCG
		}
	}
}
