using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour {
    
	static public WinPopUp current = null;

	private void Awake()
	{
		current = this;
		gameObject.SetActive(false);
	}
    
	public void Play()
	{
		//SceneManager.LoadScene("NextLevel");
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


}
