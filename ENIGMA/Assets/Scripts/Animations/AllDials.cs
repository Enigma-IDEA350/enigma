using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDials : MonoBehaviour
{
    //public int movespeed;
    private GameObject[] dials_one;
    private GameObject[] dials_two;
    private GameObject[] dials_three;
    public Vector3 Degrees1;
    public Vector3 Degrees2;
    public Vector3 Degrees3;

    public float Time1;
    public float Time2;
    public float Time3;

    private AudioSource audioSource;

    //public AudioSource source;
    //Creating a variable for the audio source



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("One", Time1, Time1);
        InvokeRepeating("Two", Time2, Time2);
        InvokeRepeating("Three", Time3, Time3);

        //source = GetComponent<AudioSource>();
        //taking an audio source input 
    }

    void One()
    {


        audioSource.Play();
        float x = Degrees1.x;
        float y = Degrees1.y;
        float z = Degrees1.z;
        dials_one = GameObject.FindGameObjectsWithTag("DIAL1");

        foreach (GameObject d in dials_one)
        {
            d.transform.Rotate(x, y, z);
        }
    }

    void Two()
    {
        float x = Degrees2.x;
        float y = Degrees2.y;
        float z = Degrees2.z;
        dials_two = GameObject.FindGameObjectsWithTag("DIAL2");
        foreach (GameObject d in dials_two)
        {
            d.transform.Rotate(x, y, z);
        }
    }

    void Three()
    {
        float x = Degrees3.x;
        float y = Degrees3.y;
        float z = Degrees3.z;
        dials_three = GameObject.FindGameObjectsWithTag("DIAL3");
        foreach (GameObject d in dials_three)
        {
            d.transform.Rotate(x, y, z);
        }
            
    }


}
