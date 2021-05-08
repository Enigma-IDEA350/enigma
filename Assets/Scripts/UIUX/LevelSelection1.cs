// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection1 : MonoBehaviour
{
    Transition transition;
    private void Start()
    {
        transition = FindObjectOfType<Transition>();
    }
    public void Level1()
    {

        transition.LoadLevel("Tutorial");
        //SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void Level2()
    {
        transition.LoadLevel("Level_2");
        //SceneManager.LoadScene("LEVEL 2", LoadSceneMode.Single);
    }

    public void Level3()
    {
        transition.LoadLevel("Level_3");
        //SceneManager.LoadScene("LEVEL 3", LoadSceneMode.Single);
    }
    public void Level4()
    {
        transition.LoadLevel("TUTORIAL 4");
        //SceneManager.LoadScene("TUTORIAL 4", LoadSceneMode.Single);
    }
    public void Level5()
    {
        transition.LoadLevel("Level_5");
        //SceneManager.LoadScene("level 5", LoadSceneMode.Single);
    }
    public void Level6()
    {
        transition.LoadLevel("Level_6");
        //SceneManager.LoadScene("level 6", LoadSceneMode.Single);
    }
    public void Level7()
    {
        transition.LoadLevel("Level_7");
        //SceneManager.LoadScene("level 7", LoadSceneMode.Single);
    }
    public void Level8()
    {
        transition.LoadLevel("Level_8");
        //SceneManager.LoadScene("level 8", LoadSceneMode.Single);
    }
    public void Level9()
    {
        transition.LoadLevel("Level_9");
        //SceneManager.LoadScene("level 9", LoadSceneMode.Single);
    }
}
