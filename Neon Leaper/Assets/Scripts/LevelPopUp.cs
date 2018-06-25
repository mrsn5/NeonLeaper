using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPopUp : MonoBehaviour {

	static public LevelPopUp current = null;

	public Text level;
	
	// Use this for initialization
	void Awake()
	{
		current = this;
		level.text = SceneManager.GetActiveScene().name;
	}
	
	
	void Start()
	{
		gameObject.SetActive(true);
		StartCoroutine(vanishCoroutine());
	}
	
	
	private IEnumerator vanishCoroutine()
	{
		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
	}
}
