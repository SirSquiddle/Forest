using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableScript : MonoBehaviour
{

    public GameObject parent;
    public bool destroyed = false;

	// Use this for initialization
	void Start ()
	{
	    destroyed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.transform.tag == "arrow")
        {
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            destroyed = true;
            Destroy(col.gameObject);
        }
    }
}
