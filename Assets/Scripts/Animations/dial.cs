using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dial : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Degrees;

    public int nextUpdate = 1;

    // Update is called once per frame
    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

    }

    // Update is called once per second
    void UpdateEverySecond()
    {
        float x = Degrees.x;
        float y = Degrees.y;
        float z = Degrees.z;
        transform.Rotate(x, y, z);
    }
}
