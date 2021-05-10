using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.MainMenuMusic);
        SoundManager.PlaySound(SoundManager.Sound.LaptopClicking);
        try
        {
            Destroy(GameObject.Find("Background Music"));
        }
        catch
        {
            throw;
        }
    }
}
