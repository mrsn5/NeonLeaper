using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

	public int id;
	public Button but;
	
	private string levelname;

	void Awake ()
	{
		//PlayerPrefs.DeleteAll();
		levelname = "Level" +" "+ id;
		if (id > 1)
		{
			string prevLevel = "Level" + " " + (id - 1);
			LevelStats stats = LevelStats.Deserialize(prevLevel);
			if (stats == null || !stats.levelPassed)
			{
				but.interactable = false;
			}
			else
			{
				but.interactable = true;
			}
		}
	}

	public void Click()
	{
		Debug.Log(levelname);
		SceneManager.LoadScene(levelname);
	}
}
