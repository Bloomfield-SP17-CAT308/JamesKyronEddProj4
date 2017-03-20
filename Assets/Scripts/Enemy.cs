using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{

    public float health, moveSpeed, maxMSpeed, roamDist;
    public AIBehavior state;
    public Vector2 vel;
    public Vector2 initPos;
    public bool left;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
    {
        health = 5f;
        moveSpeed = 5f;
        maxMSpeed = 4f;
        initPos = transform.position;
        state = AIBehavior.Roam;
        left = true;
        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (state == AIBehavior.Roam)
        {
            OnRoam(left);
        }

        float HForce = Input.GetAxis("Horizontal");
        //Move(HForce, 0);

        if (rb.velocity.magnitude > maxMSpeed)
            rb.velocity = rb.velocity.normalized * maxMSpeed;

	}

    void Move(float xforce, float yForce)
    {
       // if (xforce == 0)
       //     rb.velocity = new Vector2(0, rb.velocity.y);
      //  else
        {
            rb.AddForce(new Vector2(xforce * moveSpeed, 0));
            print(rb.velocity);
        }
    }

    void Attack()
    {
        //Animation Code 
    }

    void Jump()
    {
        
    }

    void OnRoam(bool goingLeft)
    {
        if (goingLeft)
            Move(-.5f, 0);
        else
            Move(.5f, 0);
      

    }

    void OnChase()
    {
    }

    void OnAttacking()
    {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
            left = !left;
    }
        
}
