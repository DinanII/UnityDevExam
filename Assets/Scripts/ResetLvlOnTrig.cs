using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DamagePlayerOnColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Player touched Enemy");
        }
    }
}
