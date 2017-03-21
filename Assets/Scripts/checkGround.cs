using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour 
{
    private Player pp;

    void Awake()
    {
        pp = transform.parent.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Platform"))
            pp.isGrounded = true;    
    }


       
}
