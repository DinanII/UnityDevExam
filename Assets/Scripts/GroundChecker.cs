using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded;

    void OnTriggerEnter(Collider otherObject) {
        if(otherObject.tag == "Floor") {
            IsGrounded = true;
        }
    }

    void OnTriggerExit(Collider otherObject) {
        if(otherObject.tag == "Floor") {
            IsGrounded = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
