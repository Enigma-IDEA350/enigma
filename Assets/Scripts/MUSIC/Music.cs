using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Music : MonoBehaviour
{
    //private AudioSource source;
    private GameObject[] GameMusic;
    public GamePlayMusic gamePlayMusic;
    private AudioSource source;
    private bool musicPlaying = false;

    private void Awake()
    {
        Music[] musics = FindObjectsOfType<Music>();
        if (musics.Length == 2)
        {
            gamePlayMusic.reset();
        }

        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();

        if (!gamePlayMusic.musicStarted)
        {
            source.Play();
            gamePlayMusic.startMusic();
        }
    }

    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "NEW__MAIN_MENU")
        {
            Debug.Log("In main menu");
            GameMusic = GameObject.FindGameObjectsWithTag("GameplayMusic");

            if (GameMusic.Length > 1)
            {
                //Destroy(GameMusic[1]);
                Destroy(GameMusic[0]);
                Destroy(GameMusic[1]);
            }
        }
    }

    public void PlayMusic()
    {
        if (source.isPlaying) return;
        source.Play();
    }

    public void StopMusic()
    {
        source.Stop();
    }
}