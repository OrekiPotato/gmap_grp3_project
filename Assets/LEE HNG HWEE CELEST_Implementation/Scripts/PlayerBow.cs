using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Transform arrowSpawnPoint, head;
    public GameObject arrowPrefab;
    public Animator animator;
    public float maxForce = 20f;
    public float currentForce;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("IsFiring", true);
            if (currentForce < maxForce)
            {
                currentForce += 20f * Time.deltaTime;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsFiring", false);
            var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            arrow.GetComponent<Arrow>().bow = this;

        }
        
    }
}
