﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null) { 
            player.decreaseEnergy(10);
            LevelController.current.Respawn(player);
        }
    }
     
}
