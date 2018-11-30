using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        //Makes a timer that waits until the end of the animation before putting false in the attack animator variable. Also waits the end of the animation to shoot the arrow
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

	    //Checks if the player is moving

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

            //change orientation according to Input.GetAxisRaw("Horizontal") --- if -1 -> "left" --- if 1 -> "right" 

            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                orientation = "left";
                if (!flipped)
                {
                    Flip();
                }

                RaycastHit2D hit= Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), transform.TransformDirection(Vector3.left), 0.05f);
                if (!hit || hit.collider.tag != "staticobstacle")
                {
                    //Moves the player from Input.GetAxis("Horizontal")*Time.deltaTime on the x axis

                    gameObject.transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
                }

            }
            else if (Input.GetAxisRaw("Horizontal") == 1)
            {
                orientation = "right";
                if (flipped)
                {
                    Flip();
                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0),transform.TransformDirection(Vector3.right), 0.05f);
                if (!hit || hit.collider.tag != "staticobstacle")
                {
                    //Moves the player from Input.GetAxis("Horizontal")*Time.deltaTime on the x axis

                    gameObject.transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
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

                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.9f, 0), transform.TransformDirection(Vector3.down), 0.05f);

                if (!hit || hit.collider.tag != "staticobstacle")
                {
                    
                    //Moves the player from Input.GetAxis("Vertical")*Time.deltaTime on the y axis

                    gameObject.transform.Translate(0, speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
                }

            }
            else if (Input.GetAxisRaw("Vertical") == 1)
            {
                orientation = "up";

                //sets the animator parameter "direction" to 2 (up) to use the right animation

                animator.SetInteger("direction", 2);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), 0.05f);
                if (!hit || hit.collider.tag != "staticobstacle")
                {
                    //Moves the player from Input.GetAxis("Vertical")*Time.deltaTime on the y axis
                    gameObject.transform.Translate(0, speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
                }
            }

            

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
            //starts the animation that shoots an arrow in the right direction
            animator.SetBool("attack", true);
            hasattacked = true;
            //shoots an arrow with 0.4s delay to match the animation
            Invoke("Shootforrealthistime",0.4f);
        }
        else
        {
            Debug.Log("You have no bow!");
        }
    }

    public void Shootforrealthistime()
    {
        //actually shoots the arrow
        Instantiate(arrow);
    }

    //Flips the character sprite to make him look left or right

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
