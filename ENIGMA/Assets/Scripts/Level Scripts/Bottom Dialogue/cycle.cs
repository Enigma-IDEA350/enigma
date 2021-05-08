using System;
using System.Collections.Generic;
using UnityEngine;

public class cycle : MonoBehaviour
{
    // Start is called before the first frame update
    ChatBubble messages;
    int currentSlide;
    OnStart begining;

    bool isAllowed = true;
    string[] texts;
    List<string[]> group;
    string errorMessage;

    public void blockNext(string error) { isAllowed = false; errorMessage = error; }

    public void allowNext() { isAllowed = true; }
    private void setToLast() { currentSlide = texts.Length - 1; messages.messageAtIndex(texts, currentSlide); }
    public void setMessageGroup(List<string[]> groupOfMessages) { group = groupOfMessages; }

    public void setText(string[] text) { texts = text; }

    public List<string[]> getGroup() { return group; }

    public void runStart()
    {
        messages = GameObject.Find("ChatBubble").GetComponent<ChatBubble>();
        begining = GameObject.Find("LevelManager").GetComponent<OnStart>();
        currentSlide = 0;
        messages.begin(texts);
    }
    public void runStart2() {
        currentSlide = 0;
        messages.begin(texts);
    }
    public void runStartGroup()
    {
        texts = group[0];
        messages = GameObject.Find("ChatBubble").GetComponent<ChatBubble>();
        begining = GameObject.Find("LevelManager").GetComponent<OnStart>();
        currentSlide = 0;
        messages.begin(texts);
    }


    public void previosuMessageGroup()
    {
        int currentIndex = group.IndexOf(texts);
        if (currentIndex - 1 >= 0)
        {
            texts = group[currentIndex - 1];
            setToLast();
        }
    }

    public void nextMessageGroup()
    {
        int currentIndex = group.IndexOf(texts);
        if (currentIndex + 1 < group.Count)
        {
            texts = group[currentIndex + 1];
            runStart();
        }
    }


    public void Next(Action transtion)
    {
        if (currentSlide + 1 < texts.Length && isAllowed)
        {
            currentSlide += 1;
            messages.nextMessage(texts);
        }
        else if (currentSlide == texts.Length - 1 && isAllowed)
        {
            if (group != null) nextMessageGroup();
            if (transtion != null) transtion();
        }
        else if (!isAllowed)
        {
            ErrorHandler errorHandler = GameObject.Find("ERROR_MESSAGE").GetComponent<ErrorHandler>();
            errorHandler.raiseError(errorMessage);
        }

    }

    public void Previous(Action transtion)
    {
        if (currentSlide - 1 >= 0)
        {
            currentSlide -= 1;
            messages.previousMessage(texts);
        }
        else if (currentSlide == 0 && group != null)
        {
            previosuMessageGroup();
            if (transtion != null) transtion();
        }

    }
}
