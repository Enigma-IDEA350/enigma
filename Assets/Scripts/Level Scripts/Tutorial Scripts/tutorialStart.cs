using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class tutorialStart : MonoBehaviour
{
    GameObject tutorialGroup;
    bool chatBubble = false;

    TutorialOne tutorialOne;
    TutorialTwo tutorialTwo;

    bool unChatBubble = false;
    next next;
    cycle cycle;
    Arrow arrow;
    Utils utils = new Utils();

    void Update()
    {
        if (chatBubble) utils.showChatBubble();
        else if (unChatBubble) utils.HideChatBubble();
    }

    public void tutorialInit(string[] initText, List<string[]> listOfMessages, int level)
    {
        setDependencies();
        cycle.setMessageGroup(listOfMessages);
        cycle.setText(initText);
        fadeinTutorial();
        if (level == 1)
        {
            next.setTranstion(tutorialOne.init);
        }
        else if (level == 4)
        {
            next.setTranstion(tutorialTwo.init);
        }
    }
    public void regularInit(string[] messages)
    {
        setDependencies();
        cycle.setText(messages);
        fadeinTutorial();
        next.setTranstion(StartGameplay);
    }

    void StartGameplay()
    {
        hideChatBubble();
        utils.SetBackgroundActive(true);

    }
    void setDependencies()
    {
        tutorialOne = GetComponent<TutorialOne>();
        tutorialTwo = GetComponent<TutorialTwo>();
        arrow = GameObject.Find("arrow").GetComponent<Arrow>();
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        next = GameObject.Find("next").GetComponent<next>();
        tutorialGroup = GameObject.Find("Tutorial Things");
    }

    void fadeinTutorial()
    {
        tutorialGroup.SetActive(false);
        utils.SetBackgroundActive(false);
        StartCoroutine(StartDelay(2));
    }
    IEnumerator StartDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        setTutorial();
        showChatBubble();
        cycle.runStart();

    }
    public void setTutorial()
    {
        tutorialGroup.SetActive(true);
        SpriteRenderer[] spriteItems = tutorialGroup.GetComponentsInChildren<SpriteRenderer>();
        Image[] buttonItems = tutorialGroup.GetComponentsInChildren<Image>();
        foreach (SpriteRenderer item in spriteItems)
        {
            Color c = new Color(item.color.r, item.color.g, item.color.b, 0);
            item.color = c;
        }
    }

    void showChatBubble()
    {
        chatBubble = true;
        unChatBubble = false;
    }

    IEnumerator hideChatDelay()
    {
        unChatBubble = true;
        chatBubble = false;
        yield return new WaitForSeconds(2);
        unChatBubble = false;
    }

    void hideChatBubble()
    {
        StartCoroutine(hideChatDelay());
    }

}
