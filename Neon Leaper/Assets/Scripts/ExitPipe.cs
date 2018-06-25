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
                    WinPopUp.current.Open();
                }
                else
                {
                    //LevelPopUp.current.transform.width=350;
                    LevelPopUp.current.Open("Not all crystals!");
                }
            }
        }
    }
}
