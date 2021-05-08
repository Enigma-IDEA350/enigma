using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ComputerBoot : MonoBehaviour

{
    public AudioClip StartClip;
    public AudioClip LoopClip;
    //public float volume_of_boot;
    //public float volume_of_fan;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
    }

    // Update is called once per frame
    IEnumerator playSound()
    {
        GetComponent<AudioSource>().volume = .12f;
        GetComponent<AudioSource>().clip = StartClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(StartClip.length);
        GetComponent<AudioSource>().clip = LoopClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().volume = .04f;
    }
}


