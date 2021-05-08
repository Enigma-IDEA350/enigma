using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractIf : AbstractMouthBlock
{
    protected abstract bool letterIf(char letter);

    public override LetterModifier totalAction { get => _getTotalAction; }

    public override string GetMyType()
    {
        return ("IfBlock");
    }

    private char _getTotalAction(char letter)
    {
        LetterModifier childAction = ChildenActions();
        if (letterIf(letter))
        {
            return childAction(letter);
        }
        else
        {
            return letter;
        }
    }
}
