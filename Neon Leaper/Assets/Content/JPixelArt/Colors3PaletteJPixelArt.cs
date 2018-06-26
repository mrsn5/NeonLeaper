using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/Colors3PaletteJPixelArt")]
[ExecuteInEditMode]
public class Colors3PaletteJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/Colors3PaletteJPixelArt";
	public Color Color1=Color.red;
	public Color Color2=Color.blue;
	public Color Color3=Color.green;


	public override void SetShaderParameters ()
	{
		mat.SetColor("_Color1",Color1);
		mat.SetColor("_Color2",Color2);
		mat.SetColor("_Color3",Color3);
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
