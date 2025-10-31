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
    public GameObject music1;
    public GameObject musictown;
    public GameObject musicsilence;
  
    void Start()
    {
        
        // Store our camera's Z position at the start
        cameraZ = transform.position.z;
        musicsilence.SetActive(false);
        musictown.SetActive(false);
    }
    void FixedUpdate()
    {
        if(NewBehaviourScript.Temple==true)
        {
            music1.SetActive(true);
            musicsilence.SetActive(false);
            musictown.SetActive(false);
        }
        if (NewBehaviourScript.Village == true|| NewBehaviourScript.Village_2==true)
        {
            music1.SetActive(false);
            musicsilence.SetActive(false);
            musictown.SetActive(true);
        }
        if (NewBehaviourScript.Grave==true)
        {
            music1.SetActive(false);
            musicsilence.SetActive(true);
            musictown.SetActive(false);
        }
        timesee += Time.deltaTime/3;
        if (NewBehaviourScript.Entrace == true)
        {
            
            minX = -126f;
            maxX = -103f;
            minY = -4.3f;
            maxY = 10;
        }
        else if (NewBehaviourScript.Temple == true)
        {
            
            minX = -67.5f;
            maxX = -41f;
            minY = -3;
            maxY = 10;
        }
        else if (NewBehaviourScript.Village == true)
        {
           
            minX = -3f;
            maxX = 20f;
            minY =-3;
            maxY =10;
        }
        else if (NewBehaviourScript.House == true)
        {
            
            minX = 49f;
            maxX = 61f;
            minY = -3;
            maxY = 10;
        }
        else if (NewBehaviourScript.Village_2 == true)
        {
            minX = 94f;
            maxX = 108f;
            minY = -3;
            maxY = 10;
        }

        else if (NewBehaviourScript.Grave == true)
        {
            minX = 142f;
            maxX = 172f;
            minY = -3;
            maxY = 10;
        }
        else if (NewBehaviourScript.Final == true)
        {
            minX = 213;
            maxX = 247;
            minY = -3;
            maxY = 10;
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