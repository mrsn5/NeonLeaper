using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Collectable
{
    protected override void OnPlayerHit(Player player)
    {
        Player.lastPlayer.addEnergy(30);
        this.CollectedHide();
    }
}
