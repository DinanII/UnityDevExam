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
    private Transform Transform;
    private Rigidbody RigidBody;
    private Camera Camera;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        GroundChecker = GetComponentInChildren<GroundChecker>();
        Camera = Camera.main;
        Transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundChecker.IsGrounded)
        {
            Jumped = true;
        }

        if(Transform.position.y < 0) {
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
        float verticalVelocity = RigidBody.velocity.y;

        // Apply jump force
        if (Jumped)
        {
            verticalVelocity = JumpHeight;
            Jumped = false;
        }

        // Set the velocity, preserving the vertical component
        RigidBody.velocity = new Vector3(movement.x, verticalVelocity, movement.z);
    }
}
