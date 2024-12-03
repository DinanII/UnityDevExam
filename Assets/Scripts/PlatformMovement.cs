using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] Vector3 pointB = new(0,0,0);
    [SerializeField] float movementSpeed = 2f;
    Vector3 startPos;
    private new Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        startPos = transform.position;
        // Replace pointB positions with start positions if pointB value is 0
        // (Was looking for something like this: pointB.x == 0 ? pointB.x = startPos.x : pass / do nothing;, but ended up with the setup below.)
        pointB.x = (pointB.x == 0) ? startPos.x : pointB.x;
        pointB.y = (pointB.y == 0) ? startPos.y : pointB.y;
        pointB.z = (pointB.z == 0) ? startPos.z : pointB.z;

    }

    // When player lands on platform, set the platform temporarily as a parent.
    private void OnCollisionEnter(Collision otherObject) {
        if(otherObject.gameObject.CompareTag("Player")) {

            otherObject.transform.SetParent(transform);
        }
    }
    // When player leaves, unparent the player.
    private void OnCollisionExit(Collision otherObject) {
        // Check if the player is leaving the platform
        if (otherObject.gameObject.CompareTag("Player"))
        {
            // Reset the player's parent to null
            otherObject.transform.SetParent(null);
        }
    }

    // FixedUpdate is called 50 times a frame
    void FixedUpdate() {
        // Move to the player forward and back 
        float time = Mathf.PingPong(Time.time * movementSpeed,1);
        transform.position = Vector3.Lerp(startPos,pointB,time);
    }


}
