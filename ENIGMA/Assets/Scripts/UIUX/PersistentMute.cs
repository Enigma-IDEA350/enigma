using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentMute
{
    public static bool muted;

    public static bool Muted 
    {
        get
        {
            return muted;
        }
        set 
        {
            muted = value;
        }
    }
}
