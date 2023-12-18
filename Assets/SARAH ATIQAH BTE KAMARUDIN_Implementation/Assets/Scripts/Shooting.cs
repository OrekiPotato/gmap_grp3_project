using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting : MonoBehaviour
{
    public Missile missile;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*GameObject missileObj = Instantiate(missile, shootPt.position, shootPt.rotation); //spawn missile prefab into the scene at the position tht was taken from the transform component of the gameobject shootpoint
            missileObj.GetComponent<Rigidbody>().velocity = -shootPt.transform.forward * mSpeed; //moving the missile forward 

            Destroy(missileObj, 5f); //destory after 5s*/

            //missile.FireMissile();
        }
    }
}
