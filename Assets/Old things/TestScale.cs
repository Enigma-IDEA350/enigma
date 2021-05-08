using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script for controlling scaling of mouth blocks. Not so happy about
/// constantly updating the transform. This is also my ugliest code yet! wooooo
/// </summary>
public class TestScale : MonoBehaviour
{
    // Start is called before the first frame update
    public float _scaleAmount;
    private float _scaleTop;
    private float _scaleBot;
    private float _width;
    private float _height;
    public float _initialHeight;

    public float goal_height;
    public bool button = false;



    SpriteRenderer spriteRenderer;

    Vector3 conOfCurrent;
    Vector3 recOfCurrent;
    float drop;
    float raise;
    void Awake()
    {

        conOfCurrent = transform.Find("connector").gameObject.transform.localPosition;
        recOfCurrent = transform.Find("opening").gameObject.transform.localPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        _width = spriteRenderer.size.x;
        _height = spriteRenderer.size.y;
        _initialHeight = spriteRenderer.size.y;
        _scaleTop = transform.position.y + _height / 2;
        _scaleBot = transform.position.y - _height / 2;


        drop = _scaleTop - transform.Find("connector").gameObject.transform.position.y;
        raise = _scaleBot - transform.Find("opening").gameObject.transform.position.y;
        SetHeightToScaleFrom();
    }

    // Update is called once per frame
    /// <summary>
    /// Annoying work around because have to set the transform position
    /// dynamically to keep up with scale. Only to be called once every time we
    /// drop the object. This is annoyingly hacky. 
    /// </summary>
    public void SetHeightToScaleFrom()
    {
        _scaleTop = transform.position.y + _height / 2;
        _scaleBot = transform.position.y - _height / 2;


        ////drop = _scaleTop - transform.Find("connector").gameObject.transform.position.y;
        //raise = _scaleBot - transform.Find("opening").gameObject.transform.position.y ;
    }
    public void SetHeight(float number)
    {
        SetHeightToScaleFrom();
        Vector3 connectorPos = transform.Find("connector").gameObject.transform.position;
        Vector3 openingPos = transform.Find("opening").gameObject.transform.position;

        _height = _initialHeight + number * _scaleAmount;

        float diff = (_scaleTop - _height / 2) - transform.position.y;

        spriteRenderer.size = new Vector2(_width, _height);
        transform.position += new Vector3(0, diff,
            0);

        foreach (Transform child in transform)
        {
            if (child != transform)
            {
                child.position -= new Vector3(0, diff,
            0);
            }
        }

        transform.Find("connector").gameObject.transform.position = new Vector3(connectorPos.x, _scaleTop - drop, connectorPos.y);
        transform.Find("opening").gameObject.transform.position = new Vector3(openingPos.x, -raise + transform.position.y - _height / 2, openingPos.y);
    }

    public void Update()
    {
        if (button)
        {
            SetHeight(goal_height);
        }
        button = false;
        //GameObject connector = this.transform.Find("connector").gameObject;
        //GameObject opening = this.transform.Find("opening").gameObject;
        ////_height += .001f;
        //spriteRenderer.size = new Vector2(_width, _height);
        //transform.position = new Vector3(transform.position.x, _scalePoint - _height / 2,
        //    transform.position.z);
        ////connector.transform.position = new Vector3(conOfCurrent.x, drop, conOfCurrent.z);
    }
}
