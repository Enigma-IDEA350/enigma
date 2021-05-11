using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If true for a func lets the block be picked
/// </summary>
public class BlockButtonGreyout : MonoBehaviour
{
    [SerializeField]
    private GameObject ForEach;
    [SerializeField]
    private GameObject ForEachGrey;
    [SerializeField]
    private GameObject If;
    [SerializeField]
    private GameObject IfGrey;
    [SerializeField]
    private GameObject Switch;
    [SerializeField]
    private GameObject SwitchGrey;
    [SerializeField]
    private GameObject Shift;
    [SerializeField]
    private GameObject ShiftGrey;
    [SerializeField]
    private GameObject Read;
    [SerializeField]
    private GameObject ReadGrey;




    public void IfOn(bool yes)
    {
        if (yes) { If.SetActive(true); IfGrey.SetActive(false); }
        else { If.SetActive(false); IfGrey.SetActive(true); }
    }
    public void SwitchOn(bool yes)
    {
        if (yes) { Switch.SetActive(true); SwitchGrey.SetActive(false); }
        else { Switch.SetActive(false); SwitchGrey.SetActive(true); }
    }
    public void ShiftOn(bool yes)
    {
        if (yes) { Shift.SetActive(true); ShiftGrey.SetActive(false); }
        else { Shift.SetActive(false); ShiftGrey.SetActive(true); }
    }
    public void ReadOn(bool yes)
    {
        if (yes) { Read.SetActive(true); ReadGrey.SetActive(false); }
        else { Read.SetActive(false); ReadGrey.SetActive(true); }
    }


}
