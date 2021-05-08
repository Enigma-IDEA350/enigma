using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBlock : AbstractDoBlock
{
    public override char DoAction(char letter)
    {
        return letter;
    }

    public override string GetMyType()
    {
        return "ReadBlock";
    }
}
