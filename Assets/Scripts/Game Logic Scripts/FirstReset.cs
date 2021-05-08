using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstReset : MonoBehaviour
{

    public LevelWinArray_SO levelWinArray_SO;
    // Start is called before the first frame update
    void Start()
    {
            levelWinArray_SO.ResetLevels();       
    }

}
