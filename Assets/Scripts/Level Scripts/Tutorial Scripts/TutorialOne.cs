using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOne : MonoBehaviour
{
    Arrow arrow;
    TutorialVerifierOne tutorialVerifier;
    Utils utils;
    cycle cycle;
    string[] currentText;
    List<string[]> group;
    next next;
    int position;
    tutorialStart tutorial;


    public void init()
    {
        setDependencies();
        next.setTranstion(forTranstiontion);
        tutorialVerifier.verifyForMade();
        cycle.blockNext("Click on the FOR block");
        arrow.StartArrowAt(position);
        arrow.Show();
        utils.ActiveFor(true);
        cycle.runStartGroup();
    }

    void setDependencies()
    {
        tutorialVerifier = gameObject.GetComponent<TutorialVerifierOne>();
        tutorialVerifier.init();
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        arrow = GameObject.Find("arrow").GetComponent<Arrow>();
        next = GameObject.Find("next").GetComponent<next>();
        group = cycle.getGroup();
        tutorial = gameObject.GetComponent<tutorialStart>();
        utils = new Utils();
    }
    void forTranstiontion()
    {
        next.setTranstion(forInputTransition);
    }

    void forInputTransition()
    {
        cycle.blockNext("Put 1 and 8 into the FOR block");
        tutorialVerifier.verifyForInput();
        next.setTranstion(shiftTranstion);
    }

    void shiftTranstion()
    {
        arrow.NextArrow();
        utils.ActiveShift(true);
        cycle.blockNext("Click on SHIFT block!");
        tutorialVerifier.verifyShiftMade();
        next.setTranstion(shiftMadeTrasition);
    }
    void shiftMadeTrasition()
    {
        next.setTranstion(shiftInputTransition);
    }

    void shiftInputTransition()
    {
        cycle.blockNext("Enter one on the SHIFT block");
        tutorialVerifier.verifyShiftInput();
        next.setTranstion(shiftConnectTransition);
    }
    void shiftConnectTransition()
    {
        cycle.blockNext("Drag the SHIFT block to the opening inside the FOR block");
        tutorialVerifier.verifyShiftConnected();
        next.setTranstion(readTransition);
    }
    void readTransition()
    {
        utils.ActiveRead(true);
        arrow.NextArrow();
        cycle.blockNext("Click on WRITE Block");
        tutorialVerifier.verifyReadMade();
        next.setTranstion(readMadeTrasition);
    }
    void readMadeTrasition()
    {
        next.setTranstion(ReadConnectedTranstion);
    }
    void ReadConnectedTranstion()
    {
        arrow.Hide();
        cycle.blockNext("Connect WRITE block under SHIFT block");
        tutorialVerifier.verifyReadConnected();
        next.setTranstion(play);
    }

    void play()
    {
        GameObject.Find("next").SetActive(false);
        GameObject button = GameObject.Find("Play Button");
        cycle.Clear();
        foreach (var component in button.GetComponents<Component>())
        {
            if (component.GetType().ToString() != "UnityEngine.SpriteRenderer" && component.GetType().ToString() != "UnityEngine.Transform")
            {
                utils.ChangeComponent(component, true);
            }
        }

    }
}
