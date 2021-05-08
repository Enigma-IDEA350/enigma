// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundSettings : MonoBehaviour, IPointerClickHandler
{
    public Sprite muteSound;
    public Sprite startSound;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // spriteRenderer.sprite = muteSound;
        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        addEventSystem();
        AudioListener.pause = false;
        spriteRenderer = gameObject.transform.Find("Sound Button").GetComponent<SpriteRenderer>();
        // if (spriteRenderer.sprite = null) {
        //     spriteRenderer.sprite = muteSound;
        // }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (spriteRenderer.sprite == muteSound)
        {
            spriteRenderer.sprite = startSound;
            AudioListener.pause = true;
        }
        else
        {
            spriteRenderer.sprite = muteSound;
            AudioListener.pause = false;
        }
    }

    //Add Event System to the Camera
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
