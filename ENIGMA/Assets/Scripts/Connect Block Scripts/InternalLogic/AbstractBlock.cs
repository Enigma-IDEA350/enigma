using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBlock : MonoBehaviour
{
    protected GameLogic gameLogic;

    private AbstractBlock myParent;
    public delegate char LetterModifier(char letter);
    public abstract LetterModifier totalAction { get; }
    public LetterModifier BaseAction;

    public abstract string GetMyType();

    public void SetMyParent(AbstractBlock abstractBlock)
    {
        myParent = abstractBlock;
    }

    public AbstractBlock GetMyParent()
    {
        if (myParent == null)
        { //Debug.Log("i have no parent"); }
        }
        return myParent;
    }

   
    public void Awake()
    {
        gameLogic = GameObject.FindObjectOfType<GameLogic>();
    }

    public abstract LetterModifier ChildenActions();

    public char IdentityLetterModifier(char letter)
    {
        return letter;
    }
}
