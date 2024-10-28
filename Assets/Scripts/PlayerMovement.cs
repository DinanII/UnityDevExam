using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Movement;
    [SerializeField] float MovementSpeed;
    [SerializeField] bool Jumped;
    [SerializeField] float JumpHeight;
    
    GroundChecker GroundChecker;
    Rigidbody Rb;

    Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        
        GroundChecker = GetComponentInChildren<GroundChecker>();
        Camera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GroundChecker.IsGrounded) {
            Jumped = true;
        }
        // if(!GroundChecker.IsGrounded) {
        //     MovementSpeed *= 0.5f;
        // }
    }

    // FixedUpdate is called 50 * / second
    void FixedUpdate() {
        Vector3 cameraForward = Camera.transform.forward;
        Vector3 cameraRight = Camera.transform.right;

        // Normalize to avoid diagonal speed boost
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Zero out the y component to keep the movement on the XZ plane
        cameraForward.y = 0;
        cameraRight.y = 0;


        if(Jumped) {
            Rb.AddForce(0, JumpHeight, 0, ForceMode.VelocityChange);
            Jumped = false;
        }

        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W)) {
            movement += cameraForward * MovementSpeed;
        }
        if(Input.GetKey(KeyCode.S)) {
            movement -= cameraForward * MovementSpeed;
        }
        if(Input.GetKey(KeyCode.A)) {
            movement -= cameraRight * MovementSpeed;
        }
        if(Input.GetKey(KeyCode.D)) {
            movement += cameraRight * MovementSpeed;
        }

        // Apply movement as a single force to the rigidbody
        Rb.AddForce(movement, ForceMode.VelocityChange);
    }
}
