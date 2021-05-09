using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSounds : MonoBehaviour
{
    public bool correctAnswer;
    private bool soundPlayed;
    Utils utils = new Utils();

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


    }
    IEnumerator Chat()
    {
        yield return new WaitForSeconds(3f);
        message = GameObject.Find("ChatBubble").GetComponent<ChatBubble>();
        message.begin(listsOfMessages.postArrowTutorial);
    }

    IEnumerator Win()
    {
        Debug.Log("Play sound");
        yield return new WaitForSeconds(.4f);
        SoundManager.PlaySoundOnce(SoundManager.Sound.Winning);
        showChat = true;
        StartCoroutine(Chat());
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
        if (showChat) { utils.showChatBubble(); }

    }
}