using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public static Player lastPlayer = null;

    private float HSpeed = 10f;
    //private float maxVertHSpeed = 20f;
    private bool facingRight = true;
    private float moveXInput;

    //Used for flipping Character Direction
    public static Vector3 theScale;

    //Jumping Stuff
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool grounded = false;
    private float groundRadius = 0.15f;
    [SerializeField]
    private float jumpForce = 26f;

    private Animator anim;

    bool isDead = false;

    // Use this for initialization
    void Awake ()
    {
//      startTime = Time.time;
        anim = GetComponent<Animator> ();
        lastPlayer = this;
        LevelController.current.setStartPosition(transform.position);
    }

    void FixedUpdate ()
    {
        if (!isDead)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("ground", grounded);
        }
    }

    void Update()
    {
        if (!isDead)
        {
            moveXInput = Input.GetAxis("Horizontal");

            if ((grounded) && Input.GetButtonDown("Jump"))
            {
                anim.SetBool("ground", false);
                Jump();
            }


            anim.SetFloat("HSpeed", Mathf.Abs(moveXInput));
            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


            GetComponent<Rigidbody2D>().velocity = new Vector2((moveXInput * HSpeed), GetComponent<Rigidbody2D>().velocity.y);

            //if (Input.GetButtonDown("Fire1") && (grounded)) { anim.SetTrigger("Punch"); }

            if (Input.GetButton("Fire2"))
            {
                anim.SetBool("Sprint", true);
                HSpeed = 14f;
            }
            else
            {
                anim.SetBool("Sprint", false);
                HSpeed = 10f;
            }

            //Flipping direction character is facing based on players Input
            if (moveXInput > 0 && !facingRight)
                Flip();
            else if (moveXInput < 0 && facingRight)
                Flip();
        }
    }
    ////Flipping direction of character
    void Flip()
    {
        facingRight = !facingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, jumpForce);
    }

    private IEnumerator KillCoroutine()
    {
        isDead = true;
        anim.SetTrigger("isDead");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        LevelController.current.Respawn(null);

    }

    public void Kill()
    {
        StartCoroutine(KillCoroutine());
    }

}
