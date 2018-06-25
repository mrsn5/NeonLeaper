using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crystal : Collectable
{
    public new void Start()
    {
        base.Start();
        LevelController.current.incrementDefaultCrystals();
    }

    protected override void OnPlayerHit(Player player)
    {
        LevelController.current.addCrystal();
        this.CollectedHide();
    }
}
