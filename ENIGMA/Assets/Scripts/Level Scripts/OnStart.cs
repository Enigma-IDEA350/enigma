using System.Collections.Generic;
using UnityEngine;


public class OnStart : MonoBehaviour
{
    tutorialStart tutorial;
    Message_SO levelInfo;
    GameLogic gameLogic;

    void Start()
    {
        //levelInfo = GameObject.Find("GameLogic").GetComponent<GameLogic>().MessageData;

        gameLogic = FindObjectOfType<GameLogic>();
        Debug.Log(gameLogic == null);
        levelInfo = gameLogic.MessageData;
        List<int> tutorialLevels = new List<int> { 1, 4 };
        tutorial = gameObject.GetComponent<tutorialStart>();

        if (tutorialLevels.Contains(levelInfo.CurrLevel))
        {
            List<string[]> groupOfMessages = new ListsOfMessages().getTutorialLevelDialogue(levelInfo.CurrLevel);
            string[] initText = new ListsOfMessages().getinitTutorialLevelDialogue(levelInfo.CurrLevel);
            tutorial.tutorialInit(initText, groupOfMessages, levelInfo.CurrLevel);
        }
        else
        {
            string[] levelDialogue = new ListsOfMessages().getLevelDialogue(levelInfo.CurrLevel);
            tutorial.regularInit(levelDialogue);
        }
    }

}
