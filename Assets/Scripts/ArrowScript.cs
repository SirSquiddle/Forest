using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    public float timer = 0;
    public string orientation = "";
    public GameObject character = null;
    public float speed = 25;

	// Use this for initialization
	void Start ()
	{
	    orientation = GameObject.Find("ForestCharacter").GetComponent<CharacterController>().orientation;
	    gameObject.transform.position = GameObject.Find("ForestCharacter").transform.position;
        timer = 0;
	    switch (orientation)
	    {
            case "up":
	            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
	            break;

	        case "down":
	            gameObject.transform.rotation = new Quaternion(0, 0, -1, 0);
                break;

	        case "right":
	            //TODO right
	            gameObject.transform.rotation = new Quaternion(0, 0, -0.7f, 0.7f);
                break;

	        case "left":
                //TODO left
                gameObject.transform.rotation = new Quaternion(0, 0, 0.7f, 0.7f);
                break;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;
	    switch (orientation)
	    {
	        case "up":
	            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime, gameObject.transform.position.z);
                break;

	        case "down":
	            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed * Time.deltaTime, gameObject.transform.position.z);
                break;

	        case "right":
	            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
                break;

	        case "left":
	            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
                break;
	    }


        if (timer >= 5)
	    {
            Destroy(gameObject);
	    }
	}
}
