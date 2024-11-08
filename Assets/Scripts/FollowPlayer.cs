using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Offset;
    [SerializeField] float SmoothSpeed;
    private Vector3 DesiredPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = Player.position + Offset;
    // }
    void FixedUpdate()
    {
        // Set the desired camera position
        DesiredPosition = Player.position + Offset;
        
        // Check if there’s an obstacle between the camera and Player
        RaycastHit hit;
        if (Physics.Linecast(Player.position, DesiredPosition, out hit))
        {
            // Rotate the camera around the Player to find a clear line of sight
            int rotationStep = 90; // Rotate by 90 degrees each step
            for (int i = 0; i < 4; i++)
            {
                // Rotate the Offset vector around the Player
                Offset = Quaternion.Euler(0, rotationStep, 0) * Offset;
                DesiredPosition = Player.position + Offset;

                // Check again for obstruction with updated position
                if (!Physics.Linecast(Player.position, DesiredPosition, out hit))
                {
                    break; // Stop rotating once we have a clear view
                }
            }
        }

        // Smoothly move the camera to the updated position
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        
        // Always look at the Player
        transform.LookAt(Player);
    }
}
