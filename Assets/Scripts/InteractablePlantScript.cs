using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlantScript : MonoBehaviour
{

    public bool isGrown = false;

	// Use this for initialization
	void Start () {

	    if (gameObject.transform.Find("witherable").gameObject.active)
	    {
	        isGrown = true;
        }
	    else
	    {
	        isGrown = false;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.F))
	    {
	        if (gameObject.transform.Find("witherable").gameObject.active)
	        {
	            gameObject.transform.Find("witherable").gameObject.SetActive(false);
	            gameObject.transform.Find("growable").gameObject.SetActive(true);
                isGrown = false;

	        }
	        else
	        {
	            gameObject.transform.Find("witherable").gameObject.SetActive(true);
	            gameObject.transform.Find("growable").gameObject.SetActive(false);
	            isGrown = true;
            }
        }
	}

    
}
