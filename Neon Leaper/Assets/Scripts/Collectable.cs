using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    Vector3 startPosition;
    float time = 0;

    protected virtual void OnPlayerHit(Player player) { }

    protected void Start()
    {
        startPosition = transform.position;
    }

    protected void Update()
    {
        time += Time.deltaTime;
        if (time >= 2 * Mathf.PI) time -= 2 * Mathf.PI;
        transform.position = startPosition + new Vector3(0, Mathf.Sin(2*time) / 4 , 0); 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.isActiveAndEnabled)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                this.OnPlayerHit(player);
            }
        }
    }

    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }
}
