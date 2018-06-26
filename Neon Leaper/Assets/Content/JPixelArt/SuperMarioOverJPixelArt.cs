using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/SuperMarioOverJPixelArt")]
[ExecuteInEditMode]
public class SuperMarioOverJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/SuperMarioOverJPixelArt";

	//public float measurOffset=0.3f;

	public override void SetShaderParameters ()
	{
		//mat.SetFloat("_MeasureOffset",measurOffset);
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
