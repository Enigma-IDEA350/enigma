using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUnlockTest : MonoBehaviour
{
    public bool button = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button == true)
        {
            Debug.Log(levelProgress_SO.lvl2_unlocked);
            button = false;
        }
    }

    public LevelProgress_SO levelProgress_SO;


}
