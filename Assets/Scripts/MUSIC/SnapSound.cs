using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSound : MonoBehaviour
{
    public GameObject BlockSnapSound;
    GameObject snapSoundInstance;
    bool ifAvailable = true;

    public bool button;
    // Start is called before the first frame update

    public void MakeSound()
    {
        snapSoundInstance = Instantiate(BlockSnapSound, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(snapSoundInstance, 1.0f);
    }


    private void Update()
    {
        if (button == true)
        {
            MakeSound();
            button = false;
        }

    }


}
