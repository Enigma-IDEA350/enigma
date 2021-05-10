using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSounds : MonoBehaviour
{
    public bool correctAnswer;
    private bool soundPlayed;
    Utils utils = new Utils();
    cycle cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();


    bool showChat = false;

    public bool clicked;
    public PlayButton playButton;
    public GameLogic gameLogic;
    private ListsOfMessages listsOfMessages = new ListsOfMessages();


    ChatBubble message;

    private void Start()
    {

        gameLogic = FindObjectOfType<GameLogic>();
        correctAnswer = gameLogic.CorrectDecode;
        playButton = FindObjectOfType<PlayButton>();
        clicked = false;
        soundPlayed = false;
        utils.setMono(this);


    }
    void Chat()
    {

        message = GameObject.Find("ChatBubble").GetComponent<ChatBubble>();
        message.begin(listsOfMessages.postArrowTutorial);
    }

    IEnumerator Win()
    {
        Debug.Log("Play sound");
        yield return new WaitForSeconds(.4f);
        SoundManager.PlaySound(SoundManager.Sound.Winning);
        utils.showChatBubble(cycle);
        Chat();
    }

    // Update is called once per frame
    void Update()
    {
        if (playButton.clicked == 1)
        {
            clicked = true;
            correctAnswer = gameLogic.CorrectDecode;
        }

        if (clicked && correctAnswer && !soundPlayed)
        {
            Debug.Log("Player Won");
            StartCoroutine(Win());
            soundPlayed = true;
        }

    }
}