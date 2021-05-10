using UnityEngine;
using TMPro;
using System.Collections;

public class Utils

{
    MonoBehaviour mono;

    public void setMono(MonoBehaviour monoBehaviour)
    {
        mono = monoBehaviour;
    }

    public void FadeIn(SpriteRenderer item)
    {
        IEnumerator fade()
        {
            yield return new WaitForSeconds(.1f);
            Color objectColor = item.color;
            float fadeAmount = objectColor.a + 5;
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }

        while (item.color.a != 255)
        {
            mono.StartCoroutine(fade());
            return;
        }

    }
    public void FadeOut(SpriteRenderer item)
    {
        IEnumerator fade()
        {
            yield return new WaitForSeconds(.1f);
            Color objectColor = item.color;
            float fadeAmount = objectColor.a - 5;
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            item.color = objectColor;
        }

        while (item.color.a != 0)
        {
            mono.StartCoroutine(fade());
            return;
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
    public void SetBackgroundActive(bool isActive)
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
    public void showChatBubble(cycle cycle)
    {
        SpriteRenderer[] spriteItems = GameObject.Find("Tutorial Dialogue").GetComponentsInChildren<SpriteRenderer>();
        IEnumerator fadeInChat()
        {
            foreach (SpriteRenderer item in spriteItems)
            {
                if (item.gameObject.name != "Background") FadeIn(item);
            }
            yield return new WaitForSeconds(.2f);
            GameObject.Find("Tutorial Dialogue").GetComponentInChildren<TMP_Text>().enabled = true;
            if (cycle.getTexts() != null) cycle.runStart();
        }

        mono.StartCoroutine(fadeInChat());

    }

    public void HideChatBubble(cycle cycle)

    {
        SpriteRenderer[] spriteItems = GameObject.Find("Tutorial Dialogue").GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in spriteItems)
        {
            if (item.gameObject.name != "Background") FadeOut(item);
        }
        cycle.Clear();
    }
    public void ActiveFor(bool isActive)
    {
        GameObject.Find("for_maker").GetComponent<PolygonCollider2D>().enabled = isActive;
    }
    public void ActiveShift(bool isActive)
    {
        GameObject.Find("shift_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void ActiveRead(bool isActive)
    {
        GameObject.Find("read_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void ActiveIf(bool isActive)
    {
        GameObject.Find("If_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
    public void ActiveSwitch(bool isActive)
    {
        GameObject.Find("switch_maker").GetComponent<PolygonCollider2D>().enabled = isActive;

    }
}
