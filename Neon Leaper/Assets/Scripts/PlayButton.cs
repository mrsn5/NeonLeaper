
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    
	public void Play()
    {
        SceneManager.LoadScene("LevelPicker");
    }
    
    public void Next()
    {
        string str = SceneManager.GetActiveScene().name;
        string[] list = str.Split(null);

        int id = Int32.Parse(list[1]);
        if (id < 2)
        {
            SceneManager.LoadScene(list[0] + " " + (id+1)); 
        }
    }
    
}
