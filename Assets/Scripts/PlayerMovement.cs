using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float JumpHeight = 5f;
    [SerializeField] float Gravity = -20f;
    [SerializeField] public bool AutoRun;
    [SerializeField] int AutoRunMultiplierTreshold = 20;
    [SerializeField] bool AutoRunUseTreshold = true;

    [SerializeField] float AutoRunMovementMultiplier = 0.01f;
    private bool Jumped = false;

    private GroundChecker GroundChecker;
    private Transform PlayerTransform;
    private Rigidbody PlayerRigidbody;
    private Camera MainCamera;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        GroundChecker = GetComponentInChildren<GroundChecker>();
        MainCamera = Camera.main;
        PlayerTransform = transform;
        Physics.gravity = new Vector3(0, Gravity, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundChecker.IsGrounded && !AutoRun)
        {
            Jumped = true;
        }

        if(PlayerTransform.position.y < 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        float currentYVelocity = PlayerRigidbody.velocity.y;
        if(!AutoRun) {
            // Use Camera's horizontal forward direction
            Vector3 cameraForward = Vector3.ProjectOnPlane(MainCamera.transform.forward, Vector3.up);
            Vector3 cameraRight = Vector3.ProjectOnPlane(MainCamera.transform.right, Vector3.up);

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

            
            // Apply jump force
            if (Jumped)
            {
                currentYVelocity = JumpHeight;
                Jumped = false;
            }

            // Set the velocity, preserving the vertical component
            PlayerRigidbody.velocity = new Vector3(movement.x, currentYVelocity, movement.z);
            return;
        }
        
        Vector3 strictMovement = new (0,0,MovementSpeed);
        if(Input.GetKey(KeyCode.D)) {
            strictMovement += new Vector3(MovementSpeed,0,0);
        }
        if(Input.GetKey(KeyCode.A)) {
            strictMovement += new Vector3(-MovementSpeed,0,0);
        }

        // Apply movement speed
        PlayerRigidbody.velocity = new Vector3(strictMovement.x, currentYVelocity, strictMovement.z);

        
        // Increase movementspeed with multiplier while it is below trehold
        if(MovementSpeed <= AutoRunMultiplierTreshold || AutoRunUseTreshold == false) {
            MovementSpeed += (float)((float) MovementSpeed * AutoRunMovementMultiplier);
        }
  
    }
}