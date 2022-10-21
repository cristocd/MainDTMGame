using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move : MonoBehaviour {



	public float speed;
	private float x;
	private PlayerController playerControllerScript;



	// Use this for initialization
	void Start () 
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
    {

		// Make background only move if gameOver = false
		if (playerControllerScript.gameOver == false)
        {
            x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
        }
    }

}