using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HotbarControl : MonoBehaviour
{
    public FishPlacement fishPlacement;
    public GameObject[] fish = new GameObject[5];

    public event Action addedFish;

    public bool fishAssign;
    
    public void InitHotbar()
    {
        addedFish();
    }

    private void fishButton(int index)
    {
        if (fishPlacement.fishHeld)
        {
            if (fish[index] != null)
            {
                Destroy(fish[index]);
            }
            fishAssign = true;
            fish[index] = Instantiate(fishPlacement.selectedFish, Vector2.zero, Quaternion.identity);
            fish[index].SetActive(false);
            addedFish();
            fishPlacement.CancelPlace();
        }
        else
        {
            fishAssign = false;
        }
    }

    public void button1()
    {
        fishButton(0);
    }
    public void button2()
    {
        fishButton(1);
    }
    public void button3()
    {
        fishButton(2);
    }
    public void button4()
    {
        fishButton(3);
    }
    public void button5()
    {
        fishButton(4);
    }

    public GameObject getFish(int index)
    {
        return fish[index];
    }
}
