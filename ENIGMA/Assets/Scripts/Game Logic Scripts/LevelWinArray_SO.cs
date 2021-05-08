using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelState", menuName = "LevelState")]
public class LevelWinArray_SO : ScriptableObject
{
    public bool FirstReset = false;


    [SerializeField]
    private bool[] _LevelWinArray { get; set; } = new bool[9];

    public bool[] LevelWinArray { get => _LevelWinArray; }

    public void ResetLevels()
    {
        Debug.Log("gamestate");
        LevelWinArray[0] = true;
        for (int i = 1; i < 9; i++)
        {
            LevelWinArray[i] = false;
        }
    }

    public void BeatLevel(int i)
    {
        if (i<9) LevelWinArray[i] = true;
    }


}
