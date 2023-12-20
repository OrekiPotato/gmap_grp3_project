using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleMovement : MonoBehaviour
{
    private float horizontal; //input variables
    private float vertical;
    private float mSpeed = 5f; //player movement speed

    private Vector3 moveDir;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //captures and returns the input value (-1, 0, 1) for both horizontal and vertical every frame so it can be used to update the player's direction (moveDir)
        vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, 0, vertical);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * mSpeed; //apply linear velocity to the players rb with the speed to make the player move towards the direction that was inputted by the user
    }
}
