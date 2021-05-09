using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Threading;

//main driver for game logic 


public class GameLogic : MonoBehaviour
{
    public LevelWinArray_SO levelState;

    public ErrorHandler errorHandler;
    BlockButtonGreyout blockButtonGreyout;
    Transition transition;
    public TextMeshProUGUI InputField;
    public TextMeshProUGUI OutputField;
    public Message_SO MessageData;

    public bool CorrectDecode { get; set; } = false;

    public string PotentialMessage { get; set; } = "";

    public bool WonAndWaited { get; set; }

    public bool Button = false;

    public bool editOutputText = false;

    public char[] letters;
    private float _timer { get; set; } = 0f;
    private int _charIndex { get; set; }

    private RunMachine _runMachine;

    private bool _complete = false;

    public void Start()
    {
        transition = FindObjectOfType<Transition>();
        errorHandler = FindObjectOfType<ErrorHandler>();
        blockButtonGreyout = GetComponent<BlockButtonGreyout>();
        _runMachine = GetComponent<RunMachine>();
        
        InputField.text = MessageData.Code;
        OutputField.text = "";
        letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        

        //setting the maker blocks to on or off based on our scriptable object
        blockButtonGreyout.ForeachOn(MessageData.ForOn);
        blockButtonGreyout.IfOn(MessageData.IfOn);
        blockButtonGreyout.SwitchOn(MessageData.SwitchOn);
        blockButtonGreyout.ShiftOn(MessageData.ShiftOn);
        blockButtonGreyout.ReadOn(MessageData.ReadOn);

    }


    private void FixedUpdate()
    {
        TextDisplay();
        Win();

    }

    private void Win()
    {
        if (WonAndWaited)
        {
            if (MessageData.CurrLevel == 9)
            {

                if (Input.anyKey)
                {
                    levelState.BeatLevel(MessageData.CurrLevel);
                    transition.LoadLevel("EndWinScene");
                }
            }
            else
            {
                levelState.BeatLevel(MessageData.CurrLevel);
                if (Input.anyKey)
                {
                    Debug.Log(transition == null);
                    transition.LoadLevel("LevelSelection");
                }
            }
        }
        else
        {
            _complete = false;
        }
    }


    //tsun code
    private void TextDisplay()
    {
        if (editOutputText)
        {
            _timer -= 0.1f;
            Debug.Log(PotentialMessage == null);
            while (_charIndex < PotentialMessage.Length && _timer <= 0f)
            {
                _timer += 0.5f;
                _charIndex++;
                string text = PotentialMessage.Substring(0, _charIndex);
                for (int i = 0; i < PotentialMessage.Length - _charIndex; i++)
                {
                    if (PotentialMessage.Substring(_charIndex + i, 1) == " ")
                    {
                        text += " ";
                    }
                    else
                    {
                        text += letters[UnityEngine.Random.Range(0, letters.Length)];
                    }
                }
                // text = "<mspace=2.5>" + text + "</mspace>";
                OutputField.text = text;
            }
            if (_charIndex == PotentialMessage.Length)
            {
                _complete = true;
                editOutputText = false;
                _charIndex = 0;
            }
        }
    }

    public void RaiseError(string error)
    {
        errorHandler.raiseError(error);
        _runMachine.BlockErrors = true;
    }

    public void TestMachine()
    {
        _runMachine.TestMachine();
    }
}
