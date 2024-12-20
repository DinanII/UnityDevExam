using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float JumpHeight = 5f;
    [SerializeField] public bool AutoRun;
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

            // Preserve the vertical velocity
            float verticalVelocity = PlayerRigidbody.velocity.y;

            // Apply jump force
            if (Jumped)
            {
                verticalVelocity = JumpHeight;
                Jumped = false;
            }

            // Set the velocity, preserving the vertical component
            PlayerRigidbody.velocity = new Vector3(movement.x, verticalVelocity, movement.z);
            return;
        }

        // Separate movement logic
        Vector3 strictMovement = new (0,0,MovementSpeed);
        if(Input.GetKey(KeyCode.D)) {
            strictMovement += new Vector3(MovementSpeed,0,0);
        }
        if(Input.GetKey(KeyCode.A)) {
            strictMovement += new Vector3(-MovementSpeed,0,0);
        }
        PlayerRigidbody.velocity = strictMovement;
        if(MovementSpeed <= 20) {
            MovementSpeed += (float)((float) MovementSpeed * 0.01);
        }
  
    }
}