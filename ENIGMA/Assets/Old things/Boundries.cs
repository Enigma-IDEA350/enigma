using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{

    private Bounds bounds;
    private float boundsWidth;
    private float boundsHeight;
    // Start is called before the first frame update
    void Start()
    {
        bounds = GameObject.Find("Bounds").GetComponent<SpriteRenderer>().bounds;
        boundsWidth = bounds.size.x;
        boundsHeight = bounds.size.y;
    }
    public bool leftEdge(Transform block)
    {
        float blockEdgeX = block.GetComponent<SpriteRenderer>().bounds.extents.x;
        float blockLeftEdge = block.position.x - blockEdgeX;
        bool onEdge = bounds.min.x >= blockLeftEdge;

        return (onEdge);
    }
    public bool rightEdge(Transform block)
    {
        float blockEdgeX = block.GetComponent<SpriteRenderer>().bounds.extents.x;
        float blockrightEdge = block.position.x + blockEdgeX;
        bool onEdge = bounds.max.x <= blockrightEdge;

        return (onEdge);
    }


    public bool topEdge(Transform block)
    {
        float blockEdgeY = block.GetComponent<SpriteRenderer>().bounds.extents.y;
        float blockTopEdge = block.position.y + blockEdgeY;
        bool onEdge = bounds.max.y <= blockTopEdge;

        return (onEdge);
    }
    public bool bottomEdge(Transform block)
    {
        float blockEdgeY = block.GetComponent<SpriteRenderer>().bounds.extents.y;
        float blockBottomtEdge = block.position.y - blockEdgeY;
        bool onEdge = bounds.min.y >= blockBottomtEdge;

        return (onEdge);
    }

}
