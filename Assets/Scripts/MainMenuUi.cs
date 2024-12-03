using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("LevelSelectMenu");
    }

    public void Quit() {
        Application.Quit();
    }
}
