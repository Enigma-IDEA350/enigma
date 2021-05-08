using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] listOfPositions;
    [SerializeField] Vector3 target;
    [SerializeField] Vector3 dirNormalized;
    [SerializeField] Vector3 rotNormalized;
    [SerializeField] Vector3 targetRot;

    [SerializeField] float speed;

    [SerializeField] int postion = 0;

    public int getListLen() { return listOfPositions.Length; }
    ChatBubble messages;
    bool arrow = false;
    bool unArrow = false;
    next next;
    float fadeSpeed;

    Utils utils = new Utils();

    public void show()
    {
        arrow = true;
        unArrow = false;
        fadeSpeed = 2 * Time.deltaTime;
        enabled = true;

    }
    public void hide()
    {
        unArrow = true;
        arrow = false;
        fadeSpeed = 2 * Time.deltaTime;
        enabled = true;
    }
    void Start()
    {
        listOfPositions = GameObject.Find("Tutorial Positions").GetComponentsInChildren<Transform>();
        List<Transform> lst = new List<Transform>();
        lst.AddRange(listOfPositions);
        lst.Remove(GameObject.Find("Tutorial Positions").transform);
        listOfPositions = lst.ToArray();
        transform.position = listOfPositions[0].position;
    }

    public void startArrowAt(int index)
    {
        transform.position = listOfPositions[index].position;
    }

    public void nextArrow()
    {
        if (postion + 1 < listOfPositions.Length)
        {
            postion += 1;
            target = listOfPositions[postion].position;
            targetRot = listOfPositions[postion].forward;
            dirNormalized = (target - transform.position).normalized;
            rotNormalized = (targetRot - transform.forward).normalized;
            speed = 2 * Time.deltaTime;
            enabled = true;
        }
    }

    void Update()
    {
        if (Vector2.Distance(target, transform.position) <= .1f && Vector2.Distance(targetRot, transform.forward) <= .1f)
        {
            enabled = false;
        }
        if (Vector2.Distance(target, transform.position) > .1f)
        {
            transform.position = transform.position + dirNormalized * speed;
        }
        if (Vector2.Distance(targetRot, transform.forward) > .1f)
        {
            transform.forward += rotNormalized * speed;
        }
        if (arrow) utils.fadeIn(GameObject.Find("arrow").GetComponent<SpriteRenderer>(), 1);
        if (unArrow) utils.fadeOut(GameObject.Find("arrow").GetComponent<SpriteRenderer>(), 1);
    }
}
