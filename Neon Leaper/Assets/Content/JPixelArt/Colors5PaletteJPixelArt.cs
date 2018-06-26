using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/Colors5PaletteJPixelArt")]
[ExecuteInEditMode]
public class Colors5PaletteJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/Colors5PaletteJPixelArt";
	public Color Color1=Color.red;
	public Color Color2=Color.blue;
	public Color Color3=Color.cyan;
	public Color Color4=Color.yellow;
	public Color Color5=Color.green;

	public override void SetShaderParameters ()
	{
		mat.SetColor("_Color1",Color1);
		mat.SetColor("_Color2",Color2);
		mat.SetColor("_Color3",Color3);
		mat.SetColor("_Color4",Color4);
		mat.SetColor("_Color5",Color5);
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
