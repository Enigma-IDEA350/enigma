using UnityEngine;

public class dial : MonoBehaviour
{
    private Vector3 _degree;
    private int nextUpdate = 1;

    // Update is called once per frame
    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

    }

    // Update is called once per second
    void UpdateEverySecond()
    {
        float x = _degree.x;
        float y = _degree.y;
        float z = _degree.z;
        transform.Rotate(x, y, z);
    }
}
