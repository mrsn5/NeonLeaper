using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : Box {

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        anim.SetBool("isActive", true);
        StartCoroutine(PlayCoroutine());
    }

    private IEnumerator PlayCoroutine() 
    {
        yield return new WaitForSeconds(0.750f);
        anim.SetBool("isActive", false);
    }
}
