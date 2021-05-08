using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] _listOfPositions;
    Vector3 _target;
    Vector3 _dirNormalized;
    Vector3 _rotNormalized;
    Vector3 _targetRot;
    float _speed;
    int _postion = 0;
    bool _arrow = false;
    bool _unArrow = false;
    float _fadeSpeed;
    Utils _utils = new Utils();

    public void Show()
    {
        _arrow = true;
        _unArrow = false;
        _fadeSpeed = 2 * Time.deltaTime;
        enabled = true;

    }
    public void Hide()
    {
        _unArrow = true;
        _arrow = false;
        _fadeSpeed = 2 * Time.deltaTime;
        enabled = true;
    }
    void Start()
    {
        _listOfPositions = GameObject.Find("Tutorial Positions").GetComponentsInChildren<Transform>();
        List<Transform> lst = new List<Transform>();
        lst.AddRange(_listOfPositions);
        lst.Remove(GameObject.Find("Tutorial Positions").transform);
        _listOfPositions = lst.ToArray();
        transform.position = _listOfPositions[0].position;
    }

    public void StartArrowAt(int index)
    {
        transform.position = _listOfPositions[index].position;
    }

    public void NextArrow()
    {
        if (_postion + 1 < _listOfPositions.Length)
        {
            _postion += 1;
            _target = _listOfPositions[_postion].position;
            _targetRot = _listOfPositions[_postion].forward;
            _dirNormalized = (_target - transform.position).normalized;
            _rotNormalized = (_targetRot - transform.forward).normalized;
            _speed = 2 * Time.deltaTime;
            enabled = true;
        }
    }

    void Update()
    {
        if (Vector2.Distance(_target, transform.position) <= .1f && Vector2.Distance(_targetRot, transform.forward) <= .1f)
        {
            enabled = false;
        }
        if (Vector2.Distance(_target, transform.position) > .1f)
        {
            transform.position = transform.position + _dirNormalized * _speed;
        }
        if (Vector2.Distance(_targetRot, transform.forward) > .1f)
        {
            transform.forward += _rotNormalized * _speed;
        }
        if (_arrow) _utils.FadeIn(GameObject.Find("_arrow").GetComponent<SpriteRenderer>(), 1);
        if (_unArrow) _utils.FadeOut(GameObject.Find("_arrow").GetComponent<SpriteRenderer>(), 1);
    }
}
