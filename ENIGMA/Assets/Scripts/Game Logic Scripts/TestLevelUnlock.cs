using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelUnlock : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelProgress_SO levelProgress_SO;
    public bool button = false;
    private void Update()
    {
        if (button)
        {
            PrintLevels();
        }
        button = false;
    }

    private void PrintLevels()
    {
        Debug.Log(levelProgress_SO.lvl2_unlocked);
        Debug.Log(levelProgress_SO.lvl3_unlocked);
        Debug.Log(levelProgress_SO.lvl5_unlocked);
        Debug.Log(levelProgress_SO.lvl6_unlocked);
        Debug.Log(levelProgress_SO.lvl7_unlocked);
        Debug.Log(levelProgress_SO.lvl8_unlocked);
    }
}
