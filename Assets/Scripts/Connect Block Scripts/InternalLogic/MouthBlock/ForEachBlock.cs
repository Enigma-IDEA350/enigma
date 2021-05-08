using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TMP_InputField))]
public class ForEachBlock : AbstractMouthBlock
{
    private Message_SO messageData;
    

    public bool ReadblockExists { get => childHolder.CheckForReadBlock(); }

    public string Input;
    public string Output;
    public bool ChildrenButton = false;
    public bool LetterMod = false;
    [SerializeField] private TMP_InputField start_field;
    [SerializeField] private TMP_InputField end_field;

    private int _start
    {
        get
        {
            if (start_field.text == "")
            {
                Debug.Log("asdf");
                return 0;
            }
            else { return int.Parse(start_field.text); }
        }
    }
    private int _end
    {
        get
        {
            if (end_field.text == "") { return 0; }
            else { return int.Parse(end_field.text); }
        }
    }
    private bool _reverse { get => _end < _start; }

    private void Start()
    {
        childHolder = GetComponent<ChildHolder>();
        TMP_InputField[] inputFields = GetComponentsInChildren<TMP_InputField>();
        start_field = inputFields[0];
        end_field = inputFields[1];

        SetMyFields();
    }

    public override LetterModifier totalAction => _getTotalActionsChildren;


    public string Map(string input)
    {
        
        int left = Mathf.Max(Mathf.Min(_start-1, _end-1),0);
        int right = Mathf.Min(Mathf.Max(_start-1, _end-1)+1, input.Length-1);

        int numSpaces = 0;
  
        char[] tempCharList = input.ToCharArray(left, (right-left));
        foreach(char letter in tempCharList)
        {
            if (letter == char.Parse(" "))
            {
                numSpaces++;
            }
        }

        tempCharList = input.ToCharArray(left, Mathf.Min(right+1 + numSpaces - left-1,input.Length - left));
        Debug.Log(tempCharList.Length);
        Debug.Log(numSpaces);
        Debug.Log(tempCharList);

        if (_reverse)
        {
            System.Array.Reverse(tempCharList);
        }


        for (int i = 0; i < tempCharList.Length; i += 1)
        {
            if (tempCharList[i] != char.Parse(" "))
            {
                tempCharList[i] = totalAction(tempCharList[i]);
            }
        }

        return new string(tempCharList);
  
      
    }
    
    

    public override string GetMyType()
    {
        return "ForeachBlock";
    }

    public override LetterModifier ChildenActions()
    {
        throw new System.NotImplementedException();
    }

    private void SetMyFields()
    {
        messageData = gameLogic.MessageData;
        start_field.text = messageData.CorrectStart.ToString();
        end_field.text = messageData.CorrectEnd.ToString();
    }
}
