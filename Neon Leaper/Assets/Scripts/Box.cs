using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField]
    private List<int> states;

    private Vector3[] positions = new Vector3[3];
    private bool isTouched = false;
    public Transform groundCheck;
    private Transform heroParent = null;
    public LayerMask whatIsGround;
    private float groundRadius = 0.15f;

    public void Start()
    {
        LevelController.current.AddBox(this);
        foreach (int i in states)
            positions[i] = transform.position;
        heroParent = transform.parent;
    }

    public void Update () {
        if (isTouched)
            for (int state = LevelController.current.GetState(); state < 3; state++)
                positions[state] = transform.position;
	}

    void FixedUpdate()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (groundCollider != null)
        {
            MovingPlatform movingPlatform = groundCollider.GetComponent<MovingPlatform>();
            if (movingPlatform != null) SetNewParent(this.transform, movingPlatform.transform);
            else SetNewParent(this.transform, heroParent);
        }
        else
        {
            SetNewParent(this.transform, heroParent);
        }
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

    static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            Vector3 pos = obj.transform.position;
            obj.transform.parent = new_parent;
            obj.transform.position = pos;
        }
    }
}
