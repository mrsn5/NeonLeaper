using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPopUp : MonoBehaviour {

	static public SettingsPopUp current = null;

	private void Awake()
	{
		current = this;
		gameObject.SetActive(false);
	}
    
	public void Open()
	{
		Energy.current.slider.enabled = false;
		Player.lastPlayer.setInactive();
		gameObject.SetActive(true); 
	}

	public void Menu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	
	public void Repeat()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void Close()
	{
		Energy.current.slider.enabled = true;
		Player.lastPlayer.setActive();
		gameObject.SetActive(false); 
	}
}
