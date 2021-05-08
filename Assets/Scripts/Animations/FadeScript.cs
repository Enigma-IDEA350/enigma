using TMPro;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    SpriteRenderer rend;
    TMP_Text text;
    private float speed;
    private bool fadeIn;
    private bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TMP_Text>();
        Color c = rend.color;
        Color t = text.color;
        t.a = 0f;
        c.a = 0f;
        rend.color = c;
        text.color = t;
    }

    private void Update()
    {
        if (fadeIn)
        {
            if (rend.color.a < 255)
            {
                float fadeAmount = rend.color.a + (speed * Time.deltaTime);
                Color newRend = new Color(rend.color.r, rend.color.g, rend.color.b, fadeAmount);
                Color newText = new Color(text.color.r, text.color.g, text.color.b, fadeAmount);
                rend.color = newRend;
                text.color = newText;
            }
        }
        if (fadeOut)
        {
            if (rend.color.a > 0)
            {
                float fadeAmount = rend.color.a - (speed * Time.deltaTime);
                Color newRend = new Color(rend.color.r, rend.color.g, rend.color.b, fadeAmount);
                Color newText = new Color(text.color.r, text.color.g, text.color.b, fadeAmount);
                rend.color = newRend;
                text.color = newText;
            }
        }

    }

    public void FadeIn()
    {
        fadeIn = true;
        fadeOut = false;
        speed = 5;
        Color c = rend.color;
        enabled = true;
    }
    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
        speed = 5;
        Color c = rend.color;
        enabled = true;
    }
}
