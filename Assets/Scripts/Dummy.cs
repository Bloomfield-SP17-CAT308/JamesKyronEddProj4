using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour 
{
    public float health;

	// Use this for initialization
	void Start () 
    {
        health = 3f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (health < -40)
            Destroy(gameObject);
	}

    void Hurt(float pain)
    {
        health -= pain;
    }

}
