using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    PlayerMovement PlayerScript;
    [SerializeField] float Sensitivity = 120f;
    [SerializeField] float MaxVerticalAngle = 80f;
    [SerializeField] Vector3 Offset = new Vector3(0, 5, -10); 

    private float Pitch = 0f; 
    private float Yaw = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player = GameObject.Find("Player");
        PlayerScript = Player.GetComponent<PlayerMovement>();

    }

    void Update()
    {
        if(!PlayerScript.AutoRun) {
            MouseMovement();
            UpdateCameraPosition();
        }
    }

    void MouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        Yaw += mouseX;
        Pitch -= mouseY;

        Pitch = Mathf.Clamp(Pitch, -MaxVerticalAngle, MaxVerticalAngle);
    }

    void UpdateCameraPosition()
    {
        // Rotate offset based on mouse movement
        Quaternion rotation = Quaternion.Euler(Pitch, Yaw, 0f);
        Vector3 rotatedOffset = rotation * Offset;

        // Set camera position relative to player
        transform.position = Player.transform.position + rotatedOffset;
        transform.LookAt(Player.transform.position);
    }
}