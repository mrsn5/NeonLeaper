using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField]
    private List<int> states;

    // TODO
    public Vector3[] positions = new Vector3[3];

    private void Start()
    {
        LevelController.current.AddBox(this);
        foreach (int i in states)
            positions[i] = transform.position;
    }

    private void Update () {
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
        transform.position = positions[state];
    }
}
