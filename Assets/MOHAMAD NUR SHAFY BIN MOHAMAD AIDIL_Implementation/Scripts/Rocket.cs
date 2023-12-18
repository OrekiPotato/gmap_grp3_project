using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float initialSpeed = 50f;
    public float accelerationFactor = 2.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        LaunchRocket(initialSpeed);
    }

    public void LaunchRocket(float velocity)
    {
        if (rb != null)
        {
            rb.velocity = transform.up * (velocity * accelerationFactor);
        }
    }
}
