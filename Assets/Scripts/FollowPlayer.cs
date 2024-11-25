using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] float Sensitivity = 120f;
    [SerializeField] float MaxVerticalAngle = 80f;
    [SerializeField] Vector3 PlayerOffset = new (10,5,0); 
    [SerializeField] float SmoothSpeed = 0.125f; // Only used in CheckObstacles method
    private Vector3 DesiredPosition; // Only used in CheckObstacles method
    private float Pitch = 0f; 
    private float Yaw = 0f;
    

    void Start()
    {

        // Lock the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseMovement();
        UpdateCameraPosition();
        //CheckObstacles();
    }
    void MouseMovement()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        // Adjust yaw and pitch
        Yaw += mouseX;
        Pitch -= mouseY;


        // Clamp the pitch to prevent flipping
        Pitch = Mathf.Clamp(Pitch, -MaxVerticalAngle, MaxVerticalAngle);
    }
    void UpdateCameraPosition()
    {
        // Calculate new camera position and rotation
        Quaternion rotation = Quaternion.Euler(Pitch, Yaw, 0f);
        Vector3 offset = rotation * PlayerOffset;

        // Set camera position and look at the player
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
    void CheckObstacles() {
        // Set the desired camera position
        DesiredPosition = player.position + PlayerOffset;
        
        // Check if there’s an obstacle between the camera and Player
        RaycastHit hit;
        if (Physics.Linecast(player.position, DesiredPosition, out hit))
        {
            // Rotate the camera around the Player to find a clear line of sight
            int rotationStep = 90; // Rotate by 90 degrees each step
            for (int i = 0; i < 4; i++)
            {
                // Rotate the PlayerOffset vector around the Player
                PlayerOffset = Quaternion.Euler(0, rotationStep, 0) * PlayerOffset;
                DesiredPosition = player.position + PlayerOffset;

                // Check again for obstruction with updated position
                if (!Physics.Linecast(player.position, DesiredPosition, out hit))
                {
                    break; // Stop rotating once we have a clear view
                }
            }
        }

        // Smoothly move the camera to the updated position
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        
        // Always look at the Player
        transform.LookAt(player.position);
    }
}
