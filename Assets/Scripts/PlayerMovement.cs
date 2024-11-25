using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float JumpHeight = 5f;
    private bool Jumped = false;

    private GroundChecker GroundChecker;
    private Transform ObjectTransform;
    private Rigidbody Rb;
    private Camera Camera;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        GroundChecker = GetComponentInChildren<GroundChecker>();
        Camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundChecker.IsGrounded)
        {
            Jumped = true;
        }

        if(ObjectTransform.position.y < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

     void FixedUpdate()
    {
        Vector3 cameraForward = Camera.transform.forward;
        Vector3 cameraRight = Camera.transform.right;

        // Zero out the y component to keep movement on the XZ plane
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize directions
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += cameraForward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= cameraForward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= cameraRight;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += cameraRight;
        }

        // Scale movement by speed
        movement = movement.normalized * MovementSpeed;

        // Preserve the vertical velocity
        float verticalVelocity = Rb.velocity.y;

        // Apply jump force
        if (Jumped)
        {
            verticalVelocity = JumpHeight;
            Jumped = false;
        }

        // Set the velocity, preserving the vertical component
        Rb.velocity = new Vector3(movement.x, verticalVelocity, movement.z);
    }
}
