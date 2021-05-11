using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSounds : MonoBehaviour
{
    public bool correctAnswer;
    private bool soundPlayed;
    public bool clicked;
    public PlayButton playButton;
    public GameLogic gameLogic;

    private void Start()
    {

        gameLogic = FindObjectOfType<GameLogic>();
        correctAnswer = gameLogic.CorrectDecode;
        playButton = FindObjectOfType<PlayButton>();
        clicked = false;
        soundPlayed = false;
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(.4f);
        SoundManager.PlaySound(SoundManager.Sound.Winning);
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
            StartCoroutine(Win());
            soundPlayed = true;
        }

    }
}