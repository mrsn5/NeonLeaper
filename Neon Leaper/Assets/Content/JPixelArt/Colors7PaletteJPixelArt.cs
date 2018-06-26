using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/Colors7PaletteJPixelArt")]
[ExecuteInEditMode]
public class Colors7PaletteJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/Colors7PaletteJPixelArt";
	public Color Color1=Color.white;
	public Color Color2=Color.blue;
	public Color Color3=Color.cyan;
	public Color Color4=Color.yellow;
	public Color Color5=Color.green;
	public Color Color6=Color.magenta;
	public Color Color7=Color.red;

	public override void SetShaderParameters ()
	{
		mat.SetColor("_Color1",Color1);
		mat.SetColor("_Color2",Color2);
		mat.SetColor("_Color3",Color3);
		mat.SetColor("_Color4",Color4);
		mat.SetColor("_Color5",Color5);
		mat.SetColor("_Color6",Color6);
		mat.SetColor("_Color7",Color7);
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
