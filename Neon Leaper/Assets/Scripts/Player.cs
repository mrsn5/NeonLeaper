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
    bool isActive = true;

    private Transform heroParent = null;
    private float energy = 100;

    
    // Use this for initialization
    void Awake ()
    {
//      startTime = Time.time;
        anim = GetComponent<Animator> ();
        lastPlayer = this;
        LevelController.current.setStartPosition(transform.position);
    }

    private void Start()
    {
        Energy.current.setValue(energy);
        heroParent = transform.parent;
    }

    void FixedUpdate ()
    {
        if (!isDead)
        {
            Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            grounded = groundCollider;
            anim.SetBool("ground", grounded);

            if (groundCollider != null)
            {
                MovingPlatform movingPlatform = groundCollider.GetComponent<MovingPlatform>();
                if (movingPlatform != null) SetNewParent(this.transform, movingPlatform.transform);
                else SetNewParent(this.transform, heroParent);
            } else {
                SetNewParent(this.transform, heroParent);
            }
        }
    }

    void Update()
    {
        if (!isDead && isActive)
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

    public void StrongJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, 1.5f * jumpForce);
    }

    private IEnumerator KillCoroutine()
    {
        grounded = true;
        anim.SetBool("ground", grounded);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        isDead = true;
        anim.SetTrigger("isDead");
        decreaseEnergy(10);
        yield return new WaitForSeconds(0.8f);
        LevelController.current.Respawn(this);
        isDead = false;
    }

    public void Kill()
    {
        if (!isDead) StartCoroutine(KillCoroutine());
    }

    public float getEnergy()
    {
        return energy;
    }
    
    public void addEnergy(float val)
    {
        energy += val;
        Energy.current.setValueSlowly(energy);
    }
    
    public void decreaseEnergy(float val)
    {
        energy -= val;
        Energy.current.setValueSlowly(energy);
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

    public void vanish()
    {
        setInactive();
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        sr.enabled=false;
    }
    
    public void setActive()
    {
        GetComponent<Rigidbody2D>().simulated = true; 
        isActive = true;
    }
    public void setInactive()
    {
        GetComponent<Rigidbody2D>().simulated = false; 
        isActive = false;
    }

}
