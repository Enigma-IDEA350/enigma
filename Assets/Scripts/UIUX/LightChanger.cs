// Tsun Lok Kwan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class LightChanger : MonoBehaviour
{
    public Light2D glow;
    public SpriteRenderer fill;
    public float timeLeft;
    public Color targetColor;
    public static LightInstance lightInstance;

    public bool timerReached;
    public float timer;

    public class LightInstance
    {
        public Light2D glow;
        public SpriteRenderer fill;
        public Color targetColor;
        public Color colorSet;
        public bool keepGoing;
        public float timeLeft;
        public bool pulse;
        public int pulseRepetition;

        public LightInstance(Light2D glow, SpriteRenderer fill, Color targetColor)
        {
            this.glow = glow;
            this.fill = fill;
            this.keepGoing = true;
            this.targetColor = targetColor;
            this.timeLeft = 2.0f;
            this.pulse = false;
            this.colorSet = Color.black;
            this.pulseRepetition = 0;
        }

        public void Update()
        {
            if (!pulse)
            {
                if (timeLeft <= Time.deltaTime) {
                    // transition complete
                    glow.color = targetColor;
                    fill.color = targetColor;
                    
                    if (keepGoing) {
                        // assign new color
                        targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.3f, 1f);
                        timeLeft = Random.Range(1.0f, 3.0f);
                    }

                }
                else {
                    glow.color = Color.Lerp(glow.color, targetColor, Time.deltaTime/timeLeft);
                    fill.color = Color.Lerp(fill.color, targetColor, Time.deltaTime/timeLeft);
                    timeLeft -= Time.deltaTime;
                }
            }

            else {
                if (timeLeft <= Time.deltaTime) {
                    // transition complete
                    glow.color = targetColor;
                    fill.color = targetColor;
                    // assign new color
                    if (targetColor == Color.black) {
                        targetColor = colorSet;
                    } else {
                        targetColor = Color.black;
                    }
                    timeLeft = 0.3f;
                    pulseRepetition++;
                }
                else {
                    glow.color = Color.Lerp(glow.color, targetColor, Time.deltaTime/timeLeft);
                    fill.color = Color.Lerp(fill.color, targetColor, Time.deltaTime/timeLeft);
                    timeLeft -= Time.deltaTime;
                }                
            }

        }

        public void setPulseRepetition(int pulseRepetition)
        {
            this.pulseRepetition = pulseRepetition;
        }
        
        public void setPulse(bool pulse)
        {
            this.pulse = pulse;
        }

        public void setColor(Color targetColor)
        {
            this.targetColor = targetColor;
            this.colorSet = targetColor;
        }

        public void setTime(float timeLeft)
        {
            this.timeLeft = timeLeft;
        }

        public void setKeepGoing(bool keepGoing)
        {
            this.keepGoing = keepGoing;
        }
    }

    public void Awake() 
    {
        glow = gameObject.transform.Find("Glow").GetComponent<Light2D>();
        fill = gameObject.transform.Find("Fill").GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timerReached = false;
        lightInstance = new LightInstance(glow, fill, Random.ColorHSV(0f, 1f, 1f, 1f, 0.3f, 1f));
        while (!timerReached)
        {
            timer += Time.deltaTime;
            if (timer > 2.0f) {
                timerReached = true;
                timer = 0f;
            }
        }
        LightManager.Add(lightInstance);
    }

    // Update is called once per frame
    // public void Update()
    // {
    //     if (timeLeft <= Time.deltaTime) {
    //         // transition complete
    //         glow.color = targetColor;
    //         fill.color = targetColor;

    //         // assign new color
    //         targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.3f, 1f);
    //         timeLeft = Random.Range(1.0f, 3.0f);
    //     }
    //     else {
    //         glow.color = Color.Lerp(glow.color, targetColor, Time.deltaTime/timeLeft);
    //         fill.color = Color.Lerp(fill.color, targetColor, Time.deltaTime/timeLeft);
    //         timeLeft -= Time.deltaTime;
    //     }
    // }
}
