// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    public SpriteRenderer topButton;
    public SpriteRenderer bottomButton;
    public float timeLeft;
    public Vector3 buttonCopy;
    public Vector3 buttonBounds;
    public Vector3 buttonOriginalLoc;
    public Vector3 buttonOriginalBounds;
    public int clicked;
    public bool complete;
    public GameLogic gameLogic;
    public List<WireSocket> wireSockets = new List<WireSocket>();
    public List<ButtonClicked> buttonClickeds = new List<ButtonClicked>();
    public LightManager lightManager;

    public float staticTimeLeft;


    WinProtocal winProtocal;

    public void Awake()
    {
        staticTimeLeft = 1.0f;
        topButton = gameObject.transform.Find("Top Button").GetComponent<SpriteRenderer>();
        buttonOriginalLoc = topButton.transform.position;
        buttonOriginalBounds = topButton.sprite.bounds.max;
        bottomButton = gameObject.transform.Find("Bottom Button").GetComponent<SpriteRenderer>();
        timeLeft = staticTimeLeft;
        clicked = 0;
        complete = false;
        wireSockets = new List<WireSocket>(FindObjectsOfType<WireSocket>());
        buttonClickeds = new List<ButtonClicked>(FindObjectsOfType<ButtonClicked>());
        lightManager = FindObjectOfType<LightManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        winProtocal = GetComponent<WinProtocal>();
        Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        addEventSystem();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    public void RunMachine()
    {
        gameLogic.TestMachine();
    }


    void Update()
    {
        if (clicked == 1)
        {
            buttonCopy = topButton.transform.position;
            buttonBounds = topButton.sprite.bounds.max;

            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                buttonCopy.y = bottomButton.transform.position.y + bottomButton.transform.localScale.y * bottomButton.sprite.bounds.max.y - topButton.transform.localScale.y * buttonBounds.y;
                topButton.transform.position = buttonCopy;
                complete = true;
                clicked = 2;
                timeLeft = staticTimeLeft;
            }
            else
            {
                buttonCopy.y = Mathf.Lerp(topButton.transform.position.y, bottomButton.transform.position.y + bottomButton.transform.localScale.y * bottomButton.sprite.bounds.max.y - topButton.transform.localScale.y * buttonBounds.y, Time.deltaTime / timeLeft);
                topButton.transform.position = buttonCopy;
                timeLeft -= Time.deltaTime;
            }
        }

        if (complete)
        {
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                buttonCopy.y = buttonOriginalLoc.y + bottomButton.transform.localScale.y * buttonOriginalBounds.y - topButton.transform.localScale.y * buttonBounds.y;
                topButton.transform.position = buttonCopy;
            }
            else
            {
                buttonCopy.y = Mathf.Lerp(topButton.transform.position.y, buttonOriginalLoc.y + bottomButton.transform.localScale.y * buttonOriginalBounds.y - topButton.transform.localScale.y * buttonBounds.y, Time.deltaTime / timeLeft);
                topButton.transform.position = buttonCopy;
                timeLeft -= Time.deltaTime;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (true) // (clicked == 0)
        {

            clicked = 1;
            complete = false;
            timeLeft = staticTimeLeft;
            RunMachine();
            lightManager.Update();
            foreach (WireSocket ws in wireSockets)
            {
                ws.Update();
            }
            foreach (ButtonClicked bc in buttonClickeds)
            {
                bc.Update();
            }

            if (gameLogic.CorrectDecode)
            {
                Debug.Log("era)/");
                winProtocal.Win();
                Debug.Log("you've won");
            }
            else { Debug.Log("erre"); }
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
