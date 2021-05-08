using System;
using UnityEngine;

public class next : MonoBehaviour
{

    cycle cycle;
    Action transtion;

    public void setTranstion(Action newTranstion) { transtion = newTranstion; }
    public void triggerNext() { cycle.Next(transtion); }

    void Start()
    {
        cycle = GameObject.Find("Arrows for Cycle").GetComponent<cycle>();
    }

    void OnMouseDown()
    {
        cycle.Next(transtion);
    }
}
