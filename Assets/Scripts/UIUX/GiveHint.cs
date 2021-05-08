using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHint : MonoBehaviour
{
    ErrorHandler errorHandler;
    GameLogic GameLogic;
    Message_SO LevelData;

    // Start is called before the first frame update
    void Start()
    {
        errorHandler = GameObject.FindObjectOfType<ErrorHandler>();
        GameLogic = GameObject.FindObjectOfType<GameLogic>();
        LevelData = GameLogic.MessageData;

    }


    public void PassHint()
    {
        Debug.Log("fimil");
        RaiseHint(LevelData.hint);
    }

    private void RaiseHint(string hint)
    {
        errorHandler.RaiseError(hint);
    }
}
