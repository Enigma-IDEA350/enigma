// Tsun Lok Kwan
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpriteButton : MonoBehaviour, IPointerClickHandler
{
    public Transition transition;
    public Animator animator;


    void Start()
    {
        //Attach Physics2DRaycaster to the Camera
        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        addEventSystem();
        animator = GameObject.Find("Transition").GetComponent<Animator>();
        transition = GameObject.FindObjectOfType<Transition>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.PlaySoundOnce(SoundManager.Sound.BlockSnap);

        transition.LoadLevel("LevelSelection");
        //SceneManager.LoadScene("LevelSelection");
    }
    void addEventSystem()
    {
        GameObject eventSystem = null;
        GameObject tempObj = GameObject.Find("EventSystem");
        if (tempObj == null)
        {
            eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        else
        {
            if ((tempObj.GetComponent<EventSystem>()) == null)
            {
                tempObj.AddComponent<EventSystem>();
            }

            if ((tempObj.GetComponent<StandaloneInputModule>()) == null)
            {
                tempObj.AddComponent<StandaloneInputModule>();
            }
        }
    }

}