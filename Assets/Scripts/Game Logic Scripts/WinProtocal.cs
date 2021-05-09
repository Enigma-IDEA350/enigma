using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinProtocal : MonoBehaviour
{
    public GameLogic gameLogic;

    public void Win()
    {
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1.5f);
        gameLogic.WonAndWaited = true;
    }
}
