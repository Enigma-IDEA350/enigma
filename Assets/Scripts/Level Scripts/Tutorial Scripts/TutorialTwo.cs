using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTwo : MonoBehaviour
{
    Arrow arrow;
    TutorialVerifierTwo tutorialVerifier;
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
        next.setTranstion(forInputTransition);
        tutorialVerifier.verifyForMade();
        cycle.blockNext("Click on the FOR block");
        utils.ActiveFor(true);
        cycle.runStartGroup();
    }

    void setDependencies()
    {
        tutorialVerifier = gameObject.GetComponent<TutorialVerifierTwo>();
        tutorialVerifier.init();
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        arrow = GameObject.Find("arrow").GetComponent<Arrow>();
        next = GameObject.Find("next").GetComponent<next>();
        group = cycle.getGroup();
        tutorial = gameObject.GetComponent<tutorialStart>();
        utils = new Utils();
    }

    void forInputTransition()
    {
        cycle.blockNext("Put 1 and 13 into the FOR block");
        tutorialVerifier.verifyForInput();
        next.setTranstion(ifTranstion);
    }

    void ifTranstion()
    {
        utils.ActiveIf(true);
        arrow.Show();
        cycle.blockNext("Click on IF block!");
        tutorialVerifier.verifyIfMade();
        next.setTranstion(ifInputTransition);
    }
    void ifInputTransition()
    {
        cycle.blockNext("Type Q into the input panel");
        tutorialVerifier.verifyIfInput();
        next.setTranstion(ifConnectTransition);
    }
    void ifConnectTransition()
    {
        cycle.blockNext("Drag the IF block to the opening inside the FOR block");
        tutorialVerifier.verifyifConnected();
        next.setTranstion(switchTransition);
    }
    void switchTransition()
    {
        arrow.NextArrow();
        utils.ActiveSwitch(true);
        cycle.blockNext("Click on the Switch block");
        tutorialVerifier.verifySwitchMade();
        next.setTranstion(switchInputTransition);
    }
    void switchInputTransition()
    {
        cycle.blockNext("Type S into the input panel");
        tutorialVerifier.verifySwitchInput();
        next.setTranstion(switchConnectedTransition);
    }
    void switchConnectedTransition()
    {
        cycle.blockNext("Put the SWITCH BLOCK inside of the IF block");
        tutorialVerifier.verifySwitchConnected();
        next.setTranstion(readTransition);
    }
    void readTransition()
    {
        utils.ActiveRead(true);
        GameObject.Find("arrow").SetActive(false);
        GameObject.Find("Arrows for Cycle").SetActive(false);
        cycle.blockNext("Click on WRITE Block");
        tutorialVerifier.verifyReadMade();
        next.setTranstion(play);
    }
    void play()
    {
        cycle.blockNext("Connect WRITE block under SHIFT block and press the PLAY Button!");
        tutorialVerifier.verifyReadConnected();
        GameObject button = GameObject.Find("Play Button");

        foreach (var component in button.GetComponents<Component>())
        {
            if (component.GetType().ToString() != "UnityEngine.SpriteRenderer" && component.GetType().ToString() != "UnityEngine.Transform")
            {
                utils.ChangeComponent(component, true);
            }
        }

    }
}
