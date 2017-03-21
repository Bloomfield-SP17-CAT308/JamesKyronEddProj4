using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D (Collider2D other) 
    {
        other.transform.position = new Vector3(16, 1.5f, 0);
        
		
	}
}
