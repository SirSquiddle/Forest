using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed*Input.GetAxis("Horizontal")*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed * Input.GetAxis("Vertical")*Time.deltaTime, gameObject.transform.position.z);
        }
    }
}
