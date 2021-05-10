using System;
using UnityEngine;

public class next : MonoBehaviour
{

    cycle cycle;
    Action transtion;

    public void setTranstion(Action newTranstion) { transtion = newTranstion; }
    public void triggerNext() { cycle.Next(transtion); }

    void Start()
    {
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
    }

    void OnMouseDown()
    {
        AudioSource[] sounds = GameObject.FindObjectsOfType<AudioSource>();
        bool isTyping = false;
        foreach (AudioSource sound in sounds)
        {
            if (sound.clip == SoundManager.GetAudioClip(SoundManager.Sound.LaptopClicking))
            {
                isTyping = sound.isPlaying ? true : false;
            }
        }
        if (!isTyping) cycle.Next(transtion);
    }
}
