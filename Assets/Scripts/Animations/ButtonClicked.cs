using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public Animator m_Animator;
    public float timer;
    public bool timerReached;
    public bool animated;

    public PlayButton playButton;
    public GameLogic gameLogic;
    public WireSocket wireSocket;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        timer = 0f;
        timerReached = false;
        animated = false;
        playButton = FindObjectOfType<PlayButton>();
        gameLogic = FindObjectOfType<GameLogic>();
        wireSocket = FindObjectOfType<WireSocket>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (playButton != null)
        {
            if (playButton.clicked == 1)
            {                
                if (gameLogic.CorrectDecode)
                {
//                    Debug.Log("tsun");
                    m_Animator.Play("Base Layer.Move Wire");
                }
                if (!gameLogic.CorrectDecode) {
                    m_Animator.SetBool("ButtonClicked", true);
                    m_Animator.Play("Base Layer.Move Wire 1");                   
                }
                //m_Animator.SetFloat("Direction", 1.5f);

                //animated = true;
                //m_Animator.SetBool("ButtonClicked", true);

                //animated = false;
            }
        }
    }
}
