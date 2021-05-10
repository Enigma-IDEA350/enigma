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
        ShowChat();
    }
    void ShowChat()
    {
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        Debug.Log(cycle);
        _utils.showChatBubble(cycle);
        cycle.setText(listsOfMessages.postArrowTutorial);
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        yield return new WaitForSeconds(1.5f);
        _gameLogic.WonAndWaited = true;
    }
}
