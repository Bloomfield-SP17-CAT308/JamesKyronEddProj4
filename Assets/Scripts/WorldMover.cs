using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour 
{
    public bool moving;

	// Use this for initialization
	void Start () 
    {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                StartCoroutine(MoveLeft());
            if (Input.GetKeyDown(KeyCode.UpArrow))
                StartCoroutine(MoveUp());
            if (Input.GetKeyDown(KeyCode.RightArrow))
                StartCoroutine(MoveRight());
            if (Input.GetKeyDown(KeyCode.DownArrow))
                StartCoroutine(MoveDown());
        }
	}

    IEnumerator MoveLeft()
    {
        moving = true;
        while (moving)
        {
            transform.position += new Vector3(-.05f, 0);
            yield return null;
        }
    }

    IEnumerator MoveUp()
    {
        moving = true;
        while (moving)
        {
            transform.position += new Vector3(0, 0.05f);
            yield return null;
        }
    }

    IEnumerator MoveRight()
    {
        moving = true;
        while (moving)
        {
            transform.position += new Vector3(.05f, 0);
            yield return null;
        }
    }

    IEnumerator MoveDown()
    {
        moving = true;
        while (moving)
        {
            transform.position += new Vector3(0, -.05f);
            yield return null;
        }
    }
}
