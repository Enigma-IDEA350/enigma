using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningMessageFadeIn : MonoBehaviour
{
    SpriteRenderer rend;
    private float speed;
    private bool fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.color;
        c.a = 0f;
        rend.color = c;
        speed = .4f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (rend.color.a < 255)
        {
            float fadeAmount = rend.color.a + (speed * Time.deltaTime);
            Color newRend = new Color(rend.color.r, rend.color.g, rend.color.b, fadeAmount);
            rend.color = newRend;
        }
    } 
}
