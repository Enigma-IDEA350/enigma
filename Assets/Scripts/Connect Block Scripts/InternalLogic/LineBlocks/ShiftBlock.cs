using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShiftBlock : AbstractDoBlock
{
    [SerializeField] private TMP_InputField shiftField;
    private int _shiftAmount
    {
        get
        {
            if (shiftField.text == "")
            {
                gameLogic.RaiseError("No number entered in the Shift Block");
                return 0;
            }
            else { return int.Parse(shiftField.text); }
        }
    }
    public override char DoAction(char letter)
    {
        char d = char.IsUpper(letter) ? 'A' : 'a';
        return (char)((((letter + _shiftAmount) - d) % 26) + d);
    }

    public override string GetMyType()
    {
        return "ShiftBlock";
    }
}
