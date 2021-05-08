using UnityEngine;

public class EndMusic : MonoBehaviour
{
    private void Awake()
    {
        Music[] musics = FindObjectsOfType<Music>();
        if (musics.Length == 2)
        {
            Destroy(musics[0].gameObject);
        }
    }
}
