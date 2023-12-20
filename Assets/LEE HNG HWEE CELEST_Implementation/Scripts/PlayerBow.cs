using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles the firing of the arrows
public class PlayerBow : MonoBehaviour
{
    //get the transform of the arrow's spawn point so that the arrow can be spawned in the correct position and rotation
    public Transform arrowSpawnPoint;
    //Get the arrow prefab to spawn in
    public GameObject arrowPrefab;
    //Get the animator for the bow
    public Animator animator;
    //The maximum the arrow will be shot (not exact)
    public float maxForce = 20f;
    //Actual speed the arrow will be shot
    public float currentForce;

    void Update()
    {
        //When the left mouse button is held down
        if(Input.GetMouseButton(0))
        {
            //Set the IsFiring bool parameter in the animator to true so the firing animation will play
            animator.SetBool("IsFiring", true);
            //If the current force is less that the maximum force (ensures that the speed the arrow will be shot will not exceed the max)
            if (currentForce < maxForce)
            {
                //Increases the currentForce over time so that the arrow will be shot with more speed the longer the left mouse button 
                //is held down
                currentForce += 20f * Time.deltaTime;
            }
        }

        //If the left mouse button is released
        if(Input.GetMouseButtonUp(0))
        {
            //Set the IsFiring bool parameter in the animator to false so the firing animation will not play
            animator.SetBool("IsFiring", false);
            //Spawn the arrow prefab at the arrow spawn point position and rotation
            var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            //Store this script into the arrow's script as a variable called bow
            arrow.GetComponent<Arrow>().bow = this;

            
        }
        
    }
}
