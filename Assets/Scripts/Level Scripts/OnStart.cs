using System.Collections.Generic;
using UnityEngine;


public class OnStart : MonoBehaviour
{
    tutorialStart _tutorial;
    Message_SO _levelInfo;
    GameLogic _gameLogic;

    void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        Debug.Log(_gameLogic == null);
        _levelInfo = _gameLogic.MessageData;
        List<int> tutorialLevels = new List<int> { 1, 4 };
        _tutorial = gameObject.GetComponent<tutorialStart>();
        SoundManager.ComputerBoot();

        if (tutorialLevels.Contains(_levelInfo.CurrLevel))
        {
            List<string[]> groupOfMessages = new ListsOfMessages().getTutorialLevelDialogue(_levelInfo.CurrLevel);
            string[] initText = new ListsOfMessages().getinitTutorialLevelDialogue(_levelInfo.CurrLevel);
            _tutorial.tutorialInit(initText, groupOfMessages, _levelInfo.CurrLevel);
        }
        else
        {
            string[] levelDialogue = new ListsOfMessages().getLevelDialogue(_levelInfo.CurrLevel);
            _tutorial.regularInit(levelDialogue);
        }
    }

}
