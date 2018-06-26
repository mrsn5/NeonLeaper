using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/AppleIIDarkJPixelArt")]
[ExecuteInEditMode]
public class AppleIIDarkJPixelArt : JPixelArtSimple{

	private string thisShaderName="Hidden/AppleIIDarkJPixelArt";
	//public float offset=0f;
	//public float factor =1f;
	//public float measurOffset=0.3f;

	public override void SetShaderParameters ()
	{
		//mat.SetFloat("_Offset",offset);
		//mat.SetFloat("_Factor",factor);
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
