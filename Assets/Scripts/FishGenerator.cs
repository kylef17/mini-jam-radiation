using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public Sprite head;
    public Sprite body;
    public Sprite tail;
    public GameObject headObject;
    public GameObject bodyObject;
    public GameObject tailObject;

    void Start()
    {
        headObject = transform.GetChild(0).gameObject;
        bodyObject = transform.GetChild(1).gameObject;
        tailObject = transform.GetChild(2).gameObject;

        headObject.GetComponent<SpriteRenderer>().sprite = head;
        bodyObject.GetComponent<SpriteRenderer>().sprite = body;
        tailObject.GetComponent<SpriteRenderer>().sprite = tail;
    }

    void Update()
    {
        if (headObject.GetComponent<SpriteRenderer>().sprite != head)
        {
            headObject.GetComponent<SpriteRenderer>().sprite = head;
        }
        if (bodyObject.GetComponent<SpriteRenderer>().sprite != body)
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite = body;
        }
        if (tailObject.GetComponent<SpriteRenderer>().sprite != tail)
        {
            tailObject.GetComponent<SpriteRenderer>().sprite = tail;
        }
    }
}
