using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPoint : MonoBehaviour {

	// Use this for initialization

    private GameObject mover;
	void Start () 
    {
        mover = null;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (mover != null)
            if(mover.transform.position == transform.position)
                mover.GetComponent<WorldMover>().moving = false;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WMover"))
        {
            mover = other.gameObject;
        }
        
    }
}
