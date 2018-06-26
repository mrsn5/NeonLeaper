using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("JPixelArt/JPixelArtSimple")]
[ExecuteInEditMode]
public class JPixelArtSimple : MonoBehaviour {
	
	protected Material mat;
	public int referenceScreenWidth=720;
	public float pixelSize=8f;
	public bool absolutePixelSize=false;
	public bool smooth=false;
	private string shaderName="Hidden/JPixelArtSimple";
	protected float screenSizeFactor;
	protected float finalPixelSize;
	public bool usePalette=true;
	protected RenderTexture s;
	protected float aspectRatio;
	protected int renderTexture_h;
	protected int renderTexture_w;
	protected int screen_w;
	protected int screen_h;

	virtual public Material GetMaterial()
	{
		return new Material(Shader.Find(shaderName));

	}
	public virtual void PreUpscale()
	{}
	public virtual void OnValidate()
	{
		if (pixelSize<1f)
			pixelSize=1f;
		pixelSize=Mathf.Abs(pixelSize);
		//Awake();
	}
	public virtual void Awake()
	{
		mat= GetMaterial();
	}
	void OnRenderImage(RenderTexture source,RenderTexture destination)
	{
		screen_w=Screen.width;
		screen_h=Screen.height;
		if (!smooth)
			source.filterMode=FilterMode.Point;
		aspectRatio=Camera.main.aspect;
		if (!absolutePixelSize)
		{
			screenSizeFactor=(float)referenceScreenWidth/(float)screen_w;
			finalPixelSize=pixelSize/screenSizeFactor;
			renderTexture_w=Mathf.RoundToInt(screen_w/finalPixelSize);
			renderTexture_h=Mathf.RoundToInt(screen_w/finalPixelSize*aspectRatio);
		}
		else
		{
			renderTexture_h=Mathf.RoundToInt (Screen.height/pixelSize);
			renderTexture_w=Mathf.RoundToInt(Screen.width/pixelSize);
		}
		s= RenderTexture.GetTemporary(renderTexture_h,renderTexture_w);
		s.filterMode=FilterMode.Point;
		s.anisoLevel=0;
		SetShaderParameters();
		if (usePalette)
			Graphics.Blit(source,s,mat);
		else
			Graphics.Blit(source,s);
		PreUpscale();
		Graphics.Blit(s,destination);
		RenderTexture.ReleaseTemporary(s);
	}
	public virtual void SetShaderParameters()
	{}
}
