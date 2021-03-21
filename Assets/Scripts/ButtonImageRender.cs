using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonImageRender : MonoBehaviour
{
    public Sprite head;
    public Sprite body;
    public Sprite tail;
    public Image headImage;
    public Image bodyImage;
    public Image tailImage;

    void Start()
    {
        headImage.sprite = head;
        bodyImage.sprite = body;
        tailImage.sprite = tail;
    }

    void Update()
    {
        if (headImage.sprite != head)
        {
            headImage.sprite = head;
        }
        if (bodyImage.sprite != body)
        {
            bodyImage.sprite = body;
        }
        if (tailImage.sprite != tail)
        {
            tailImage.sprite = tail;
        }
    }
}
