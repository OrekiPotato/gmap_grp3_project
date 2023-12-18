using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float mSpeed = 10f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ProjectileMovement();
    }

    //private void ProjectileMovement()
    //{
    //    Vector3 BallVelocity = Vector3.forward * mSpeed; // Sets cannonball movement direction
    //    transform.Translate(BallVelocity * Time.deltaTime); // Moves cannonball based on time.
    //}

    public void SetVelocity(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.velocity = direction * mSpeed;
        }
    }
}
