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
    public bool isFish2;

    void Start()
    {
        fishGen = gameObject.GetComponent<FishGenerator>();
        fishController = gameObject.GetComponent<FishController>();
        beenBeamed = false;
        isFish2 = false;
    }

    public void RandomColorChangeFullBody()
    {
        System.Random rand = new System.Random();
        int randomInt = rand.Next(0, 5);
        Colors headcolorToUse = SelectColorsToUse(headType);
        Colors bodycolorToUse = SelectColorsToUse(bodyType);
        Colors tailcolorToUse = SelectColorsToUse(tailType);
        if (fishGen.head == headcolorToUse.headColors[randomInt] || fishGen.body == bodycolorToUse.headColors[randomInt] || fishGen.tail == tailcolorToUse.headColors[randomInt])
        {
            RandomColorChangeFullBody();
        } else
        {
            fishGen.head = headcolorToUse.headColors[randomInt];
            fishGen.body = bodycolorToUse.bodyColors[randomInt];
            fishGen.tail = tailcolorToUse.tailColors[randomInt];
        }
    }

    public Colors SelectColorsToUse(FishType type)
    {
        if (type == FishType.dory)
        {
            return DoryColors;
        }
        else if (type == FishType.clown)
        {
            return ClownColors;
        }
        else if (type == FishType.loach)
        {
            return LoachColors;
        }
        else if (type == FishType.tang)
        {
            return TangColors;
        }
        else if (type == FishType.gulp)
        {
            return GulpColors;
        }
        else
        {
            return DoryColors;
        }
    }

    public void ColorSwap(GameObject fish1, GameObject fish2)
    {
        System.Random rand = new System.Random();
        int randomInt = rand.Next(0, 3);

        FishGenerator fish1Gen = fish1.GetComponent<FishGenerator>();
        FishGenerator fish2Gen = fish2.GetComponent<FishGenerator>();
        FishEditor fish1Edit = fish1.GetComponent<FishEditor>();
        FishEditor fish2Edit = fish2.GetComponent<FishEditor>();
        fish2Edit.isFish2 = true;
        if (randomInt == 0)
        {
            if (fish1Gen.head == fish2Gen.head)
            {
                RandomColorChangeFullBody();
                fish2Edit.RandomColorChangeFullBody();
            }
            Sprite tempSprite = fish1Gen.head;
            FishType tempType = fish1Edit.headType;
            fish1Gen.head = fish2Gen.head;
            fish2Gen.head = tempSprite;
            fish1Edit.headType = fish2Edit.headType;
            fish2Edit.headType = tempType;
        } else if (randomInt == 1)
        {
            if (fish1Gen.body == fish2Gen.body)
            {
                RandomColorChangeFullBody();
                fish2Edit.RandomColorChangeFullBody();
            }
            Sprite tempSprite = fish1Gen.body;
            FishType tempType = fish1Edit.bodyType;
            fish1Gen.body = fish2Gen.body;
            fish2Gen.body = tempSprite;
            fish1Edit.bodyType = fish2Edit.bodyType;
            fish2Edit.bodyType = tempType;
        } else if (randomInt == 2)
        {
            if (fish1Gen.tail == fish2Gen.tail)
            {
                RandomColorChangeFullBody();
                fish2Edit.RandomColorChangeFullBody();
            }
            Sprite tempSprite = fish1Gen.tail;
            FishType tempType = fish1Edit.tailType;
            fish1Gen.tail = fish2Gen.tail;
            fish2Gen.tail = tempSprite;
            fish1Edit.tailType = fish2Edit.tailType;
            fish2Edit.tailType = tempType;
        }
        fish2.GetComponent<FishIonPoints>().AddRadLevel();
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
