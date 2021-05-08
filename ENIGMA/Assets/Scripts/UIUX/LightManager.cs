// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static List<LightChanger.LightInstance> lightInstances = new List<LightChanger.LightInstance>();
    public PlayButton playButton;
    public GameLogic gameLogic;
    public bool pulse;
    public int pulseRepetition;
    public bool green;


    // void Awake()
    // {
    //     if(Instance){
    //         DestroyImmediate(gameObject);
    //     }else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //         Instance = this;
    //     }
    // }
    void Awake()
    {
        lightInstances = new List<LightChanger.LightInstance>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playButton = FindObjectOfType<PlayButton>();
        gameLogic = FindObjectOfType<GameLogic>();
        pulse = false;
        pulseRepetition = 0;
        green = false;
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < lightInstances.Count; i++)
        {
            lightInstances[i].Update();
        }

        pulseRepetition = lightInstances[0].pulseRepetition;

        if (!green && pulseRepetition > 6)
        {
            pulseColor(false);
        }

        if (playButton != null)
        {
            if (playButton.clicked == 1)
            {
                if (gameLogic.CorrectDecode)
                // if correctly decoded and clicked
                {
                    for (int i = 0; i < lightInstances.Count; i++)
                    {
                        lightInstances[i].setPulseRepetition(0);
                    }
                    setColor(Color.green);
                    green = true;
                }
                else
                // if incorrectly decoded and clicked
                {
                    for (int i = 0; i < lightInstances.Count; i++)
                    {
                        lightInstances[i].setPulseRepetition(0);
                    }
                    setColor(Color.red);
                }
                pulse = true;
            }
        }
        if (pulse && pulseRepetition == 0)
        {
            pulseColor(true);
        }

    }

    void setColor(Color targetColor)
    {
        for (int i = 0; i < lightInstances.Count; i++)
        {
            lightInstances[i].setTime(2.0f);
            lightInstances[i].setKeepGoing(false);
            lightInstances[i].setColor(targetColor);
        }
    }

    void pulseColor(bool pulse)
    {
        for (int i = 0; i < lightInstances.Count; i++)
        {
            lightInstances[i].setPulse(pulse);
            if (!pulse)
            {
                lightInstances[i].setKeepGoing(true);
                lightInstances[i].setTime(2.0f);
                lightInstances[i].setPulseRepetition(1);
            }

        }
    }

    public static void Add(LightChanger.LightInstance lightInstance)
    {
        lightInstances.Add(lightInstance);
    }
}
