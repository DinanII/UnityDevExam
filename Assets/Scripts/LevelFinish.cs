using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelFinish : MonoBehaviour
{

    [SerializeField] public GameObject FinishPanel;
    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI SubTitle;
    [SerializeField] public Button NextLvlBtn;


    void Start() {
        FinishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }


    public void LoadNextLevel() {
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel < totalScenes) {
            SceneManager.LoadScene(nextLevel);
            return;
        }
        Title.text = "Congratulations!";
        SubTitle.text = "You Finished the game.";
        
    }


    public void OpenMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
