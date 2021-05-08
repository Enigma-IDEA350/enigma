using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectTutorialEntiresOne : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ForEachStart = false;
    public bool ForEachEnd = false;
    public bool ShiftStep = false;


    private int NumForeach;
    private int NumShift;
    private int NumRead;

    public bool CorrectNumForeach => (NumForeach == 1);
    public bool CorrectNumRead => (NumRead == 1);
    public bool CorrectNumShift => (NumShift == 1);

    private ForEachBlock[] forEachBlocks;
    private ShiftBlock[] shiftBlocks;
    private ReadBlock[] readBlocks;

    public bool CorrectShiftPlacement;
    public bool CorrectReadPlacement;

    public ErrorHandler errorHandler;



    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<ErrorHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        forEachBlocks = GameObject.FindObjectsOfType<ForEachBlock>();
        shiftBlocks = GameObject.FindObjectsOfType<ShiftBlock>();
        readBlocks = GameObject.FindObjectsOfType<ReadBlock>();

        NumForeach = forEachBlocks.Length;
        NumShift = shiftBlocks.Length;
        NumRead = readBlocks.Length;

        if (NumForeach == 1)
        {
            ForEachBlock forEachBlock = forEachBlocks[0];
            TMP_InputField[] fields = forEachBlock.GetComponentsInChildren<TMP_InputField>();

           

            if (fields[0].text != "" && int.Parse(fields[0].text) == 1) { ForEachStart = true; } else { ForEachStart = false; }
            if (fields[1].text != "" && int.Parse(fields[1].text) > 5) { ForEachEnd = true; } else { ForEachEnd = false; }

            ChildHolder childHolder = forEachBlock.GetComponent<ChildHolder>();



            if (childHolder.ChildBlocks.Count > 0 && childHolder.ChildBlocks[0].GetMyType() == "ShiftBlock")
            { CorrectShiftPlacement = true; }
            else { CorrectShiftPlacement = false; }

            if (childHolder.ChildBlocks.Count > 1 && childHolder.ChildBlocks[1].GetMyType() == "ReadBlock")
            { CorrectReadPlacement = true; }
            else { CorrectReadPlacement = false; }
        }

        if (NumShift == 1)
        {
            TMP_InputField field = shiftBlocks[0].GetComponentInChildren<TMP_InputField>();
            if (field.text != "" && int.Parse(field.text) == 1) { ShiftStep = true; } else { ShiftStep = false; }
        }
    }
}
