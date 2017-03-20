using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

    public float health, moveSpeed, maxMSpeed, JumpPower;
    public Vector2 vel;
    public Vector2 initPos;
    public bool isAttacking, isGrounded;

    private Animator anim;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () 
    {
        health = 5f;
        moveSpeed = 10f;
        maxMSpeed = 12f;
        JumpPower = 300;
        isGrounded = false;
        initPos = transform.position;
     
        isAttacking = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
      
        
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
            GetComponent<SpriteRenderer>().flipX = true;
        if(HForce > 0)
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
        anim.speed = Mathf.Abs(xforce);
    }

    void Attack()
    {
        //Animation Code 
    }

    void Jump()
    {
        
        rb.AddForce(new Vector2(0, JumpPower));
        isGrounded = false;
    }

    void OnAttacking()
    {
        
    }

}
