using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenu : MonoBehaviour {

    float period = 0;
    Vector3 position;

    private void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update () {
        period += Time.deltaTime;
        if (period > 2 * Mathf.PI) period -= 2*Mathf.PI;
        transform.position = new Vector3(position.x + 2 * Mathf.Sin(period), position.y, position.z);
		
	}
}
