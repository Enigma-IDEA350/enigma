using System.Collections;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ComputerBoot : MonoBehaviour

{
    private AudioClip _startClip;
    private AudioClip _loopClip;
    //public float volume_of_boot;
    //public float volume_of_fan;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    IEnumerator PlaySound()
    {
        GetComponent<AudioSource>().volume = .12f;
        GetComponent<AudioSource>().clip = _startClip;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(_startClip.length);
        GetComponent<AudioSource>().clip = _loopClip;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().volume = .04f;
    }
}


