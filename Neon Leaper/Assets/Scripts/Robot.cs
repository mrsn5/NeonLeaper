using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public enum Mode { GoToA, GoToB, Attack, Dead }

    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float runSpeed = 2f;

    bool transitStarted = false;

    private Mode mode = Mode.GoToB;
    private Mode prevMode = Mode.GoToB;

    protected SpriteRenderer sr = null;
    protected Animator animator = null;

    public void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;

        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (mode != Mode.Dead)
        {
            mode = (playerHere()) ? Mode.Attack : prevMode;

            // Moving
            animator.SetBool("isWalking", true);
            if (mode == Mode.Attack)
            {
                if (!transitStarted) StartCoroutine(TransitCoroutine());
                transitStarted = true;
                Attack();
            }
            else
            {
                transitStarted = false;
                animator.SetBool("isTransit", false);
                Move();
            }
        }
    }

    private void Move()
    {
        animator.SetBool("isAttacking", false);
        if (isArrived(transform.position, (mode == Mode.GoToA) ? pointA : pointB))
        {
            mode = (mode == Mode.GoToA) ? Mode.GoToB : Mode.GoToA;
            prevMode = mode;
        }
        float value = this.getDirection((mode == Mode.GoToA) ? pointA : pointB);
        sr.flipX = (value > 0) ? false : true;
        transform.position += new Vector3(-value, .0f, .0f) * speed * Time.deltaTime;
    }

    void Attack()
    {
        if (!animator.GetBool("isTransit"))
        {
            animator.SetBool("isAttacking", true);
            float value = this.getDirection(Player.lastPlayer.transform.position);
            sr.flipX = (value > 0) ? false : true;
            transform.position += new Vector3(-value, .0f, .0f) * runSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.isActiveAndEnabled)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                this.OnRabbitHit(player);
            }
        }
    }

    void OnRabbitHit(Player player)
    {
        Vector3 v = player.transform.position - transform.position;
        float angle = Mathf.Atan2(v.y, v.x) / Mathf.PI * 180;
        if (angle > 60f && angle < 120f)
        {
            player.Jump();
            Kill();
        }
        else
        {
            //animator.SetTrigger("isAttacking");
            player.Kill();
        }
    }


    public float getDirection(Vector3 obj)
    {
        float value = (transform.position - obj).x;
        if (Mathf.Abs(value) < 0.02f)
            return 0;
        else if ((transform.position - obj).x > 0)
            return 1;
        else return -1;

        //Vector3 dir = (transform.position - obj);
        //dir.Normalize();
        //return dir.x;
    }

    bool isArrived(Vector3 pos, Vector3 target)
    {
        return Mathf.Abs(pos.x - target.x) < 0.02f;
    }

    bool playerHere()
    {
        Vector3 rabbit_pos = Player.lastPlayer.transform.position;
        if (System.Math.Abs(Mathf.Abs(rabbit_pos.x - pointA.x)
                            + Mathf.Abs(rabbit_pos.x - pointB.x)
                            - Mathf.Abs(pointA.x - pointB.x)) < 0.1f) return true;
        return false;
    }

    private IEnumerator KillCoroutine()
    {
        mode = Mode.Dead;
        animator.SetTrigger("isDead");
        yield return new WaitForSeconds(2 / 3f);
        Destroy(this.gameObject);
    }



    public void Kill()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(KillCoroutine());

    }

    private IEnumerator TransitCoroutine()
    {
        animator.SetBool("isTransit", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isTransit", false);
    }
}