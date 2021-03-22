using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FishEditor : MonoBehaviour
{
    public enum FishType { clown, dory, loach, tang, gulp }

    public FishType headType;
    public FishType bodyType;
    public FishType tailType;

    public Colors DoryColors;
    public Colors ClownColors;
    public Colors LoachColors;
    public Colors TangColors;
    public Colors GulpColors;
    public FishGenerator fishGen;
    public FishController fishController;

    public float speedChangeRange;
    public bool beenBeamed;
    public IEnumerator beam;

    void Start()
    {
        fishGen = gameObject.GetComponent<FishGenerator>();
        fishController = gameObject.GetComponent<FishController>();
        beenBeamed = false;
    }

    public void RandomColorChangeFullBody()
    {
        System.Random rand = new System.Random();
        int randomInt = rand.Next(0, 5);
        Colors colorToUse;

        if (headType == FishType.dory)
        {
            colorToUse = DoryColors;
        } else if (headType == FishType.clown)
        {
            colorToUse = ClownColors;
        } else if (headType == FishType.loach)
        {
            colorToUse = LoachColors;
        } else if (headType == FishType.tang)
        {
            colorToUse = TangColors;
        } else if (headType == FishType.gulp)
        {
            colorToUse = GulpColors;
        }
        else
        {
            colorToUse = DoryColors;
        }

        if (fishGen.head == colorToUse.headColors[randomInt])
        {
            RandomColorChangeFullBody();
        } else
        {
            fishGen.head = colorToUse.headColors[randomInt];
            fishGen.body = colorToUse.bodyColors[randomInt];
            fishGen.tail = colorToUse.tailColors[randomInt];
        }
    }

    public void speedChange()
    {
        float changeAmount = UnityEngine.Random.Range(0f, speedChangeRange);
        if (UnityEngine.Random.value > 0.7f)
        {
            fishController.moveSpeed += changeAmount;
        }
    }
}
