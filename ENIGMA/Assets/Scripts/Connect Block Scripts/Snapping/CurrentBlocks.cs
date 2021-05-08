using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
Author: Logan Brown
Description:
Keeps track of all of the current blocks in the play area
*/

public class CurrentBlocks : MonoBehaviour
{
    private List<GameObject> currentActionBlocks = new List<GameObject>();
    public List<GameObject> getActionBlocks() { return currentActionBlocks; }
    private List<GameObject> currentMouthBlocks = new List<GameObject>();
    public List<GameObject> getMouthBlocks() { return currentMouthBlocks; }

    private List<GameObject> currentHybridBlocks = new List<GameObject>();
    public List<GameObject> getHybridBlocks() { return currentHybridBlocks; }

    MakeBlock[] makeBlocks;

    void Start()
    {
        makeBlocks = GameObject.Find("Makers").GetComponentsInChildren<MakeBlock>();
    }

    private List<GameObject> updateList(string tag, List<GameObject> currentGameObjects)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

        if (goWithTag != null)
        {
            if (goWithTag.Length != currentGameObjects.Count)
            {
                currentGameObjects = goWithTag.ToList();

            }
        }
        else
        {
            currentGameObjects = new List<GameObject>();
        }
        return currentGameObjects;
    }

    private void getLists()
    {
        currentActionBlocks = updateList("ActionBlock", currentActionBlocks);
        currentMouthBlocks = updateList("MouthBlock", currentMouthBlocks);
        currentHybridBlocks = updateList("HybridBlock", currentHybridBlocks);
        tooManyBlocks();
        singleBlockCheck();
    }

    private void onlyOne()
    {
        if (GameObject.FindObjectsOfType<ForEachBlock>().Count() == 1)
        {
            GameObject.Find("for_maker").GetComponent<MakeBlock>().setOnlyOne(true);
        }
        else if (GameObject.FindObjectsOfType<ForEachBlock>().Count() == 0)
        {
            GameObject.Find("for_maker").GetComponent<MakeBlock>().setOnlyOne(false);
        }
        if (GameObject.FindObjectsOfType<ConditionalBlock>().Count() == 1)
        {
            GameObject.Find("if_maker").GetComponent<MakeBlock>().setOnlyOne(true);
        }
        else if (GameObject.FindObjectsOfType<ConditionalBlock>().Count() == 0)
        {
            GameObject.Find("if_maker").GetComponent<MakeBlock>().setOnlyOne(false);
        }
    }
    private void tooManyBlocks()
    {
        if (makeBlocks != null)
        {
            if (currentActionBlocks.Count + currentMouthBlocks.Count + currentHybridBlocks.Count > 8)
            {
                foreach (MakeBlock makeBlock in makeBlocks)
                {
                    makeBlock.setTooManyBlocks(true);
                }
            }
            else
            {
                foreach (MakeBlock makeBlock in makeBlocks)
                {
                    makeBlock.setTooManyBlocks(false);
                }
            }
        }
    }

    private void singleBlockCheck()
    {
        if (GameObject.FindObjectsOfType<ReadBlock>().Count() == 1)
        {
            GameObject.Find("read_maker").GetComponent<MakeBlock>().setOnlyOne(true);
        }
        else if (GameObject.FindObjectsOfType<ReadBlock>().Count() == 0)
        {
            GameObject.Find("read_maker").GetComponent<MakeBlock>().setOnlyOne(false);
        }
        if (GameObject.FindObjectsOfType<ForEachBlock>().Count() == 1)
        {
            GameObject.Find("for_maker").GetComponent<MakeBlock>().setOnlyOne(true);
        }
        else if (GameObject.FindObjectsOfType<ForEachBlock>().Count() == 0)
        {
            GameObject.Find("for_maker").GetComponent<MakeBlock>().setOnlyOne(false);
        }
    }

    void Update()
    {
        getLists();
    }



}
