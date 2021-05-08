using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDoBlock : AbstractBlock
{
    public abstract char DoAction(char letter);

    public override string GetMyType()
    {
        return ("DoBlock");
    }

    public override LetterModifier totalAction => DoAction;

    public override LetterModifier ChildenActions()
    {
        return null;
    }
}
