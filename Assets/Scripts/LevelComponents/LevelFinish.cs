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


    void Start() {
        FinishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        //CheckLevelVadility();
    }



    public void LoadNextLevel() {
        Time.timeScale = 1f;
        FinishPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void OpenMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }


    // private void CheckLevelVadility() {
    //     if(NextLevel > TotalScenes) {
    //         Debug.Log("Updating text for last level...");
    //         NextLvlBtn.interactable = false;
    //         Title.text = "Congratulations!";
    //         SubTitle.text = "You Finished the game.";
    //         Debug.Log($"Title: {Title.text}, SubTitle: {SubTitle.text}");
    //     }
    // }
}
