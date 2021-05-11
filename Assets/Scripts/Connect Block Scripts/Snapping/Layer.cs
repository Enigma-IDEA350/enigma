using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    int _currentLayer = 0;
    float _currentZ = -0.001f;
    public int GetCurrentLayer()
    {
        return _currentLayer;
    }
    public void SetCurrentLayer(int layer)
    {
        _currentLayer = layer;
    }
    public float GetCurrentZ()
    {
        return _currentZ;
    }
    public void SetCurrentZ()
    {
        _currentZ -= .001f;
    }

}
