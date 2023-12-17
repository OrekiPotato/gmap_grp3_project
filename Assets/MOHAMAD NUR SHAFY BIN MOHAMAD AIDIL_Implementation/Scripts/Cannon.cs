using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float tileSpeed = 10f;

    public Transform tiltpoint;
    public Transform barrelPivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CannonRotation();
        BarrelTilt();
        Fire();
    }

    private void CannonRotation()
    {
        float hInput = Input.GetAxis("Horizontal");

        float rotationAmount = hInput * (rotationSpeed * 2) * Time.deltaTime; // Sets how much to rotate over time.
        
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void BarrelTilt()
    {
        float vInput = Input.GetAxis("Vertical");

        float tiltAmount = vInput * tileSpeed * Time.deltaTime;

        Vector3 pivot = tiltpoint.position;

        barrelPivot.RotateAround(pivot, barrelPivot.right, tiltAmount); // Tilts the barrel from the new pivot point at tiltpoint position.
    }

    private void Fire()
    {

    }
}
