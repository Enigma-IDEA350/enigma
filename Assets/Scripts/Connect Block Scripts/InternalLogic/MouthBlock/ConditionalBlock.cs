using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ConditionalBlock : AbstractIf
{
    [SerializeField] private TMP_InputField letterField;
    public char IfLetter
    {
        get
        {
            if (letterField.text == "")
            {
                return char.Parse("*");
            }
            else { return char.Parse(letterField.text); }
        }
    }

    public override string GetMyType()
    {
        return "IfBlock";
    }
    protected override bool LetterIf(char letter)
    {

        if (IfLetter.ToString() == "")
        {
            return false;
        }

        if (Char.ToLower(letter) == Char.ToLower(IfLetter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}



