// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused; // static bool to make it global and usable in other scripts to block input
    // Start is called before the first frame update
    public PauseButton pauseButton;

    void Start()
    {
        pauseMenu.SetActive(false);
        pauseButton = FindObjectOfType<PauseButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // escape key to trigger pause menu
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (pauseButton.isClicked) // click on pause button triggers pause menu
        {
            PauseGame();
            pauseButton.isClicked = false;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // stop all animations
        isPaused = true; // set global bool
        AudioListener.pause = true; // stop sounds
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
