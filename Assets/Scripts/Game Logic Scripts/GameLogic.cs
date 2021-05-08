using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Threading;

//main driver for game logic also oops the maping and foreach stuff should
//obviously be in a dif script, but too late to refactor :D


public class GameLogic : MonoBehaviour
{
    public LevelWinArray_SO levelState;

    ErrorHandler errorHandler;
    BlockButtonGreyout blockButtonGreyout;
    Transition transition;
    public TextMeshProUGUI InputField;
    public TextMeshProUGUI OutputField;
    public Message_SO MessageData;
    ForEachBlock[] ForEachBlocks;
    ForEachBlock ForEachBlock;

    private bool blockErrors = false;
    public bool CorrectDecode = false;

    public string potentialMessage;

    public bool wonAndWaited;

    public bool Button = false;

    public bool editOutputText = false;

    public char[] letters;
    public float timer = 0f;
    public float timePerChar = 0.05f;
    public int charIndex;
    string text = "";

    public bool complete = false;

    public void Start()
    {
        transition = FindObjectOfType<Transition>();
        errorHandler = GameObject.FindObjectOfType<ErrorHandler>();
        blockButtonGreyout = GetComponent<BlockButtonGreyout>();
        InputField.text = MessageData.Code;
        OutputField.text = "";
        //MessageData.Decode_Attempt = "";

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
        if (editOutputText)
        {
            timer -= 0.1f;
            while (charIndex < potentialMessage.Length && timer <= 0f)
            {
                timer += 0.5f;
                charIndex++;
                string text = potentialMessage.Substring(0, charIndex);
                for (int i = 0; i < potentialMessage.Length - charIndex; i++)
                {
                    if (potentialMessage.Substring(charIndex + i, 1) == " ")
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
            if (charIndex == potentialMessage.Length)
            {
                complete = true;
                editOutputText = false;
                charIndex = 0;
            }
        }


        Debug.Log(complete);
        if (wonAndWaited) //&& complete)
        {
            if (MessageData.CurrLevel == 9)
            {

                if (Input.anyKey)
                {
                    Debug.Log("asdffdas");
                    levelState.BeatLevel(MessageData.CurrLevel);
                    transition.LoadLevel("EndWinScene");
                }
                //else
                //{
                //    Debug.Log(transition == null);
                //    transition.LoadLevel("LevelSelection");
                //}
            }
            else
            {
                Debug.Log("fart");
                levelState.BeatLevel(MessageData.CurrLevel);
                if (Input.anyKey)
                {
                    Debug.Log(transition == null);
                    transition.LoadLevel("LevelSelection");
                    //SceneManager.LoadScene("LevelSelectionn");
                }
            }
        }
        else
        {
            complete = false;
        }

    }



    public void BlockError()
    {
        blockErrors = true;
    }

    public void RaiseError(string error)
    {
        blockErrors = true;
        errorHandler.RaiseError(error);
    }

    public void TestMachine()
    {
        blockErrors = false;
        ForEachBlocks = GameObject.FindObjectsOfType<ForEachBlock>();

        //cases for wrong number of blocks
        if (ForEachBlocks.Length > 1)
        {
            RaiseError("There are too many FOR blocks");
            MessageData.Decode_Attempt = "";
        }
        else if (ForEachBlocks.Length == 0)
        {
            RaiseError("You need a FOR block");
            MessageData.Decode_Attempt = "";
        }

        //case for only one for eache
        else
        {
            ForEachBlock = ForEachBlocks[0];


            if (ForEachBlock.ReadblockExists)
            {
                //MessageData.Decode_Attempt = ForEachBlock.TestMap(MessageData.Code, 0, 6);
                potentialMessage = ForEachBlock.Map(MessageData.Code);
                if (!blockErrors)
                {
                    editOutputText = true;
                    MessageData.Decode_Attempt = potentialMessage;
                }
                else
                {
                    MessageData.Decode_Attempt = "";
                }
            }
            else
            {

                errorHandler.RaiseError("You are missing a WRITE block");
                MessageData.Decode_Attempt = "";
            }
            OutputField.text = MessageData.Decode_Attempt;
            if (MessageData.Decode_Attempt.ToLower() == MessageData.CorrectText.ToLower())
            {
                CorrectDecode = true;
            }
        }
    }
}
