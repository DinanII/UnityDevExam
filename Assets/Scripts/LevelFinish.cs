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


    private int TotalScenes = SceneManager.sceneCountInBuildSettings;
    private int NextLevel = SceneManager.GetActiveScene().buildIndex + 1;


    void Start() {
        FinishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        CheckLevelVadility();
    }

    private void CheckLevelVadility() {
        if(NextLevel > TotalScenes) {
            NextLvlBtn.interactable = false;
            Title.text = "Congratulations!";
            SubTitle.text = "You Finished the game.";
        }

    }
    public void LoadNextLevel() {
        if(NextLevel < TotalScenes) {
            SceneManager.LoadScene(NextLevel);
            return;
        }
    }


    public void OpenMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
