using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Collectable
{
    protected override void OnPlayerHit(Player player)
    {
        //LevelController.current.addCoins(1);
        this.CollectedHide();
    }
}
