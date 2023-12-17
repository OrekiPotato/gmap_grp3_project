using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject missile;
    public Transform shootPt;
    [SerializeField] private float mSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject missileObj = Instantiate(missile, shootPt.position, shootPt.rotation);
            missileObj.GetComponent<Rigidbody>().velocity = shootPt.transform.up * mSpeed;

            Destroy(missileObj, 5f);
        }
    }
}
