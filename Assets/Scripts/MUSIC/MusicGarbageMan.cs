using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicGarbageMan : MonoBehaviour
{
    Scene scene;
    int cutoff = 1;

    void GrabMusic(int cutoff)
    {

        Music[] musics = FindObjectsOfType<Music>();
        if (musics.Length > cutoff) { Destroy(musics[cutoff].gameObject); }

    }


    public void DestoryFinal()
    {
        Music[] musics = FindObjectsOfType<Music>();
        foreach (Music music in musics)
        {
            Destroy(music);
        }
    }

    private void Update()
    {
        GrabMusic(cutoff);
        scene = SceneManager.GetActiveScene();
        if (scene.name == "EndWinScene") { cutoff = 0; } else { cutoff = 1; }
    }
}
