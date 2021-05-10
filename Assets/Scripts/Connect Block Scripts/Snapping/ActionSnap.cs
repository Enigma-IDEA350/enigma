using UnityEngine;

/*
Author: Logan Brown
Description:
Script for the execution of logical and physical connection between blocks
*/
public class ActionSnap : MonoBehaviour
{

    [SerializeField] private bool bottomConnected = false;
    [SerializeField] private bool topConnected = false;
    private AbstractBlock blah;
    private CurrentBlocks blocks;
    private ActionSnap blockAbove;

    public bool InsideIfBlock = false;
    public bool BlockInsideMeIf = false;
    public bool BlockInsideMeFor = false;



    public bool ImAIff => (blah.GetMyType() == "IfBlock");

    public bool isOpen() { return !bottomConnected; }
    public bool isTopConnected() { return topConnected; }
    public void toggleBottom() { bottomConnected = false; }
    public void toggleTop() { topConnected = topConnected ? false : true; }



    void Start()
    {
        blocks = GameObject.Find("GameLogic").GetComponent<CurrentBlocks>();
        blah = transform.GetComponent<AbstractBlock>();
    }
    public void snap()
    {
        isClose(.25f);
    }

    public void disconnect()
    {
        blah.GetComponent<ConnectBlock>().DisconnectMeFrom(transform.parent.GetComponent<AbstractBlock>());
        transform.SetParent(null);
        topConnected = false;
        if (blockAbove != null)
        {
            if (blockAbove.ImAIff)
            {
                blockAbove.BlockInsideMeIf = false;
                blockAbove.toggleBottom();

            }
            else
            {
                blockAbove.toggleBottom();
            }
            blockAbove = null;
        }
    }
    private void isClose(float minDistance)
    {
        Debug.Log("frean");
        Vector3 recOfCurrent = transform.tag == "ActionBlock" ? transform.Find("opening").position : transform.Find("outer_opening").position;
        if (!topConnected)
        {
            foreach (GameObject block in blocks.getActionBlocks())
            {

                if (block != this.gameObject && !block.GetComponent<ActionSnap>().InsideIfBlock && block.GetComponent<AbstractBlock>().GetMyType() != "ReadBlock")
                {
                    Vector2 conofBlock = block.transform.Find("connector").position;
                    ActionSnap tempBlockAbove = block.GetComponent<ActionSnap>();
                    if (Vector3.Distance(recOfCurrent, conofBlock) <= minDistance && tempBlockAbove.isOpen() && block.transform.parent != null)
                    {
                        if (block.GetComponent<AbstractBlock>().GetMyParent() != null)
                        {
                            Debug.Log("close");
                            blockAbove = tempBlockAbove;
                            transform.GetComponent<ConnectBlock>().ConnectMeTo(block.GetComponent<AbstractBlock>());
                            snapToBottom(conofBlock, recOfCurrent);
                            transform.parent = block.transform.parent;
                            topConnected = true;
                            blockAbove.bottomConnected = true;
                        }

                    }
                }
            }
        }

        foreach (GameObject block in blocks.getMouthBlocks())
        {
            Debug.Log("Mouth");
            Vector2 conofBlock = block.transform.Find("connector").position;

            if (block.GetComponent<ChildHolder>().ChildBlocks.Count == 0 && Vector3.Distance(conofBlock, recOfCurrent) <= minDistance && transform.parent != block.transform)
            {
                transform.GetComponent<ConnectBlock>().ConnectMeTo(block.GetComponent<ForEachBlock>());
                snapToBottom(conofBlock, recOfCurrent);
                transform.parent = block.transform;
                topConnected = true;
            }
        }
        Debug.Log(blockAbove == null);
        if (blockAbove == null)
        {
            foreach (GameObject block in blocks.getHybridBlocks())
            {

                if (block != this.gameObject)
                {
                    Debug.Log("hello");
                    Vector2 conofBlock = block.transform.Find("connector").position;
                    Vector2 outerConofBlock = block.transform.Find("outer_connector").position;

                    if (Vector3.Distance(conofBlock, recOfCurrent) <= minDistance && transform.parent != block.transform)// && blockAbove.BlockInsideMe == false)
                    {
                        blockAbove = block.GetComponent<ActionSnap>();
                        if (!blockAbove.BlockInsideMeIf && !(blah.GetMyType() == "ReadBlock"))// || blah.GetMyType() == "IfBlock"))
                        {
                            if (blah.GetMyType() != "IfBlock")
                                transform.GetComponent<ConnectBlock>().ConnectMeTo(block.GetComponent<ConditionalBlock>());
                            snapToBottom(conofBlock, recOfCurrent);
                            transform.parent = block.transform;
                            topConnected = true;
                            InsideIfBlock = true;
                            blockAbove.BlockInsideMeIf = true;
                            Debug.Log("inner");
                        }
                    }


                    else if (Vector3.Distance(recOfCurrent, outerConofBlock) <= minDistance && block.GetComponent<ActionSnap>().isOpen() && block.transform.parent != null)
                    {
                        Debug.Log("fret");
                        if (true)//(block.GetComponent<AbstractBlock>().GetMyParent() != null)
                        {
                            blockAbove = block.GetComponent<ActionSnap>();
                            transform.GetComponent<ConnectBlock>().ConnectMeToBottom(block.GetComponent<AbstractBlock>());
                            snapToBottom(outerConofBlock, recOfCurrent);
                            transform.parent = block.transform.parent;
                            topConnected = true;
                            blockAbove.bottomConnected = true;
                            Debug.Log("outer");
                        }
                    }
                }
                Debug.Log(blockAbove == null);

            }
        }
    }



    private void snapToBottom(Vector2 newpos, Vector2 oldpos)
    {
        SoundManager.PlaySound(SoundManager.Sound.BlockSnap);
        Vector2 absmove = newpos - oldpos;
        transform.Translate(absmove);

    }
}
