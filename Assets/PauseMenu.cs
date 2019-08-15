using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject mainUI;

    private void Start()
    {
        Resume();
    }
    void Update (){
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
