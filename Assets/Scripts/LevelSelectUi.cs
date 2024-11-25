using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadDebugScene() {
        SceneManager.LoadScene("Debug");
    }

    public void LoadLevel0() {
        SceneManager.LoadScene("Level0");
    }
}
