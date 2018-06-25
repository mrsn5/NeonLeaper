using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{

    public void Switch()
    {
        StartCoroutine(SwitchCoroutine());
    }

    protected virtual IEnumerator SwitchCoroutine() { return null; }
}
