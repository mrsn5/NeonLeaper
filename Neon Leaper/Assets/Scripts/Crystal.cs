using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crystal : Collectable
{
	protected override void OnPlayerHit(Player player)
	{
		LevelController.current.addCrystal();
		this.CollectedHide();
	}
}
