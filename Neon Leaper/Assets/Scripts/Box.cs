using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField]
    private List<int> states;

    private Vector3[] positions = new Vector3[3];
    private bool isTouched = false;

    public void Start()
    {
        LevelController.current.AddBox(this);
        foreach (int i in states)
            positions[i] = transform.position;
    }

    public void Update () {
        if (isTouched)
            for (int state = LevelController.current.GetState(); state < 3; state++)
                positions[state] = transform.position;
	}

    public bool HasState(int state)
    {
        if (states.Contains(state)) return true;
        return false;
    }

    public void SetPosition(int state)
    {
        isTouched = false;
        transform.position = positions[state];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null) isTouched = true;

    }
}
