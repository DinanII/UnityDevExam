using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelIncrementer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherObject) {
        if(otherObject.tag == "Player") {
            Debug.Log("Object with Player-Tag is touching the door");
            int index = SceneManager.GetActiveScene().buildIndex;
            // Scene scene = SceneManager.GetSceneByBuildIndex(Index++)
            SceneManager.LoadScene(index+1);
        }
    }
    
}
