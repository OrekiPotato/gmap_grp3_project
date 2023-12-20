using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows the player to look up and down without affect their movement directions
public class PlayerHeadRotation : MonoBehaviour
{
    //Store the player's rotation speed so they can roate faster
    public float rotationSpeed = 4f;
    //Declare a variable to store the player's y rotation values
    private float yRotation;

    void Update()
    {
        //Store the player's y rotation values based on how much they moved the mouse in the y direction and their rotation speed. 
        //Multiply it by -1 so that the rotation will not be inverted
        yRotation = Input.GetAxis("Mouse Y") * -1f;
        //Rotate the player's "head"
        transform.Rotate(yRotation * rotationSpeed, 0f, 0f);
    }
}
