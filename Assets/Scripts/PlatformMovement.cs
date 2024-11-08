using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] Vector3 objectMovement = new();
    [SerializeField] float movementSpeed = 500f;
    Transform transform;
    bool moved = false;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.position += Vector3.Lerp(transform.position, objectMovement, Time.deltaTime * 5);
        
        transform.position -= Vector3.Lerp(transform.position, objectMovement, Time.deltaTime * 5);
        // rigidBody.AddForce(objectMovement * movementSpeed,ForceMode.VelocityChange);
        // rigidBody.AddForce(-objectMovement,ForceMode.VelocityChange);
    }

}
