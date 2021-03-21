using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPickup : MonoBehaviour
{
    public LayerMask fishLayer;
    public FishPlacement fishPlacement;

    public GameObject currentFish;

    private Vector3 mousePos;
    private Vector3 savedFishPos;
    private Quaternion savedFishRotation;
    public bool overFish;
    public bool holdingFish;

    public bool noOtherTools;

    void Start()
    {
        fishPlacement.notPlaced += ResetFish;
        fishPlacement.Placed += PickupComplete;
        holdingFish = false;
        currentFish = null;
    }

    void Update()
    {
        SetMousePos();
        transform.position = mousePos;
        holdingFish = fishPlacement.fishHeld;

        if (overFish)
        {
            if (Input.GetMouseButtonDown(0) && !holdingFish)
            {
                Pickup();
                //holdingFish = true;
            }
        }
    }

    private void Pickup()
    {
        fishPlacement.OverworldFishSelect(currentFish);
        savedFishPos = currentFish.transform.position;
        savedFishRotation = currentFish.transform.rotation;
        SetTargetInvisible(currentFish);
    }

    void SetTargetInvisible(GameObject Target)
    {
        Component[] a = Target.GetComponentsInChildren(typeof(Renderer));
        foreach (Component b in a)
        {
            Renderer c = (Renderer)b;
            c.enabled = false;
        }
    }

    void SetTargetVisible(GameObject Target)
    {
        Component[] a = Target.GetComponentsInChildren(typeof(Renderer));
        foreach (Component b in a)
        {
            Renderer c = (Renderer)b;
            c.enabled = true;
        }
    }

    void ResetFish()
    {
        currentFish.transform.position = savedFishPos;
        currentFish.transform.rotation = savedFishRotation;
        SetTargetVisible(currentFish);
        currentFish = null;
        //holdingFish = false;
        overFish = false;
    }

    void PickupComplete()
    {
        if (fishPlacement.cloneFish)
        {
            Destroy(currentFish);
            currentFish = null;
            overFish = false;
           // holdingFish = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!holdingFish && noOtherTools)
        {
            if ((fishLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                overFish = true;
                currentFish = other.gameObject;
            }
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!holdingFish)
        {
            if ((fishLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                overFish = false;
                currentFish = null;
            }
        }   
    }

    private void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }
}
