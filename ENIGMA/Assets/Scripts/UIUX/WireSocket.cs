// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSocket : MonoBehaviour
{
    public bool correctAnswer;

    public SpriteRenderer wire;
    public SpriteRenderer socket;
    public float timeLeft;
    public Vector3 wireCopy;
    public Vector3 wireBounds;

    public Vector3 originalWireCopy;
    public Vector3 originalWireBounds;

    public Vector3 socketScale;
    public Vector3 socketBounds;

    public bool clicked;
    public bool transitionComplete;

    public bool blueWire;
    public bool yellowWire;
    public bool purpleWire;
    public bool greenWire;
    public bool redWire;
    public bool tutorialPurple;
    public bool yellowWire2;
    public bool redWire2;

    public AudioSource spark;
    public AudioSource plugged;

    public PlayButton playButton;
    public GameLogic gameLogic;

    public void Awake() 
    {
        wire = gameObject.transform.Find("Wire").GetComponent<SpriteRenderer>();
        socket = gameObject.transform.Find("Socket").GetComponent<SpriteRenderer>();
        timeLeft = 0.85f;
        clicked = false;
        transitionComplete = false;
        gameLogic = FindObjectOfType<GameLogic>();
        correctAnswer = gameLogic.CorrectDecode;

        playButton = FindObjectOfType<PlayButton>();

        originalWireCopy = wire.transform.position;
        socketScale = socket.transform.localScale;
        socketBounds = socket.sprite.bounds.max;

        spark = GameObject.Find("Spark").GetComponent<AudioSource>();
        plugged = GameObject.Find("Plugged").GetComponent<AudioSource>();
        
    }

    IEnumerator sparkSound()
    {
        yield return new WaitForSeconds(0);
        spark.Play();
    }

    IEnumerator pluggedSound()
        {
            yield return new WaitForSeconds(0.5f);
            plugged.Play();
        }

    // Update is called once per frame
    public void Update()
    {
        if (playButton.clicked == 1)
        {
            clicked = true;
            correctAnswer = gameLogic.CorrectDecode;
        }

        if (clicked && !transitionComplete) {
            wireCopy = wire.transform.position;
            wireBounds = wire.sprite.bounds.max;

            if (timeLeft <= Time.deltaTime)
            {
                wireCopy.y = socket.transform.position.y + socketScale.y * socketBounds.y - wire.transform.localScale.y * wireBounds.y;
                if (!redWire) wireCopy.x = socket.transform.position.x - socketScale.x * socketBounds.x + wire.transform.localScale.x * wireBounds.x;
                if (blueWire) wireCopy.x = socket.transform.position.x;
                if (greenWire) {
                    wireCopy.x = socket.transform.position.x - 0.9f * socketScale.x * socketBounds.x + wire.transform.localScale.x * wireBounds.x;
                }
                if (greenWire) wireCopy.y = socket.transform.position.y + 1.1f * socketScale.y * socketBounds.y - wire.transform.localScale.y * wireBounds.y;
                if (purpleWire) wireCopy.x = socket.transform.position.x + 0.5f * socketScale.x * socketBounds.x;
                if (redWire2) wireCopy.x = socket.transform.position.x + 0.9f * socketScale.x * socketBounds.x;
                if (redWire2) wireCopy.y = socket.transform.position.y + socketScale.y * socketBounds.y - 1.02f * wire.transform.localScale.y * wireBounds.y;
                if (yellowWire) wireCopy.x = socket.transform.position.x + socketScale.x * socketBounds.x;
                if (yellowWire) wireCopy.y = socket.transform.position.y + 2.0f * socketScale.y * socketBounds.y - wire.transform.localScale.y * wireBounds.y;
                if (tutorialPurple) wireCopy.x = socket.transform.position.x - 0.95f * socketScale.x * socketBounds.x + wire.transform.localScale.x * wireBounds.x;
                if (tutorialPurple) wireCopy.y = socket.transform.position.y + 0.8f * socketScale.y * socketBounds.y - wire.transform.localScale.y * wireBounds.y;
                if (redWire) wireCopy.y = socket.transform.position.y + 0.85f * socketScale.y * socketBounds.y - wire.transform.localScale.y * wireBounds.y;
                if (yellowWire2) wireCopy.y = socket.transform.position.y + 0.85f * socketScale.y * socketBounds.y - 0.99f * wire.transform.localScale.y * wireBounds.y;
                wire.transform.position = wireCopy;
                transitionComplete = true;
                timeLeft = 1.5f;
            }
            
            else if (timeLeft > 0.68f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (!redWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, 0.9f*(socket.transform.position.x - socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x),Time.deltaTime/timeLeft);
                if (blueWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x - 0.9f * socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 1.1f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y,Time.deltaTime/timeLeft);
                if (purpleWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + 0.5f * socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 2.0f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);                
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
                if (!correctAnswer)
                {
                    StartCoroutine(sparkSound());
                }
                if (correctAnswer)
                {
                    StartCoroutine(pluggedSound());
                }
            }   

            else if (timeLeft > 0.51f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (!redWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, 1.1f*(socket.transform.position.x - socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x),Time.deltaTime/timeLeft);
                if (blueWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x,Time.deltaTime/timeLeft);   
                if (greenWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x - 0.9f * socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 1.1f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y,Time.deltaTime/timeLeft);
                if (purpleWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + 0.5f * socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 2.0f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);             
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }  

            else if (timeLeft > 0.34f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (!redWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, 0.9f*(socket.transform.position.x - socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x),Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 2.0f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (blueWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x - 0.9f * socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 1.1f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y,Time.deltaTime/timeLeft);
                if (purpleWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + 0.5f * socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }  

            else {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (!redWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, 1.1f*(socket.transform.position.x - socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x),Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                if (yellowWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 2.0f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y, Time.deltaTime/timeLeft);
                if (blueWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x - 0.9f * socket.transform.localScale.x * socket.sprite.bounds.max.x + wire.transform.localScale.x * wireBounds.x,Time.deltaTime/timeLeft);
                if (greenWire) wireCopy.y = Mathf.Lerp(wire.transform.position.y, socket.transform.position.y + 1.1f * socket.transform.localScale.y * socket.sprite.bounds.max.y - wire.transform.localScale.y * wireBounds.y,Time.deltaTime/timeLeft);
                if (purpleWire) wireCopy.x = Mathf.Lerp(wire.transform.position.x, socket.transform.position.x + 0.5f * socket.transform.localScale.x * socket.sprite.bounds.max.x,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }
        }
        if (transitionComplete && !correctAnswer) 
        {
            if (timeLeft <= Time.deltaTime) {
                // transition complete
                wireCopy.y = originalWireCopy.y;
                wire.transform.position = originalWireCopy;
                transitionComplete = false;
                clicked = false;
                timeLeft = 0.85f;
            }
            else if (timeLeft > 0.85f) {
                timeLeft -= Time.deltaTime;
            }
            else if (timeLeft > 0.68f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, originalWireCopy.y, Time.deltaTime/timeLeft);
                wireCopy.x = Mathf.Lerp(wire.transform.position.x, wire.transform.position.x * 0.85f,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }   
            else if (timeLeft > 0.51f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, originalWireCopy.y, Time.deltaTime/timeLeft);
                wireCopy.x = Mathf.Lerp(wire.transform.position.x, wire.transform.position.x,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }  
            else if (timeLeft > 0.34f) {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, originalWireCopy.y, Time.deltaTime/timeLeft);
                wireCopy.x = Mathf.Lerp(wire.transform.position.x, wire.transform.position.x * 1.15f,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }  
            else {
                wireCopy.y = Mathf.Lerp(wire.transform.position.y, originalWireCopy.y, Time.deltaTime/timeLeft);
                wireCopy.x = Mathf.Lerp(wire.transform.position.x, wire.transform.position.x,Time.deltaTime/timeLeft);
                wire.transform.position = wireCopy;
                timeLeft -= Time.deltaTime;
            }
        }
    }
}

