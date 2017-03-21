using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrig : MonoBehaviour 
{
    private float dmg;
    public Player player;
    public bool entered;
    public Collider2D rival;
    void Awake()
    {
        rival = null;
        dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().atk;
        player = transform.parent.gameObject.GetComponent<Player>();
    }

    void Update()
    {
        if(player.attacking && entered)
            rival.gameObject.SendMessage("Hurt", dmg);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("Enemy"))
        {
            rival = other;
            entered = true;

        }
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            entered = false;
            rival = null;
        }
    }

  
}
