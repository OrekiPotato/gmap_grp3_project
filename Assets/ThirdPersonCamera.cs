using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mCannon;
    public float rotationSpeed = 5f;
    public float distance = 5f;
    public float height = 2f;

    // Update is called once per frame
    void Update()
    {
        // checks if target is set in Inspector
        if (mCannon == null)
        {
            Debug.LogWarning("Target not assigned to script.");
            return;
        }

        float hInput = Input.GetAxis("Horizontal");
        float rotationAngle = mCannon.eulerAngles.y + hInput;

        Vector3 desiredPos = CalculateDesiredPos(rotationAngle);

        // Smoothly interpolate to desired pos and rotation.
        transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * rotationSpeed);
        transform.LookAt(mCannon.position + Vector3.up * height);
    }

    private Vector3 CalculateDesiredPos(float rotationAngle)
    {
        // Converts degrees to rads
        float angleRad = (rotationAngle + 180f) * Mathf.Deg2Rad;

        // Calculate pos offset
        float offsetX = Mathf.Sin(angleRad) * distance;
        float offsetZ = Mathf.Cos(angleRad) * distance;

        // Set the desired pos
        Vector3 desiredPos = mCannon.position + new Vector3(offsetX, height, offsetZ);
        return desiredPos;
    }
}
