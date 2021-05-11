using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildHolder : MonoBehaviour
{
    private float _ifScale = 2.425f;

    private List<AbstractBlock> _childBlockBacking = new List<AbstractBlock>();
    public List<AbstractBlock> ChildBlocks
    {
        get { return _childBlockBacking; }
    }

    public float TotalCount => RecursiveChildrenCount() + 1;
    public void AddToList(AbstractBlock abstractBlock)
    {
        _childBlockBacking.Add(abstractBlock);
    }

    public void RemoveFromList(AbstractBlock abstractBlock)
    {
        if (_childBlockBacking.Contains(abstractBlock))
        {
            _childBlockBacking.Remove(abstractBlock);
        }
        else
        {
        }
    }

    /// <summary>
    /// not so recursive anymore childcount. Ifs only hold one block now
    /// </summary>
    /// <returns></returns>
    public float RecursiveChildrenCount()
    {
        float currNumber = 0;
        foreach (AbstractBlock abstractBlock in ChildBlocks)
        {
            if (abstractBlock is ReadBlock)
            {
                currNumber += 0;
            }
            else if (abstractBlock is ConditionalBlock)
            {
                currNumber += _ifScale;
            }
            else
            {
                currNumber += 1;
            }
            //if (abstractBlock.GetComponent<ChildHolder>() != null)
            //{
            //    //Debug.Log(GetComponent<AbstractBlock>().GetMyType());
            //    currNumber += abstractBlock.GetComponent<ChildHolder>().RecursiveChildrenCount();
            //}
        }
        return currNumber;
    }

    public bool CheckForReadBlock()
    {
        if (ChildBlocks.Count == 0)
        {
            return false;
        }
        else
        {

            return (ChildBlocks[ChildBlocks.Count - 1].GetMyType() == "ReadBlock");
        }
    }
}

