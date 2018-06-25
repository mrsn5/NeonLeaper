using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Energy : MonoBehaviour {
	
    public static Energy current=null;
    public Slider slider;

	private float valueToBecome = 100;

    [SerializeField]
    Image fillArea;
    Color fillColor;
    float period = 0;

    void Awake() {
        current = this;
        fillColor = fillArea.color;
    }
    
	void Update () {
		slider.value=Mathf.MoveTowards(slider.value, valueToBecome, 0.5f);

        period += Time.deltaTime;
        if (period > 2 * Mathf.PI) period -= Mathf.PI;
        fillArea.color = new Color(fillColor.r, fillColor.g, 0.9f + Mathf.Sin(period) / 10 );
	}

	public void setValue(float val)
	{
		slider.value = val;
		valueToBecome = val;
	}
	
	public void setValueSlowly(float value)
	{
		valueToBecome = value;
	}

	public float energyLevel()
	{
		return slider.value;
	}
	
}
