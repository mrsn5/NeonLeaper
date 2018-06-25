using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    
    [SerializeField]
    Activable activable;
    [SerializeField]
    bool isAvailable = false;
    bool isOn = false;
    bool inProcess = false;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isAvailable && Input.GetKeyDown(KeyCode.E) && !inProcess)
        {
            inProcess = true;
            activable.Switch();
            isOn = !isOn;
            anim.SetBool("isOn", isOn);
            StartCoroutine(SwitchCoroutine());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        Player player = collision.GetComponent<Player>();
        if (player != null) isAvailable = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null) isAvailable = false;
    }


    private IEnumerator SwitchCoroutine()
    {
        yield return new WaitForSeconds(0.583f);
        inProcess = false;
    }
}
