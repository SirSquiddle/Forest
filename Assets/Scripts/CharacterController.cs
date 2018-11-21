using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 1;
    public bool hasBow = false;
    public string orientation = "down";
    public GameObject arrow = null;

    

	void Start ()
	{
		
	}
	
	void Update ()
	{
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            //Moves the player from Input.GetAxis("Horizontal")*Time.deltaTime on the x axis

            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed*Input.GetAxis("Horizontal")*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);

            //change orientation according to Input.GetAxisRaw("Horizontal") --- if -1 -> "left" --- if 1 -> "right" 

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                orientation = "left";
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                orientation = "right";
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            //Moves the player from Input.GetAxis("Vertical")*Time.deltaTime on the y axis

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed * Input.GetAxis("Vertical")*Time.deltaTime, gameObject.transform.position.z);

            //change orientation according to Input.GetAxisRaw("Vertical") --- if -1 -> "down" --- if 1 -> "up" 

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                orientation = "down";
            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                orientation = "up";
            }
        }

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            Shoot();
	    }
	}

    public void Shoot()
    {
        if (hasBow)
        {
            //shoots an arrow in the right direction

            Instantiate(arrow);
            /*switch (orientation)
            {
                case "up":
                    Debug.Log("*Shoots arrow graciously upward*");
                    //TODO shoots an arrow upward
                    Instantiate(arrow);
                    break;

                case "down":
                    Debug.Log("*Shoots arrow graciously downward*");
                    //TODO shoots an arrow downward
                    Instantiate(arrow);
                    break;

                case "right":
                    Debug.Log("*Shoots arrow graciously to the right*");
                    //TODO shoots an arrow to the right
                    Instantiate(arrow);
                    break;

                case "left":
                    Debug.Log("*Shoots arrow graciously to the left*");
                    //TODO shoots an arrow to the left
                    Instantiate(arrow);
                    break;
            }*/
        }
        else
        {
            Debug.Log("You have no bow!");
        }
    }
}
