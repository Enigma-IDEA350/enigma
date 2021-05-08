using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private Animator _animator;
    private float _transitionDelayTime = .5f;

    void Awake()
    {
        _animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void LoadLevel(string levelName)
    {
        //StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(DelayLoadLevel(levelName));
    }

    IEnumerator DelayLoadLevel(string levelName)
    {
        _animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(_transitionDelayTime);
        SceneManager.LoadScene(levelName);
    }
}
