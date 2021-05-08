using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLetterTo : AbstractDoBlock
{
    [SerializeField] private TMP_InputField letterField;
    public char DesiredLetter
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

    public override char DoAction(char letter)
    {
        return char.ToUpper(DesiredLetter);
    }

    public override string GetMyType()
    {
        return "SwitchBlock";
    }
}
