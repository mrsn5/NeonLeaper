using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPopUp : MonoBehaviour {

	static public LevelPopUp current = null;

	public Text level;
    
	void Awake()
	{
		current = this;
		level.text = SceneManager.GetActiveScene().name;
	}
	
	public void Open(string text)
    {
        level.text=text;
        gameObject.SetActive(true);
        StartCoroutine(vanishCoroutine(1f));
    }
    
	void Start()
	{
		gameObject.SetActive(true);
		StartCoroutine(vanishCoroutine(2f));
	}
	
	
	private IEnumerator vanishCoroutine(float sec)
	{
		yield return new WaitForSeconds(sec);
		gameObject.SetActive(false);
	}
}
