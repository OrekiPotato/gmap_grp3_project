using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float verticalInput, horizontalInput, xRotation;
    public float rotationSpeed = 4f;
    public float playerSpeed = 5;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        xRotation = Input.GetAxis("Mouse X");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * playerSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playerSpeed);
        transform.Rotate(0f, xRotation * rotationSpeed, 0f);
    }
}
