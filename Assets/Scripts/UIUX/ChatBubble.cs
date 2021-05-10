// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class ChatBubble : MonoBehaviour
{
    public SpriteRenderer backgroundSpriteRenderer; // text box bg
    public TMP_Text tmp; // text
    private ChatManager.ChatManagerInstance chatManagerInstance; // functionality for chat bubble
    public GameLogic gameLogic;
    public int sceneNumber;
    public int currMessageIndex;
    public bool clicked;
    public float speed;

    public void Awake()
    // grab components
    {
        backgroundSpriteRenderer = gameObject.transform.Find("Background").GetComponent<SpriteRenderer>();
        tmp = gameObject.transform.Find("Text").GetComponent<TMP_Text>();
        clicked = false;
        speed = 0.05f;
    }

    public void Start()
    // start
    {
        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        addEventSystem();
        gameLogic = FindObjectOfType<GameLogic>();
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        currMessageIndex = 0;
    }

    public void begin(string[] messages)
    {
        currMessageIndex = 0;
        chatManagerInstance = ChatManager.AddWriterStatic(tmp, messages[currMessageIndex], speed, false, true, stopSound, true);
        startSound();
    }

    public void messageAtIndex(string[] messages, int index)
    {
        currMessageIndex = index;
        chatManagerInstance = ChatManager.AddWriterStatic(tmp, messages[currMessageIndex], speed, false, true, stopSound, true);
        startSound();
    }
    public void previousMessage(string[] messages)
    {

        if (currMessageIndex != 0)
        {
            currMessageIndex -= 1;
            chatManagerInstance = ChatManager.AddWriterStatic(tmp, messages[currMessageIndex], speed, false, true, stopSound, true);
            startSound();
        }
    }

    public void nextMessage(string[] messages)
    {
        if (currMessageIndex + 1 < messages.Length)
        {
            currMessageIndex += 1;
            chatManagerInstance = ChatManager.AddWriterStatic(tmp, messages[currMessageIndex], speed, false, true, stopSound, true);
            startSound();
        }
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


    public void Update()
    {
        if (clicked)
        {
            Debug.Log("Clicked");
            clicked = false;
        }
    }

    private void stopSound()
    // stop playing sound
    {
        SoundManager.StopSound(SoundManager.Sound.LaptopClicking);
    }

    private void startSound()
    // play sound
    {
        SoundManager.PlaySound(SoundManager.Sound.LaptopClicking);
    }

    public void Setup(string text)
    // function to manually change text in bubble without typewriter effect
    {
        tmp.SetText(text);
        tmp.ForceMeshUpdate();
        Vector2 textSize = tmp.GetRenderedValues(false);
        Vector2 padding = new Vector2(4f, 2f);
        backgroundSpriteRenderer.size = textSize + padding; // to be tweaked with chat bubble bg
    }
}
