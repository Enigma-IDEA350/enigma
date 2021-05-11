using System.Collections;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        MainMenuMusic,
        LevelSelectionMusic,
        ComputerBoot,
        ComputerFan,
        BlockSnap,
        LaptopClicking,
        Plugged,
        Pop,
        Spark,
        Winning,
        Dial
    }

    public static void PlayBackgroundMusic()
    {
        if (GameObject.Find("Bg Music") == null)
        {
            GameObject soundGameObject = new GameObject("Bg Music");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(Sound.LevelSelectionMusic);
            audioSource.volume = .1f;
            audioSource.Play();
            Object.DontDestroyOnLoad(soundGameObject);
        }

    }
    public static void PlaySound(Sound sound)
    {
        bool soundExists = false;
        AudioSource[] sounds = Object.FindObjectsOfType<AudioSource>();
        foreach (AudioSource item in sounds)
        {
            if (item.clip == GetAudioClip(sound)) { item.Play(); soundExists = true; }
        }
        if (!soundExists)
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = .7f;
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
        }
    }
    public static void StopSound(Sound sound)
    {
        AudioSource[] soundObjs = GameObject.FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in soundObjs)
        {
            if (audioSource.clip == GetAudioClip(sound))
            {
                audioSource.Stop();
            }
        }
    }

    public static IEnumerator ComputerBoot()
    {
        IEnumerator PlaySound()
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = .12f;
            audioSource.clip = GetAudioClip(Sound.ComputerBoot);
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.clip = GetAudioClip(Sound.ComputerFan);
            audioSource.Play();
            audioSource.loop = true;
            audioSource.volume = .04f;
        }
        return PlaySound();
    }

    public static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipsArray)
        {
            if (soundAudioClip.sound == sound) return soundAudioClip.audioClip;
        }
        return null;
    }
}
