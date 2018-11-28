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
    private Animator animator = null;
    public bool flipped = false;
    public float timer = 0;
    public bool hasattacked = false;

    

	void Start ()
	{
	    animator = GetComponent<Animator>();
    }
	
	void Update ()
	{

	    if (hasattacked)
	    {
	        timer += Time.deltaTime;

	        if (timer >= 0.4)
	        {
	            hasattacked = false;
                animator.SetBool("attack", false);
	            timer = 0;
	        }
	    }

	    //animator.SetBool("attack", false);

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
	    {
            animator.SetBool("walking", true);
        }
	    else
	    {
	        animator.SetBool("walking", false);
        }

	    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {

            //sets the animator parameter "direction" to 1 (side) to use the right animation

            animator.SetInteger("direction", 1);

            //Moves the player from Input.GetAxis("Horizontal")*Time.deltaTime on the x axis

            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed*Input.GetAxis("Horizontal")*Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);

            //change orientation according to Input.GetAxisRaw("Horizontal") --- if -1 -> "left" --- if 1 -> "right" 

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                orientation = "left";
                if (!flipped)
                {
                    Flip();
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                orientation = "right";
                if (flipped)
                {
                    Flip();
                }
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {

            //change orientation according to Input.GetAxisRaw("Vertical") --- if -1 -> "down" --- if 1 -> "up" 

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                orientation = "down";

                //sets the animator parameter "direction" to 0 (down) to use the right animation

                animator.SetInteger("direction", 0);

            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                orientation = "up";

                //sets the animator parameter "direction" to 2 (up) to use the right animation

                animator.SetInteger("direction", 2);
            }

            //Moves the player from Input.GetAxis("Vertical")*Time.deltaTime on the y axis

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed * Input.GetAxis("Vertical")*Time.deltaTime, gameObject.transform.position.z);

        }

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
            Shoot();
	    }
	}

    public void Shoot()
    {
        if (hasBow && !hasattacked)
        {
            //shoots an arrow in the right direction
            animator.SetBool("attack", true);
            hasattacked = true;
            Invoke("Shootforrealthistime",0.4f);
        }
        else
        {
            Debug.Log("You have no bow!");
        }
    }

    public void Shootforrealthistime()
    {
        Instantiate(arrow);
    }

    public void Flip()
    {
        if (flipped)
        {
            gameObject.transform.localScale = new Vector3(6.25f,6.25f,1);
            flipped = !flipped;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-6.25f, 6.25f, 1);
            flipped = !flipped;
        }
    }
}
