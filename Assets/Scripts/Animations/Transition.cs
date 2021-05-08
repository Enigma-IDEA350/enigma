using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = .5f;

    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void LoadLevel(string levelName)
    {
        //StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(DelayLoadLevel(levelName));
    }

    IEnumerator DelayLoadLevel(string levelName)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(levelName);
    }
}  
