using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocking : MonoBehaviour
{
    public LevelProgress_SO levelProgress_SO;
    public LevelWinArray_SO levelWinArray_SO;


    public GameObject tutorial1;
    public GameObject level2;
    public GameObject level3;
    public GameObject tutorial4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    public GameObject level8;
    public GameObject level9;

    public bool level3Unlocked = false;

    private void Update()
    {
        //tutorial1.SetActive(levelProgress_SO.tut1_unlocked);
        //level2.SetActive(levelProgress_SO.lvl2_unlocked);
        //level3.SetActive(levelProgress_SO.lvl3_unlocked);
        //tutorial4.SetActive(levelProgress_SO.tut4_unlocked);
        //level5.SetActive(levelProgress_SO.lvl5_unlocked);
        //level6.SetActive(levelProgress_SO.lvl6_unlocked);
        //level7.SetActive(levelProgress_SO.lvl7_unlocked);
        //level8.SetActive(levelProgress_SO.lvl8_unlocked);
        //level9.SetActive(levelProgress_SO.lvl9_unlocked);

        tutorial1.SetActive(true);
        level2.SetActive(levelWinArray_SO.LevelWinArray[1]);
        level3.SetActive(levelWinArray_SO.LevelWinArray[2]);
        tutorial4.SetActive(levelWinArray_SO.LevelWinArray[3]);
        level5.SetActive(levelWinArray_SO.LevelWinArray[4]);
        level6.SetActive(levelWinArray_SO.LevelWinArray[5]);
        level7.SetActive(levelWinArray_SO.LevelWinArray[6]);
        level8.SetActive(levelWinArray_SO.LevelWinArray[7]);
        level9.SetActive(levelWinArray_SO.LevelWinArray[8]);

        if (levelProgress_SO.lvl3_unlocked)
        {
            level3Unlocked = true;
        }
    }
}
