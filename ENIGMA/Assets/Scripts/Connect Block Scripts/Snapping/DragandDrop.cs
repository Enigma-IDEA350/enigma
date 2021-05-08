/*
Author: Logan 
Description: 
This script allows the object to be dragged around during gameplay. It also checks
if it is close to other objects with the various tag checking (see CurrentBlock.cs) 
*/
using UnityEngine;
using System.Collections.Generic;

public class DragandDrop : MonoBehaviour
{
    private BoxCollider2D area;
    private ActionSnap snap;
    private GameObject trashBin;
    private trash trashFun;
    private Animator m_Animator;
    ErrorHandler errorHandler;
    Message_SO levelInfo;
    GameLogic gameLogic;
    List<int> tutorialLevels;

    void Start()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        levelInfo = gameLogic.MessageData;
        tutorialLevels = new List<int> { 1, 4 };
        area = GameObject.Find("Bounds").GetComponent<BoxCollider2D>();
        errorHandler = GameObject.Find("ERROR_MESSAGE").GetComponent<ErrorHandler>();
        snap = transform.GetComponent<ActionSnap>();
        trashBin = GameObject.Find("Trash_Bin");
        trashFun = gameObject.AddComponent<trash>();
    }

    void Drag()
    {
        if (snap == null)
        { 
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePosition);
        remainInBounds();
        if (!tutorialLevels.Contains(levelInfo.CurrLevel)) trashFun.trashProxChecker(this.gameObject, trashBin);
        }

        else if (snap != null && snap.isOpen())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            remainInBounds();
            if (!tutorialLevels.Contains(levelInfo.CurrLevel)) trashFun.trashProxChecker(this.gameObject, trashBin);
        }
    }

    void OnMouseDown()
    {
        if (snap != null && snap.isTopConnected() && snap.isOpen()) { snap.disconnect(); }
        else if (snap != null && !snap.isOpen()) { errorHandler.raiseError("You can't move this because there are blocks under it"); }

    }


    void OnMouseDrag()
    {
        Drag();
    }

    void OnMouseUp()
    {
        if (snap != null) snap.snap();
        if (!tutorialLevels.Contains(levelInfo.CurrLevel)) trashFun.delete(this.gameObject, trashBin);

    }
    private void remainInBounds()
    {
        Vector3 clampedPosition = transform.position;
        float xExtent = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        float yExtent = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, area.bounds.min.x + xExtent, area.bounds.max.x - xExtent);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, area.bounds.min.y + yExtent, area.bounds.max.y - yExtent);
        transform.position = clampedPosition;
    }



}