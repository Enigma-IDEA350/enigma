using UnityEngine;

public class Elbow : MonoBehaviour
{
    private float _speed;
    private Transform _target;
    private bool _goRight;
    private bool _goLeft;
    private float _leftClamp;
    private float _rightClamp;

    void Update()
    {

        if (transform.eulerAngles.z <= _leftClamp)
        {
            _goRight = true;
            _goLeft = false;
        }
        if (transform.eulerAngles.z >= _rightClamp)
        {
            _goRight = false;
            _goLeft = true;
        }

        if (_goLeft)
        {
            Vector3 zAxis = new Vector3(0, 0, -1);
            transform.RotateAround(_target.position, zAxis, ((_speed * Random.Range(0, 3)) * Time.deltaTime));
        }

        if (_goRight)
        {
            Vector3 zAxis = new Vector3(0, 0, 1);
            transform.RotateAround(_target.position, zAxis, ((_speed * Random.Range(0, 3)) * Time.deltaTime));
        }
    }
}
