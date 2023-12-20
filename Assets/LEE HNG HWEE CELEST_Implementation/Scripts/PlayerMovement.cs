using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows the player to rotate the camera and move
public class PlayerMovement : MonoBehaviour
{
    //Declare three floats, one to store the player's horizontal input so that the player can be moved left or right, one to store the
    //player's vertical input so that the player can be moved forward or backward, and one to store the player's mouse x movement to
    //rotate the player
    private float verticalInput, horizontalInput, xRotation;
    //Store the player's rotation and movement speeds so that turning and moving the player will be faster. It is declared as a public 
    //so it can be easily modified in unity
    public float rotationSpeed = 4f;
    public float playerSpeed = 5f;

    void Start()
    {
        //Locks the cursor to the middle of the screen and hides it so that the screen will not constantly turn
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get the horizontal and vertical inputs so that the player can be moved accordingly
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Get the x mouse movement (how much the mouse moved in the x direction) so that the player can be rotated based on how much 
        //they move their mouse
        xRotation = Input.GetAxis("Mouse X");

        //Translate the player's transform position based on their horizontal and vertical inputs and movement speed
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * playerSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playerSpeed);
        //Rotate the player 
        transform.Rotate(0f, xRotation * rotationSpeed, 0f);
    }
}
