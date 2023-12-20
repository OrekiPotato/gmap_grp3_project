using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : MonoBehaviour
{
    public Transform player;
    private Rigidbody rb;

    public GameObject missile;
    public GameObject enemy;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float mSpeed; //movement speed

    private int enemyDeath; //enemy counter

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyDeath = 0; //initialise the enemy count to 0 first
    }

    private void FixedUpdate()
    {
        Vector3 missileDir = player.position - rb.position; //calculate the vector pointing from the player postion to the missile's position
        missileDir.Normalize(); //since we want the direction, normalising it will turn the vector into a unit vector while keeping the direction the same, so it can be used applid to the cross product without the magn messing calculations

        Vector3 rotateNeeded = Vector3.Cross(transform.up, missileDir); //using cross product between the missile's up direction? with the direction to the player, to calculate the angle for the missile to face the player's direction,
                                                                        //result of it is a third vector perpendicular to both vectors which is needed when rotating the missile

        rb.angularVelocity = rotateNeeded * rotateSpeed; //applying the angular velocity of the missile around the vector earlier, with the rotate speed to rotate towards the player
        rb.velocity = transform.up * mSpeed; //applying the linear velocity to the missile rb's up direction multiplied by the movement speed to move forward 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            missile.transform.position = new Vector3(0f, 0.6f, 0f); //to reset the missile back to its og position whenever it collides with the player
        }

        if (collision.gameObject.tag == "Enemy")
        {
            RandomisePos(); //teleports the enemy to a random area of the plane and adds to the enemy counter (enemy counter is for feedback)

            enemyDeath += 1;
            print($"Enemy die: {enemyDeath}");
        }
    }

    private void RandomisePos()
    {
        float randomX = (Random.Range(-3.5f, 3.5f)); //randomises the x and z-axis with the min/max x and z values of the enemy (..that was found through moving the enemy around in scene view)
        float randomZ = (Random.Range(-3.5f, 3.5f));

        Vector3 randomPos = new Vector3(randomX, enemy.transform.position.y, randomZ); //new vector/position of the randomised values which is used to set the new position of the enemy
        enemy.transform.position = randomPos;
    }
}
