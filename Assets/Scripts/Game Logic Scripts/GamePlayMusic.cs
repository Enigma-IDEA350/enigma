using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicControl", menuName = "MusicControl")]
public class GamePlayMusic : ScriptableObject
{
    public bool musicStarted { get; private set; } = false;

    public void startMusic()
    {
        if (!musicStarted)
        {
            musicStarted = true;
        }
    }
    public void reset()
    {
        musicStarted = false;

    }

}
