using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFenceScript : MonoBehaviour
{


    public GameObject FenceObject;
    public Sprite opened;
    public Sprite closed;

	// Use this for initialization
	void Start ()
	{
	    gameObject.GetComponent<SpriteRenderer>().sprite = closed;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
            FenceObject.gameObject.SetActive(false);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
