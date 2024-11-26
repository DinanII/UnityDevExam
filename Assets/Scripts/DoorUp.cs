using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorUp : MonoBehaviour
{
    [SerializeField] GameObject LevelUpUi;
     private void OnTriggerEnter(Collider otherObject) {
        if(otherObject.tag == "Player") {
            Debug.Log("Object with Player-Tag is touching the door");
            KeyHolder keyHolder = otherObject.gameObject.GetComponent<KeyHolder>();
            if(keyHolder && keyHolder.HasKey == true) {
                // Scene scene = SceneManager.GetSceneByBuildIndex(Index++)
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                if(LevelUpUi != null) {
                    LevelUpUi.SetActive(true);
                }
            }


        }
    }
}
