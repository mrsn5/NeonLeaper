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

    void Awake() {
        current = this;
    }
    
	void Update () {
		slider.value=Mathf.MoveTowards(slider.value, valueToBecome, 0.5f);    
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
