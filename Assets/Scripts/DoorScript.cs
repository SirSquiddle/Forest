using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    //numéro de la scene à charger - File -> Build Settings -> Drag & Drop les scenes en question dans "Scenes In Build", le numéro de la scene est affiché tout à droite de la ligne. Merci de laisser le menu en n°0
    public int numScene = 0;
    

// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            SceneManager.LoadScene(numScene);
        }
    }
}
