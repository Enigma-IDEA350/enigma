using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elbow : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    

    public float speed;
    public Transform target;
    public bool goRight;
    public bool goLeft;
    public float leftClamp;
    public float rightClamp;


    private void Start()
    {
        //min = transform.position.z;
        //max = transform.position.z + max_diff;
    }

    void Update()
    {

        if (transform.eulerAngles.z <= leftClamp)
        {
            goRight = true;
            goLeft = false;
        }
        if (transform.eulerAngles.z >= rightClamp)
        {
            goRight = false;
            goLeft = true;
        }

        if (goLeft)
        {
            Vector3 zAxis = new Vector3(0, 0, -1);
            transform.RotateAround(target.position, zAxis, ((speed * Random.Range(0, 3)) * Time.deltaTime));
        }

        if (goRight)
        {
            Vector3 zAxis = new Vector3(0, 0, 1);
            transform.RotateAround(target.position, zAxis, ((speed * Random.Range(0, 3)) * Time.deltaTime));
        }
    }
}
