using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    ChildHolder childHolder;

    public float _scaleAmount;
    private float _scaleTop;
    private float _scaleBot;
    private float _width;
    private float _height;
    private float _initialHeight;

    public bool button = false;

    bool isForeach;

    SpriteRenderer spriteRenderer;

    Vector3 conOfCurrent;
    Vector3 recOfCurrent;
    Vector3 outerOfCurrent;

    float drop;
    float raise;
    float raise2;
    BoxCollider2D spine;
    BoxCollider2D bottom;
    BoxCollider2D top1;
    BoxCollider2D top2;
    BoxCollider2D top3;
    BoxCollider2D top4;
    BoxCollider2D top5;
    Vector3 defaultTopOffset;
    Vector3 defaultBottomOffset;

    Vector3 outerConnectorOffset;
    Vector3 outer_connector;


    private void Start()
    {
        childHolder = GetComponent<ChildHolder>();
        spine = transform.GetComponents<BoxCollider2D>()[0];
        top1 = transform.GetComponents<BoxCollider2D>()[1];
        bottom = transform.GetComponents<BoxCollider2D>()[2];

        top2 = transform.GetComponents<BoxCollider2D>()[3];
        top3 = transform.GetComponents<BoxCollider2D>()[4];
        top4 = transform.GetComponents<BoxCollider2D>()[5];
        top5 = transform.GetComponents<BoxCollider2D>()[6];

        defaultTopOffset = top1.offset;
        defaultBottomOffset = bottom.offset;


    }

    void Awake()
    {

        conOfCurrent = transform.Find("connector").gameObject.transform.localPosition;
        recOfCurrent = transform.Find("opening").gameObject.transform.localPosition;

        Transform tempOuter = transform.Find("outer_connector");
        if (tempOuter != null) { outerOfCurrent = tempOuter.gameObject.transform.localPosition; isForeach = true; }
        //outerOfCurrent = transform.Find("outer_connector").gameObject.transform.localPosition;
        
        outerConnectorOffset = recOfCurrent - outerConnectorOffset;

        spriteRenderer = GetComponent<SpriteRenderer>();
        _width = spriteRenderer.size.x;
        _height = spriteRenderer.size.y;
        _initialHeight = spriteRenderer.size.y;
        _scaleTop = transform.position.y + _height / 2;
        _scaleBot = transform.position.y - _height / 2;


        drop = _scaleTop - transform.Find("connector").gameObject.transform.position.y;
        raise = _scaleBot - transform.Find("opening").gameObject.transform.position.y;
        if (isForeach)
        {
            raise2 = _scaleBot - transform.Find("outer_connector").gameObject.transform.position.y;
        }

        SetHeightToScaleFrom();
    }

    public void SetHeightToScaleFrom()
    {
        _scaleTop = transform.position.y + _height / 2;
        _scaleBot = transform.position.y - _height / 2;
    }
    public void SetHeight(float number)
    {
        SetHeightToScaleFrom();
        Vector3 connectorPos = transform.Find("connector").gameObject.transform.position;
        Vector3 openingPos = transform.Find("opening").gameObject.transform.position;
        if (isForeach) {  outer_connector = transform.Find("outer_connector").gameObject.transform.position; }
        

        _height = _initialHeight + number * _scaleAmount;
        float diff = (_scaleTop - _height / 2) - transform.position.y;

        spine.size = new Vector2(spine.size.x, _height);
        bottom.offset = new Vector2(bottom.offset.x, defaultBottomOffset.y - .3f * number);
        top1.offset = new Vector2(top1.offset.x, defaultTopOffset.y + .3f * number);
        top2.offset = new Vector2(top2.offset.x, defaultTopOffset.y + .3f * number);
        top3.offset = new Vector2(top3.offset.x, defaultTopOffset.y + .3f * number);
        top4.offset = new Vector2(top4.offset.x, defaultTopOffset.y + .3f * number);
        top5.offset = new Vector2(top5.offset.x, defaultTopOffset.y + .3f * number);




        spriteRenderer.size = new Vector2(_width, _height);
        transform.position += new Vector3(0, diff, 0);

        foreach (Transform child in transform)
        {
            if (child != transform)
            {
                child.position -= new Vector3(0, diff, 0);
            }
        }

        transform.Find("connector").gameObject.transform.position = new Vector3(connectorPos.x, _scaleTop - drop, connectorPos.y);
        transform.Find("opening").gameObject.transform.position = new Vector3(openingPos.x, -raise + transform.position.y - _height / 2, openingPos.y);
        if (isForeach) { transform.Find("outer_connector").gameObject.transform.position = new Vector3(outer_connector.x, -raise2 + transform.position.y - _height / 2, outer_connector.y); }


    }

    public void Update()
    {
        if (button)
        {
            SetHeight(childHolder.TotalCount);
        }
        button = false;
    }



    public void ScaleMe()
    {

        if (childHolder != null)
        {
            SetHeight(childHolder.RecursiveChildrenCount());
        }
        AbstractBlock parent = GetComponent<AbstractBlock>().GetMyParent();
        if (parent != null)
        {
            parent.GetComponent<Scale>().ScaleMe();

        }
    }
}
