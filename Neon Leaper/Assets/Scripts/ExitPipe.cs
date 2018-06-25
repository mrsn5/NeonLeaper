using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPipe : MonoBehaviour {

		void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.isActiveAndEnabled)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                if(LevelController.current.allCrystalsCollected())
                {
                    player.vanish();
                    LevelController.current.setLevelPassed();
                    LevelController.current.Save();
                
                    WinPopUp.current.Open();
                }
                else
                {
                    LevelPopUp.current.Open("Not all crystals!");
                }
            }
        }
    }
}
