using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftTest : AbstractDoBlock
{
    public override char DoAction(char letter)
    {
        int step = 1;
        char d = char.IsUpper(letter) ? 'A' : 'a';
        return (char)((((letter + step) - d) % 26) + d);
    }
}
