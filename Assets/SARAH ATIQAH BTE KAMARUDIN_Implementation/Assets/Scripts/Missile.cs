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
    [SerializeField] private float mSpeed;

    private int enemyDeath;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyDeath = 0;
    }

    private void FixedUpdate()
    {
        Vector3 missileDir = player.position - rb.position;
        missileDir.Normalize();

        Vector3 rotateNeeded = Vector3.Cross(transform.up, missileDir);

        rb.angularVelocity = rotateNeeded * rotateSpeed;
        rb.velocity = transform.up * mSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //missile.SetActive(false);
            missile.transform.position = new Vector3(0f, 0.6f, 0f);

            //missile.SetActive(true);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //enemy.SetActive(false);

            RandomisePos();

            //enemy.SetActive(true);

            enemyDeath += 1;
            print($"Enemy die: {enemyDeath}");
        }
    }

    private void RandomisePos()
    {
        float randomX = (Random.Range(-3.5f, 3.5f));
        float randomZ = (Random.Range(-3.5f, 3.5f));

        Vector3 randomPos = new Vector3(randomX, enemy.transform.position.y, randomZ);
        enemy.transform.position = randomPos;
    }
}
