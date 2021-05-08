using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectTutotrialEntriesTwo : MonoBehaviour
{
    public ForEachBlock[] ForEachBlocks;
    public ReadBlock[] ReadBlocks;
    public ConditionalBlock[] ConditionalBlocks;
    public ChangeLetterTo[] ChangeLetterTos;

    public bool CorrectReadPlacement;
    public bool CorrectIfPlacement;
    public bool CorrectSwitchPlacement;

    public bool CorrectForEachStart;
    public bool CorrectForEachEnd;

    public bool CorrectSwitchLetter;
    public bool CorrectIfLetter;

    private int NumForeach => ForEachBlocks.Length;
    private int NumSwitch => ChangeLetterTos.Length;
    private int NumIf => ConditionalBlocks.Length;
    private int NumRead => ReadBlocks.Length;

    public bool CorrectNumForeach => NumForeach == 1;
    public bool CorrectNumSwitch => NumSwitch == 1;
    public bool CorrectNumIf => NumIf == 1;
    public bool CorrectNumRead => NumRead == 1;

    private void Update()
    {
        ForEachBlocks = GameObject.FindObjectsOfType<ForEachBlock>();
        ReadBlocks = GameObject.FindObjectsOfType<ReadBlock>();
        ConditionalBlocks = GameObject.FindObjectsOfType<ConditionalBlock>();
        ChangeLetterTos = GameObject.FindObjectsOfType<ChangeLetterTo>();

        if (CorrectNumForeach)
        {
            TMP_InputField[] fields = ForEachBlocks[0].GetComponentsInChildren<TMP_InputField>();

            int field_1;
            int field_2;
            if (fields[0].text == "") { field_1 = 10; } else { field_1 = int.Parse(fields[0].text); }
            if (fields[1].text == "") { field_2 = 1; } else { field_2 = int.Parse(fields[1].text); }

            CorrectForEachStart = field_1 < 2;
            CorrectForEachEnd = field_2 > 11;


            ChildHolder childHolder = ForEachBlocks[0].GetComponent<ChildHolder>();
            int NumForeachChildren = childHolder.ChildBlocks.Count;
            if (NumForeachChildren == 1)
            {
                if (childHolder.ChildBlocks[0].GetMyType() == "IfBlock") CorrectIfPlacement = true;
                else CorrectIfPlacement = false;
            }
            if (NumForeachChildren == 2)
            {
                if (childHolder.ChildBlocks[0].GetMyType() == "IfBlock") CorrectIfPlacement = true;
                else CorrectIfPlacement = false;

                if (childHolder.ChildBlocks[1].GetMyType() == "ReadBlock") CorrectReadPlacement = true;
                else CorrectReadPlacement = false;
            }
        }
        if (CorrectNumIf)
        {
            ConditionalBlock conditionalBlock = ConditionalBlocks[0];

            if (conditionalBlock.GetComponent<ChildHolder>() != null && conditionalBlock.GetComponent<ChildHolder>().ChildBlocks.Count > 0)
            {
                CorrectSwitchPlacement = (conditionalBlock.GetComponent<ChildHolder>().ChildBlocks[0].GetMyType() == "SwitchBlock");
            }


            CorrectIfLetter = (conditionalBlock.IfLetter == char.Parse("q") ||
                               (conditionalBlock.IfLetter == char.Parse("Q")));
        }


        if (CorrectNumSwitch)
        {
            CorrectSwitchLetter = (ChangeLetterTos[0].DesiredLetter == char.Parse("s") ||
                                  (ChangeLetterTos[0].DesiredLetter == char.Parse("S")));
        }





    }



}
