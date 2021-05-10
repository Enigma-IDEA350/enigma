using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialVerifierOne : MonoBehaviour
{
    // Start is called before the first frame update
    CorrectTutorialEntiresOne correctEntries;
    cycle cycle;
    Utils utils;
    next next;
    bool forMade = false;
    bool shiftMade = false;
    bool shiftInput = false;
    bool shiftConnected = false;
    bool readMade = false;
    bool readConnected = false;
    bool forInput = false;


    public void init()
    {
        next = GameObject.Find("next").GetComponent<next>();
        correctEntries = GameObject.Find("GameLogic").GetComponent<CorrectTutorialEntiresOne>();
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
        utils = new Utils();
    }
    public void verifyForMade() { forMade = true; enabled = true; }
    public void verifyShiftMade() { shiftMade = true; enabled = true; }
    public void verifyReadMade() { readMade = true; enabled = true; }
    public void verifyForInput() { forInput = true; enabled = true; }
    public void verifyShiftInput() { shiftInput = true; enabled = true; }
    public void verifyShiftConnected() { shiftConnected = true; enabled = true; }
    public void verifyReadConnected() { readConnected = true; enabled = true; }


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
            if (correctEntries.ForEachStart && correctEntries.ForEachEnd)
            {
                TMP_InputField[] textInputs = GameObject.FindObjectOfType<ForEachBlock>().GetComponentsInChildren<TMP_InputField>();
                foreach (TMP_InputField input in textInputs) { input.readOnly = true; }
                forInput = false;
                enabled = false;
                cycle.allowNext();
                next.triggerNext();
            }
        }

        if (shiftMade)
        {
            if (correctEntries.CorrectNumShift)
            {
                shiftMade = false;
                enabled = false;
                cycle.allowNext();
                utils.ActiveShift(false);
                next.triggerNext();
            }
        }

        if (shiftInput)
        {
            if (correctEntries.ShiftStep)
            {
                TMP_InputField[] textInputs = GameObject.FindObjectOfType<ShiftBlock>().GetComponentsInChildren<TMP_InputField>();
                foreach (TMP_InputField input in textInputs) { input.readOnly = true; }
                shiftInput = false;
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
        if (shiftConnected)
        {
            if (correctEntries.CorrectShiftPlacement)
            {
                shiftConnected = false;
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
                next.triggerNext();
            }
        }
    }
}
