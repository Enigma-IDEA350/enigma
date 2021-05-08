// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(2); // level selection 
    }

    public void Credits()
    {
        SceneManager.LoadScene(0); 
    }

    public void Quit()
    {
        Application.Quit(); // quit duh
    }
}
