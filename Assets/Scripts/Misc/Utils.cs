using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Utils
{

    public void fadeIn(SpriteRenderer item, float speed)
    {
        if (item.color.a < 255)
        {
            Color objectColor = item.color;
            float fadeAmount = objectColor.a + (speed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }
    }
    public void fadeOut(SpriteRenderer item, float speed)
    {
        if (item.color.a > 0)
        {
            Color objectColor = item.color;
            float fadeAmount = objectColor.a - (speed);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }
    }
    public void fadeInBttn(Image item, float speed)
    {
        if (item.color.a < 255)
        {
            Color objectColor = item.color;
            float fadeAmount = objectColor.a + (speed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }
    }
    public void fadeOutBttn(Image item, float speed)
    {
        if (item.color.a > 0)
        {
            Color objectColor = item.color;
            float fadeAmount = objectColor.a - (speed);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }
    }

    public void ChangeComponent(Component component, bool isActive)
    {
        if (component is Renderer)
        {
            (component as Renderer).enabled = isActive;
        }
        else if (component is Collider)
        {
            (component as Collider).enabled = isActive;
        }
        else if (component is Behaviour)
        {
            (component as Behaviour).enabled = isActive;
        }
    }
    public void setBackgroundActive(bool isActive)
    {
        GameObject[] backgroundInteractables = GameObject.FindGameObjectsWithTag("BGI");
        foreach (GameObject obj in backgroundInteractables)
        {
            foreach (var component in obj.GetComponents<Component>())
            {
                if (component.GetType().ToString() != "UnityEngine.SpriteRenderer" && component.GetType().ToString() != "UnityEngine.Transform")
                {
                    ChangeComponent(component, isActive);
                }
            }

        }
    }
    public void showChatBubble()
    {
        bool chatBubble = true;
        if (chatBubble)
        {
            SpriteRenderer[] spriteItems = GameObject.Find("Tutorial Dialogue").GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer item in spriteItems)
            {
                if (item.gameObject.name != "Background") fadeIn(item, 3f);
            }
        }
        GameObject.Find("Tutorial Dialogue").GetComponentInChildren<TMP_Text>().enabled = true;



    }

    public void hideChatBubble()

    {
        SpriteRenderer[] spriteItems = GameObject.Find("Tutorial Dialogue").GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in spriteItems)
        {
            fadeOut(item, 3f);
        }
        GameObject.Find("Tutorial Dialogue").GetComponentInChildren<TMP_Text>().enabled = false;
    }
    public void activeFor(bool isActive)
    {
        GameObject.Find("for_maker").GetComponent<PolygonCollider2D>().enabled = isActive;
    }
    public void activeShift(bool isActive)
    {
        GameObject.Find("shift_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void activeRead(bool isActive)
    {
        GameObject.Find("read_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void activeIf(bool isActive)
    {
        GameObject.Find("If_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void activeSwitch(bool isActive)
    {
        GameObject.Find("switch_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
}
