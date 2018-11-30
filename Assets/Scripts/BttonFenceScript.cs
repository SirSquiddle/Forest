using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttonFenceScript : MonoBehaviour {

    public GameObject FenceGameObject = null;
    public List<GameObject> tabActors = null;
    public bool pressed = false;

    // Use this for initialization
    void Start ()
    {
		tabActors = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    CheckActors();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.transform.tag == "Player" || col.transform.tag == "breakable")
        {
            Debug.Log("Bonjour");
            tabActors.Add(col.gameObject);
            RefreshButton();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.transform.tag == "Player" || col.transform.tag == "breakable")
        {
            Debug.Log("bye");
            tabActors.Remove(col.gameObject);
            RefreshButton();
        }
    }

    public void RefreshButton()
    {
        if (tabActors.Count == 0 && pressed)
        {
            
            FenceGameObject.SetActive(true);
            gameObject.transform.Find("button").gameObject.SetActive(true);
            gameObject.transform.Find("button_pressed").gameObject.SetActive(false);
            pressed = false;
        }
        else if (tabActors.Count > 0 && !pressed)
        {
            
            FenceGameObject.SetActive(false);
            gameObject.transform.Find("button").gameObject.SetActive(false);
            gameObject.transform.Find("button_pressed").gameObject.SetActive(true);
            pressed = true;
        }
    }

    public void CheckActors()
    {
        List<GameObject> tabActorstmp = tabActors;
        if (tabActors.Count > 0)
        {
            for (int i = 0; i <= tabActorstmp.Count - 1; i++)
            {
                if (tabActorstmp[i].gameObject.tag == "breakable" &&
                    tabActorstmp[i].gameObject.GetComponent<BreakableScript>().destroyed)
                {
                    tabActors.Remove(tabActorstmp[i].gameObject);
                    RefreshButton();
                }
            }
        }
    }
}
