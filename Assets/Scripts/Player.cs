using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

    public float health, moveSpeed, maxMSpeed, JumpPower, atk;
    public Vector2 vel;
    public Vector2 initPos;
    public bool isGrounded, attacking;
    public Collider2D attackTrigger, atkL, atkR;
    public Animator anim;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () 
    {
        
        attacking = false;
        isGrounded = false;
        initPos = transform.position;
        attackTrigger = atkL;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        
        if (GetComponent<SpriteRenderer>().flipX)
            attackTrigger = atkL;
        else
            attackTrigger = atkR;

        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch"))
            attacking = false;
            
         
    }
    void FixedUpdate ()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attacking = true;
            PunchThings();
        }


        


        if (!isGrounded)
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            print("true");
            Jump();
        }
        float HForce = Input.GetAxis("Horizontal");
        if (HForce < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (HForce > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        

        
        Move(HForce);

        if (rb.velocity.magnitude > maxMSpeed)
            rb.velocity = rb.velocity.normalized * maxMSpeed;

    }

    void Move(float xforce)
    {
         if (xforce == 0)
             rb.velocity = new Vector2(0, rb.velocity.y);
          else
        {
            rb.AddForce(new Vector2(xforce * moveSpeed, 0));

        }

        anim.SetFloat("Speed", Mathf.Abs(xforce));

    }

  
    void Jump()
    {
        rb.AddForce(new Vector2(0, JumpPower));
        isGrounded = false;
    }

    void PunchThings()
    {
        
        anim.SetTrigger("Hit1");
       
    }
        

}
