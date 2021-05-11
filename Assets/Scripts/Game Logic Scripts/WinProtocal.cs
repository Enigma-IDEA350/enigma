using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinProtocal : MonoBehaviour
{
    GameLogic _gameLogic;
    Utils _utils = new Utils();
    ListsOfMessages listsOfMessages = new ListsOfMessages();
    cycle cycle;

    public void Win()
    {
        _utils.setMono(this);
        StartCoroutine(ShowChat());
    }
    IEnumerator ShowChat()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        Message_SO levelInfo = _gameLogic.MessageData;
        List<int> tutorialLevels = new List<int> { 1, 4 };
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        yield return new WaitForSeconds(3f);
        _utils.showChatBubble(cycle);
        if (tutorialLevels.Contains(levelInfo.CurrLevel)) cycle.setText(listsOfMessages.winTutorial);
        else cycle.setText(listsOfMessages.winRegular);
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        yield return new WaitForSeconds(1.5f);
        _gameLogic.WonAndWaited = true;
    }
}
