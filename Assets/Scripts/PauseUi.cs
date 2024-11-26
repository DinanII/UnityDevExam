using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    public static bool IsGamePaused = false;
    [SerializeField] public GameObject PauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(IsGamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        Debug.Log("PauseUI: Resume");
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
        // Lock the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause() {
        Debug.Log("PauseUI: Pause");
        PauseMenuUi.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void OpenMainMenu() {
        Debug.Log("PauseUI: Main Menu"); // This log might not show if Time.timeScale is 0
        Debug.LogError("Main Menu called!"); // Try using LogError for more visibility
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Debug.LogError("Quit Game called!"); // Explicit error log
        Application.Quit();
    }
}
