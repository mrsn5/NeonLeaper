using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/BinaryJPixelArt")]
[ExecuteInEditMode]
public class BinaryJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/BinaryJPixelArt";
	public Color color1= Color.white;
	public Color color2= Color.black;
	public float offset=0f;
	public float factor =1f;
	public float measurOffset=0.3f;

	public override void SetShaderParameters ()
	{
		mat.SetFloat("_Offset",offset);
		mat.SetFloat("_Factor",factor);
		mat.SetColor("_Color1",color1);
		mat.SetColor("_Color2",color2);
		mat.SetFloat("_MeasureOffset",measurOffset);
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
		if (measurOffset>0.5f)
			measurOffset=0.5f;
		else if (measurOffset<0f)
			measurOffset=0f;
	} 
}
