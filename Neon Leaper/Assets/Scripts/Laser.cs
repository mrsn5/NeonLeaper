using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Activable {

    [SerializeField]
    private bool isActive = false;
    private Animator anim;

	void Awake () {
        anim = GetComponent<Animator>();
	}

    protected override IEnumerator SwitchCoroutine()
    {
        if (!isActive) anim.SetTrigger("turnOn"); 
        else anim.SetTrigger("turnOff");
        yield return new WaitForSeconds(0.583f);
        isActive = !isActive;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null) player.Kill();
        }
    }

}
