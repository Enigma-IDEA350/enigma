using UnityEngine;

public class BacktoMainMenu : MonoBehaviour
{
    private Transition _transition;
    public Animator _animator;

    void Start()
    {
        _animator = GameObject.Find("Transition").GetComponent<Animator>();
        _transition = GameObject.FindObjectOfType<Transition>();
    }

    public void LoadMainMenu()
    {
        _transition.LoadLevel("NEW__MAIN_MENU");
    }
}
