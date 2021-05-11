using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TutorialVerifierTwo : MonoBehaviour
{
    CorrectTutotrialEntriesTwo correctEntries;
    cycle cycle;
    Utils utils;
    next next;
    bool forMade = false;
    bool ifMade = false;
    bool switchMade = false;
    bool readMade = false;
    bool ifInput = false;
    bool switchInput = false;
    bool forInput = false;
    bool readConnected = false;
    bool switchConnected = false;
    bool ifConnected = false;



    public void init()
    {
        next = GameObject.Find("next").GetComponent<next>();
        correctEntries = GameObject.Find("GameLogic").GetComponent<CorrectTutotrialEntriesTwo>();
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        utils = new Utils();
    }
    public void verifyForMade() { forMade = true; enabled = true; }
    public void verifyReadMade() { readMade = true; enabled = true; }
    public void verifySwitchMade() { switchMade = true; enabled = true; }
    public void verifyIfMade() { ifMade = true; enabled = true; }
    public void verifyForInput() { forInput = true; enabled = true; }
    public void verifySwitchInput() { switchInput = true; enabled = true; }
    public void verifyIfInput() { ifInput = true; enabled = true; }
    public void verifySwitchConnected() { switchConnected = true; enabled = true; }
    public void verifyReadConnected() { readConnected = true; enabled = true; }
    public void verifyifConnected() { ifConnected = true; enabled = true; }

    void Update()
    {
        if (forMade)
        {
            if (correctEntries.CorrectNumForeach)
            {
                forMade = false;
                enabled = false;
                cycle.allowNext();
                utils.ActiveFor(false);
                next.triggerNext();
            }
        }

        if (forInput)
        {
            if (correctEntries.CorrectForEachStart && correctEntries.CorrectForEachEnd)
            {
                TMP_InputField[] textInputs = GameObject.FindObjectOfType<ForEachBlock>().GetComponentsInChildren<TMP_InputField>();
                foreach (TMP_InputField input in textInputs) { input.readOnly = true; }
                forInput = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }

        if (ifMade)
        {
            if (correctEntries.CorrectNumIf)
            {
                ifMade = false;
                enabled = false;
                cycle.allowNext();
                utils.ActiveIf(false);
                next.triggerNext();
            }
        }

        if (ifInput)
        {
            if (correctEntries.CorrectIfLetter)
            {
                TMP_InputField[] textInputs = GameObject.FindObjectOfType<ConditionalBlock>().GetComponentsInChildren<TMP_InputField>();
                foreach (TMP_InputField input in textInputs) { input.readOnly = true; }
                ifInput = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }

        if (switchMade)
        {
            if (correctEntries.CorrectNumSwitch)
            {
                switchMade = false;
                enabled = false;
                cycle.allowNext();
                utils.ActiveSwitch(false);
                next.triggerNext();
            }
        }

        if (switchInput)
        {
            if (correctEntries.CorrectSwitchLetter)
            {
                TMP_InputField[] textInputs = GameObject.FindObjectOfType<ChangeLetterTo>().GetComponentsInChildren<TMP_InputField>();
                foreach (TMP_InputField input in textInputs) { input.readOnly = true; }
                switchInput = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }

        if (readMade)
        {
            if (correctEntries.CorrectNumRead)
            {
                readMade = false;
                enabled = false;
                cycle.allowNext();
                utils.ActiveRead(false);
                next.triggerNext();
            }
        }
        if (switchConnected)
        {
            if (correctEntries.CorrectSwitchPlacement)
            {
                switchConnected = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }
        if (ifConnected)
        {
            if (correctEntries.CorrectIfPlacement)
            {
                ifConnected = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }
        if (readConnected)
        {
            if (correctEntries.CorrectReadPlacement)
            {
                readConnected = false;
                enabled = false;
                cycle.allowNext();
            }
        }
    }
}
