using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    public PlayerBow bow;
    private float xVelocity, yVelocity, radAngle, bowForce;
    public float gravity = 2f;
    public float angle = 0f;
    private float timeSinceFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bowForce = bow.currentForce;
        bow.currentForce = 0f;
        rb.velocity = bow.arrowSpawnPoint.up * bowForce;
        radAngle = angle * (Mathf.PI / 180f);
        
    }

    void FixedUpdate()
    {
        timeSinceFire += Time.fixedDeltaTime;
        xVelocity = bowForce * Mathf.Cos(angle);
        yVelocity = bowForce * Mathf.Sin(angle) - (gravity * timeSinceFire);
        rb.velocity = bow.arrowSpawnPoint.up * xVelocity + bow.arrowSpawnPoint.forward * -1 * yVelocity;
    }
}
