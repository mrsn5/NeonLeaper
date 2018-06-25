using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultPlatform : MonoBehaviour {

	private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.StrongJump();
            gameObject.GetComponentInParent<Catapult>().PlayAnim();
        }
    }

}
