using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    int CurrentLayer = 0;
    public int getCurrentLayer()
    {
        return CurrentLayer;
    }
    public void setCurrentLayer(int layer)
    {
        CurrentLayer = layer;
    }

}
