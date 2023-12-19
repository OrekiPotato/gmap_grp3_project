using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float initialSpeed = 50f;
    public float accelerationFactor = 2.0f;

    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public float upwardForce = 1f;

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
            rb.velocity = transform.up * (velocity * accelerationFactor); // Moves rocket forwards based on specified acceleration factor.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Cannon")) // Checks for name
        {
            return; // Ignores the Cannon object when they spawn. Avoid early explosion.
        }

        Explode();
    }

    private void Explode()
    {
        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius); // Creates a sphere around Explosion area to detect other collidable objects
        foreach (Collider hit in colliders) 
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, upwardForce); // Generate explosion force to all collidable objects within sphere.
            }
        }

        Destroy(gameObject);
    }
}
