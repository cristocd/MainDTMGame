using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpForce = 7;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        //finding the players box collider and sprite renderer

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
       // Making the player jump when the up arrow is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && gameOver != true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

   
   // Making the player be able to jump only when on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}