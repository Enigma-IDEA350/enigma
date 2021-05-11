using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DecodeState", menuName = "DecodeState_menu")]
public class Message_SO : ScriptableObject
{
    // Start is called before the first frame update
    public int CurrLevel;

    public string Code;
    public string CorrectText;
    public string Decode_Attempt { get => decodeAttemptBacking; set { decodeAttemptBacking = value; } }

    [SerializeField]
    private string decodeAttemptBacking;


    public int CorrectStart => 1;
    public int CorrectEnd;

    public bool solved => (Decode_Attempt == CorrectText);

    public bool ForOn;
    public bool ShiftOn;
    public bool ReadOn;
    public bool IfOn;
    public bool SwitchOn;

    public string hint;

    public void ResetAttempt()
    {
        Decode_Attempt = "";
    }

    private int spaceCount()
    {
        int numSpaces = 0;
        foreach (char letter in Code)
        {
            if (letter == char.Parse(" ")) numSpaces++;
        }
        return numSpaces;
    }
}
