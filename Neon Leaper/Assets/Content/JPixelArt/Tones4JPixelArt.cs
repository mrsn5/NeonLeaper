using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/Tones4JPixelArt")]
[ExecuteInEditMode]
public class Tones4JPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/Tones4JPixelArt";
	public Color color1= Color.red;
	public Color color2= Color.blue;
	public Color color3=Color.green;
	public Color color4=Color.yellow;
	public float offset=0f;
	public float factor =1f;

	public override void SetShaderParameters ()
	{
		mat.SetFloat("_Offset",offset);
		mat.SetFloat("_Factor",factor);
		mat.SetColor("_Color1",color1);
		mat.SetColor("_Color2",color2);
		mat.SetColor("_Color3",color3);
		mat.SetColor("_Color4",color4);
	}
	public override Material GetMaterial ()
	{
		return new Material(Shader.Find(thisShaderName));
	}
	public override void Awake ()
	{
		mat=this.GetMaterial();
	}

}
