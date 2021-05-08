using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Music : MonoBehaviour
{
    //private AudioSource source;
    private GameObject[] _gameMusic;
    public GamePlayMusic _gamePlayMusic;
    private AudioSource _source;
    private bool _musicPlaying = false;

    private void Awake()
    {
        Music[] musics = FindObjectsOfType<Music>();
        if (musics.Length == 2)
        {
            _gamePlayMusic.reset();
        }

        DontDestroyOnLoad(gameObject);
        _source = GetComponent<AudioSource>();

        if (!_gamePlayMusic.musicStarted)
        {
            _source.Play();
            _gamePlayMusic.startMusic();
        }
    }

    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "NEW__MAIN_MENU")
        {
            Debug.Log("In main menu");
            _gameMusic = GameObject.FindGameObjectsWithTag("GameplayMusic");

            if (_gameMusic.Length > 1)
            {
                //Destroy(GameMusic[1]);
                Destroy(_gameMusic[0]);
                Destroy(_gameMusic[1]);
            }
        }
    }

    public void PlayMusic()
    {
        if (_source.isPlaying) return;
        _source.Play();
    }

    public void StopMusic()
    {
        _source.Stop();
    }
}