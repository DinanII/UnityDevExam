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


    private int TotalScenes = 0;
    private int NextLevel = 0;


    void Start() {
        TotalScenes = SceneManager.sceneCountInBuildSettings;
        NextLevel = SceneManager.GetActiveScene().buildIndex + 2;

        Debug.Log($"Active Scene Name: {SceneManager.GetActiveScene().name}");
        Debug.Log($"Active Scene Index: {SceneManager.GetActiveScene().buildIndex}");
        Debug.Log($"Total Scenes in Build Settings: {TotalScenes}");
        Debug.Log($"Next Level Index: {NextLevel}");

        FinishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        CheckLevelVadility();
    }

    private void CheckLevelVadility() {
        if(NextLevel > TotalScenes) {
            Debug.Log("Updating text for last level...");
            NextLvlBtn.interactable = false;
            Title.text = "Congratulations!";
            SubTitle.text = "You Finished the game.";
            Debug.Log($"Title: {Title.text}, SubTitle: {SubTitle.text}");
        }

    }
    public void LoadNextLevel() {
        if(NextLevel < TotalScenes) {
            Time.timeScale = 1f;
            FinishPanel.SetActive(false);
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
