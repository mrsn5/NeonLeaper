using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/BinaryClosestJPixelArt")]
[ExecuteInEditMode]
public class BinaryClosestJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/BinaryClosestJPixelArt";
	public Color color1= Color.white;
	public Color color2= Color.black;
	public float color1Weight= 1f;
	public float color2Weight=1f;

	public override void SetShaderParameters ()
	{
		mat.SetFloat("_Color1Weight",color1Weight);
		mat.SetFloat("_Color2Weight",color2Weight);
		mat.SetColor("_Color1",color1);
		mat.SetColor("_Color2",color2);
	}
	public override Material GetMaterial ()
	{
		return new Material(Shader.Find(thisShaderName));
	}
	public override void Awake ()
	{
		mat=this.GetMaterial();
	}
	public override void OnValidate ()
	{
		base.OnValidate ();
		if (color1Weight==0f)
			color1Weight=0.01f;
		if (color2Weight==0f)
			color2Weight=0.01f;
	}
}
