using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/Colors4PaletteJPixelArt")]
[ExecuteInEditMode]
public class Colors4PaletteJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/Colors4PaletteJPixelArt";
	public Color Color1=Color.red;
	public Color Color2=Color.blue;
	public Color Color3=Color.cyan;
	public Color Color4=Color.yellow;


	public override void SetShaderParameters ()
	{
		mat.SetColor("_Color1",Color1);
		mat.SetColor("_Color2",Color2);
		mat.SetColor("_Color3",Color3);
		mat.SetColor("_Color4",Color4);
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
