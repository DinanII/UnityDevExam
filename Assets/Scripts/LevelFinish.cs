using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{

    [SerializeField] public GameObject FinishPanel;


    void Start() {
        FinishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }


    public void LoadNextLevel() {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        print(nextLevel);
    }


    public void OpenMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
