using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmoothCameraFollow2D : MonoBehaviour
{
    public float timesee;
    public Rigidbody2D target;
    public float smoothSpeed = 10f;
    //private readonly Vector3 offset = new Vector3(0f, 0f, -10f);

    // Define the boundaries where the camera must stop
    [Header("Boundary Limits")]
    public float minX = 0f; // Leftmost camera position
    public float maxX = 0f;  // Rightmost camera position
    public float minY = 0f;  // Bottommost camera position
    public float maxY = 0f;   // Topmost camera position
    private float cameraZ;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        // Store our camera's Z position at the start
        cameraZ = transform.position.z;
    }
    void FixedUpdate()
    {
        timesee += Time.deltaTime/3;
        if (NewBehaviourScript.Entrace == true)
        {
            minX = -125f;
            maxX = -103f;
            minY = -2f;
            maxY = 10;
        }
        else if (NewBehaviourScript.Temple == true)
        {
            minX = -74f;
            maxX = -34f;
            minY = -2;
            maxY = 8;
        }
        else if (NewBehaviourScript.Village == true)
        {
            minX = -9f;
            maxX = 21f;
            minY =-2;
            maxY =8;
        }
        else if (NewBehaviourScript.House == true)
        {
            minX = 35f;
            maxX = 65f;
            minY = -2;
            maxY = 8;
        }
        else if (NewBehaviourScript.Village_2 == true)
        {
            minX = 77f;
            maxX = 114f;
            minY = -1;
            maxY = 8;
        }

        else if (NewBehaviourScript.Grave == true)
        {
            minX = 125f;
            maxX = 178f;
            minY = -2;
            maxY = 8;
        }
        else if (NewBehaviourScript.Final == true)
        {
            minX = 197;
            maxX = 252;
            minY = -2;
            maxY = 8;
        }
        Vector2 targetPosition = target.position;

        // 2. Clamp the target's X and Y coordinates
        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);

        // 3. Set the camera's new position
        // We use the clamped X/Y and the original Z
        //    transform.position = new Vector3(clampedX, clampedY, cameraZ);

        Vector3 desiredPosition = new Vector3(clampedX, clampedY, cameraZ);
        transform.position = Vector3.SmoothDamp(
            transform.position,   // Our current position
            desiredPosition,      // The position we want to be at
            ref velocity,         // A variable SmoothDamp uses to track speed
            smoothTime);          // The time to catch up
    }



    //if (target == null) return;

    //// 1. Calculate the raw desired position based on the player
    //Vector3 desiredPosition = target.position + offset;

    //// 2. Clamp the desired position to the defined boundaries
    //float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
    //float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

    //// Create a new clamped position with the fixed Z offset
    //Vector3 clampedPosition = new Vector3(clampedX, clampedY, offset.z);

    //// 3. Smoothly move the camera to the clamped position
    //Vector3 smoothedPosition = Vector3.Lerp(
    //    transform.position,
    //    clampedPosition, // Use the clamped position here!
    //    smoothSpeed * Time.deltaTime
    //);

    //// 4. Apply the final smoothed position
    //transform.position = smoothedPosition
}