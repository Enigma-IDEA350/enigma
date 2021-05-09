using UnityEngine;

public class AllDials : MonoBehaviour
{
    //public int movespeed;
    private GameObject[] _dialsOne;
    private GameObject[] _dialsTwo;
    private GameObject[] _dialsThree;
    private Vector3 _degreesOne;
    private Vector3 _degreesTwo;
    private Vector3 _degreesThree;

    private float _timeOne;
    private float _timeTwo;
    private float _timeThree;

    //public AudioSource source;
    //Creating a variable for the audio source



    void Start()
    {
        InvokeRepeating("One", _timeOne, _timeOne);
        InvokeRepeating("Two", _timeTwo, _timeTwo);
        InvokeRepeating("Three", _timeThree, _timeThree);
        //taking an audio source input 
    }

    void One()
    {
        SoundManager.PlaySound(SoundManager.Sound.Dial);
        float x = _degreesOne.x;
        float y = _degreesOne.y;
        float z = _degreesOne.z;
        _dialsOne = GameObject.FindGameObjectsWithTag("DIAL1");

        foreach (GameObject d in _dialsOne)
        {
            d.transform.Rotate(x, y, z);
        }
    }

    void Two()
    {
        float x = _degreesTwo.x;
        float y = _degreesTwo.y;
        float z = _degreesTwo.z;
        _dialsTwo = GameObject.FindGameObjectsWithTag("DIAL2");
        foreach (GameObject d in _dialsTwo)
        {
            d.transform.Rotate(x, y, z);
        }
    }

    void Three()
    {
        float x = _degreesThree.x;
        float y = _degreesThree.y;
        float z = _degreesThree.z;
        _dialsThree = GameObject.FindGameObjectsWithTag("DIAL3");
        foreach (GameObject d in _dialsThree)
        {
            d.transform.Rotate(x, y, z);
        }

    }


}
