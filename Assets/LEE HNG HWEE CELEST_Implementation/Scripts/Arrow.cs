using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Declare a variable to store the rigidbody of the arrow object
    private Rigidbody rb;
    //Declare a variable to store the bow script that created the arrow
    public PlayerBow bow;
    //Declare variable arrowSpeed to store the speed of the arrow
    private float arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody of the arrow object
        rb = GetComponent<Rigidbody>();
        //Store to currentForce variable taken from the PlayerBow script that spawned the arrow as the speed of the arrow
        arrowSpeed = bow.currentForce;
        //Reset the currentForce of the bow to 0 so that the next time left click is pressed, the bows's starting currentForce will stay
        //as 0, allowing the next arrow it fires to not be affect by the provious arrow
        bow.currentForce = 0f;
        //Set the initial velocity of the arrow's rigidbody so that arrow will be fired depending on where the player is facing and the
        //the speed of the arrow will be depending on the arrowSpeed
        rb.velocity = bow.transform.forward * arrowSpeed;
    }
}
