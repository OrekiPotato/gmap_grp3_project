using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float mSpeed = 5f;

    private Vector3 moveDir;

    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(horizontal, 0, vertical);

        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * mSpeed;
    }
}
