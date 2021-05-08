using UnityEngine;
/// <summary>
/// Component to drive block to block connection
/// </summary>
[RequireComponent(typeof(AbstractBlock))]
public class ConnectBlock : MonoBehaviour
{
    AbstractBlock MyAbstractBlock;
    ChildHolder MyChildHolder;

    private void Start()
    {
        MyChildHolder = GetComponent<ChildHolder>();
        MyAbstractBlock = GetComponent<AbstractBlock>();
    }



    public void ConnectMeToBottom(AbstractBlock abstractBlock)
    {
        //we want the parent of the block we're connecting to
        Debug.Log(abstractBlock.GetMyType());

        AbstractBlock newParent = abstractBlock.GetMyParent();
        ChildHolder newParentChildHolder = newParent.GetComponent<ChildHolder>();
        MyAbstractBlock.SetMyParent(newParent);
        newParentChildHolder.AddToList(MyAbstractBlock);
        Scale scale = newParent.GetComponent<Scale>();
        if (scale == null) { Debug.Log("no scale"); }
        else
        {
            scale.ScaleMe();
        }
    }


    public void ConnectMeTo(AbstractBlock abstractBlock)
    {
        ChildHolder childHolder = abstractBlock.gameObject.GetComponent<ChildHolder>();
        AbstractBlock newParent;
        if (childHolder != null)
        {
            newParent = abstractBlock;
            childHolder.AddToList(MyAbstractBlock);
        }
        else //connecting to line block
        {
            newParent = abstractBlock.GetMyParent();
            ChildHolder newParentChildHolder = newParent.GetComponent<ChildHolder>();
            newParentChildHolder.AddToList(MyAbstractBlock);
        }



        MyAbstractBlock.SetMyParent(newParent);

        Scale scale = newParent.GetComponent<Scale>();
        if (scale == null)
        {
        }
        else
        {
            scale.ScaleMe();
        }
    }
    public void DisconnectMeFrom(AbstractBlock abstractBlock3)
    {
        AbstractBlock MyParent = MyAbstractBlock.GetMyParent();
        MyParent.GetComponent<ChildHolder>().RemoveFromList(MyAbstractBlock);

        Scale scale = MyParent.GetComponent<Scale>();
        if (scale == null)
        {
        }
        else
        {
            scale.ScaleMe();
        }

        MyAbstractBlock.SetMyParent(null);



    }

}
