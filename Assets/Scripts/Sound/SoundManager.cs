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

    public static void PlayBackgroundMusic(Sound sound)
    {

    }
    public static void PlaySoundOnce(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = .4f;
        audioSource.PlayOneShot(GetAudioClip(sound));
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
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
