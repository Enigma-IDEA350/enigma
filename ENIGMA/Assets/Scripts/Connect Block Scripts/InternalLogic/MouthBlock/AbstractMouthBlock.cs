using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Scale))]
[RequireComponent(typeof(ChildHolder))]
public abstract class AbstractMouthBlock : AbstractBlock
{
    protected ChildHolder childHolder;

    private void Start()
    {
        childHolder = GetComponent<ChildHolder>();
    }


    public override LetterModifier ChildenActions() => _getTotalActionsChildren;



    protected char _getTotalActionsChildren(char letter)
    {
        foreach (AbstractBlock child in childHolder.ChildBlocks)
        {

            letter = child.totalAction(letter);
        }
        return letter;
    }
}
