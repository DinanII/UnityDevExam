using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            KeyHolder keyHolder = other.gameObject.GetComponent<KeyHolder>();
            keyHolder.HasKey = true;
            Destroy(gameObject);
        }
    }
}
