using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Cannon Settings")]
    public float rotationSpeed = 15f;
    public float tileSpeed = 10f;
    public float shotVelocity = 100f;

    [Header("Empty Transforms")]
    public Transform tiltpoint;
    public Transform barrelPivot;
    public Transform spawnPoint;

    [Header("Projectile Prefabs")]
    public GameObject cannonBallPrefab;
    public GameObject rocketPrefab;
    public GameObject yapopoPrefab;
    public GameObject currentProjectile;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    [SerializeField] private AudioClip cannonFireClip;
    [SerializeField] private AudioClip explosionClip;


    // Start is called before the first frame update
    void Start()
    {
        currentProjectile = yapopoPrefab;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CannonRotation();
        BarrelTilt();
        Fire();
        CheckInput();
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

        float tiltAmount = -vInput * tileSpeed * Time.deltaTime;

        Vector3 pivot = tiltpoint.position;

        barrelPivot.RotateAround(pivot, barrelPivot.right, tiltAmount); // Tilts the barrel from the new pivot point at tiltpoint position.
    }

    private void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(currentProjectile, spawnPoint.position, spawnPoint.rotation); // Sets the spawn location of the cannonball to an Empty.

            Rocket rocketScript = projectile.GetComponent<Rocket>();
            if (rocketScript != null) 
            {
                rocketScript.LaunchRocket(shotVelocity);

                rocketScript.RocketCollision += HandleRocketCollision; // Subscribes to the RocketCollision in Rocket.cs using HandleRocketCollision as handler.
            }
            else
            {
                Rigidbody ballRb = projectile.GetComponent<Rigidbody>();
                if (ballRb != null)
                {
                    ballRb.AddRelativeForce(new Vector3(0, shotVelocity, 0));
                }
            }

            audioSource.PlayOneShot(cannonFireClip);
        }
    }

    private void CheckInput()
    {

        // Switches prefabs based on what key was pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchProjectile(yapopoPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchProjectile(cannonBallPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchProjectile(rocketPrefab);
        }
    }

    private void SwitchProjectile(GameObject newPrefab)
    {
        currentProjectile = newPrefab;
    }

    private void HandleRocketCollision(Collider collision)
    {
        if (collision.GetComponent<Collider>() != null) // Checks if collided object has a collider component
        {
            if (explosionClip != null)
            {
                audioSource.PlayOneShot(explosionClip); // Plays audio clip at collision
            }
        }
    }

}
