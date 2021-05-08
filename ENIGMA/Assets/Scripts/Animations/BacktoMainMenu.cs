using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMainMenu : MonoBehaviour
{
    public Transition transition;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
        transition = GameObject.FindObjectOfType<Transition>();
    }

    public void LoadMainMenu()
    {
        Debug.Log("go to main menu");
        transition.LoadLevel("NEW__MAIN_MENU");
    }
}
