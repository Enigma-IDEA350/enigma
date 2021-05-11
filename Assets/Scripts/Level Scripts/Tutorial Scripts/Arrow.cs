using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] _listOfPositions;
    Vector3 _target;
    Vector3 _dirNormalized;
    Quaternion _targetRot;
    float _speed;
    int _postion = 0;
    Utils _utils = new Utils();

    public void Show()
    {
        _utils.FadeIn(GameObject.Find("arrow").GetComponent<SpriteRenderer>());
    }
    public void Hide()
    {
        _utils.FadeOut(GameObject.Find("arrow").GetComponent<SpriteRenderer>());
    }
    void Start()
    {
        _utils.setMono(this);
        _listOfPositions = GameObject.Find("Tutorial Positions").GetComponentsInChildren<Transform>();
        List<Transform> lst = new List<Transform>();
        lst.AddRange(_listOfPositions);
        lst.Remove(GameObject.Find("Tutorial Positions").transform);
        _listOfPositions = lst.ToArray();
        _targetRot.eulerAngles = _listOfPositions[0].eulerAngles;
        transform.position = _listOfPositions[0].position;
        transform.rotation = _targetRot;
    }
    public void NextArrow()
    {
        _postion += 1;
        _targetRot.eulerAngles = _listOfPositions[_postion].eulerAngles;
        transform.rotation = _targetRot;
        transform.position = _listOfPositions[_postion].localPosition;
    }
}
