using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractIf : AbstractMouthBlock
{
    protected abstract bool LetterIf(char letter);

    public override LetterModifier TotalAction { get => _getTotalAction; }

    public override string GetMyType()
    {
        return ("IfBlock");
    }

    private char _getTotalAction(char letter)
    {
        LetterModifier childAction = ChildenActions();
        if (LetterIf(letter))
        {
            return childAction(letter);
        }
        else
        {
            return letter;
        }
    }
}
