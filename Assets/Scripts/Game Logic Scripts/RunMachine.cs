using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
runs the for each, theo

TEST
*/
public class RunMachine : MonoBehaviour
{
    public bool BlockErrors = false;
    private ForEachBlock[] forEachBlocks { get; set; }
    ForEachBlock ForEachBlock;
    ErrorHandler errorHandler;

    private TextMeshProUGUI outputField;

    private GameLogic gameLogic;


    private void Start()
    {
        gameLogic = GetComponent<GameLogic>();
    }

    public void TestMachine()
    {
        outputField = gameLogic.OutputField;
        errorHandler = gameLogic.errorHandler;

        BlockErrors = false;
        forEachBlocks = GameObject.FindObjectsOfType<ForEachBlock>();

        if (forEachBlocks.Length > 1)
        {
            RaiseError("There are too many FOR blocks");
            gameLogic.MessageData.Decode_Attempt = "";
        }
        else if (forEachBlocks.Length == 0)
        {
            RaiseError("You need a FOR block");
            gameLogic.MessageData.Decode_Attempt = "";
        }

        else
        {
            ForEachBlock = forEachBlocks[0];
            if (ForEachBlock.ReadblockExists)
            {
                string potentialMessage = ForEachBlock.Map(gameLogic.MessageData.Code);
                if (!BlockErrors)
                {
                    gameLogic.editOutputText = true;
                    gameLogic.MessageData.Decode_Attempt = potentialMessage;
                }
                else
                {
                    gameLogic.MessageData.Decode_Attempt = "";
                }
            }
            else
            {
                errorHandler.RaiseError("You are missing a WRITE block");
                gameLogic.MessageData.Decode_Attempt = "";
            }
            outputField.text = gameLogic.MessageData.Decode_Attempt;
            if (gameLogic.MessageData.Decode_Attempt.ToLower() == gameLogic.MessageData.CorrectText.ToLower())
            {
                gameLogic.CorrectDecode = true;
            }
        }
    }


    public void RaiseError(string error)
    {
        BlockErrors = true;
        errorHandler.RaiseError(error);
    }
}
