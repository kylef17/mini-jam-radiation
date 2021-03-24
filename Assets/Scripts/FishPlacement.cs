using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FishPlacement : MonoBehaviour
{
    /*public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject fish4;
    public GameObject fish5;
    //public GameObject fish6;
    //public GameObject fish7;*/
    public GameObject fishDragPrefab;
    private TempFishCollision tempFish;
    private FishGenerator tempFishGenerator;
    public GameObject selectedFish;
    public bool fishHeld;
    private bool prefabCreated;
    public bool placeable;
    private Vector3 mousePos;
    public LayerMask collisionLayer;

    public bool cloneFish;
    public event Action notPlaced;
    public event Action Placed;

    public HotbarControl hotbarControl;
    public IonPoints ionPoints;
    public StatDisplay statDisplay;

    void Start()
    {
        fishHeld = false;
        prefabCreated = false;
        placeable = true;
    }

    void Update()
    {
        SetMousePos();

        if (fishHeld)
        {
            DisplayFish();
            statDisplay.ShowDisplay(selectedFish);
            if (Input.GetMouseButtonDown(0))
            {
                if (tempFish.placeable)
                {
                    GameObject placedFish = Instantiate(selectedFish, mousePos, Quaternion.identity);
                    placedFish.SetActive(true);
                    placedFish.GetComponent<FishController>().enabled = true;
                    placedFish.GetComponent<FishIonPoints>().isDummy = false;
                    SetTargetVisible(placedFish);
                    placedFish.name = "FrankenFish";
                    SoundManager.PlaySound(SoundManager.Sound.placeFish);
                    ResetDragFish();
                    Placed();

                    if (!cloneFish)
                    {
                        ionPoints.SubtractIonPoints(placedFish.GetComponent<FishIonPoints>().cost);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                ResetDragFish();
                notPlaced();
            }           
        }
    }

    private void ResetDragFish()
    {
        Destroy(tempFish.gameObject);
        fishHeld = false;
        prefabCreated = false;
        placeable = true;
        selectedFish = null;
        statDisplay.HideDisplay();
    }

    private void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }

    public void CancelPlace()
    {
        ResetDragFish();
        notPlaced();
    }

    private void DisplayFish()
    {
        if (!prefabCreated)
        {
            Instantiate(fishDragPrefab, mousePos, Quaternion.identity);
            prefabCreated = true;
            tempFish = GameObject.Find("FishDrag(Clone)").GetComponent<TempFishCollision>();
            tempFishGenerator = tempFish.GetComponent<FishGenerator>();
            tempFishGenerator.head = selectedFish.GetComponent<FishGenerator>().head;
            tempFishGenerator.body = selectedFish.GetComponent<FishGenerator>().body;
            tempFishGenerator.tail = selectedFish.GetComponent<FishGenerator>().tail;
            tempFish.GetComponent<BoxCollider2D>().size = selectedFish.GetComponent<BoxCollider2D>().size + new Vector2(.2f, .2f);
        }
        tempFish.transform.position = mousePos;
        tempFishGenerator.headObject.GetComponent<SpriteRenderer>().color = tempFish.color;
        tempFishGenerator.bodyObject.GetComponent<SpriteRenderer>().color = tempFish.color;
        tempFishGenerator.tailObject.GetComponent<SpriteRenderer>().color = tempFish.color;
    }

    public void OverworldFishSelect(GameObject fish)
    {
        fishHeld = true;
        selectedFish = fish;
        cloneFish = true;
    }

    private void HotbarFishSelect(int index)
    {
        if (ionPoints.checkIonPoints(hotbarControl.getFish(index).GetComponent<FishIonPoints>().cost))
        {
            if (hotbarControl.getFish(index) != null && !hotbarControl.fishAssign)
            {
                fishHeld = true;
                selectedFish = hotbarControl.getFish(index);
                cloneFish = false;
            }
        } 
    }

    public void ShopFishSelect(GameObject fish)
    {
        fishHeld = true;
        selectedFish = fish;
        cloneFish = false;
    }

    public void Fish1Select()
    {
        HotbarFishSelect(0);
    }

    public void Fish2Select()
    {
        HotbarFishSelect(1);
    }

    public void Fish3Select()
    {
        HotbarFishSelect(2);
    }
    public void Fish4Select()
    {
        HotbarFishSelect(3);
    }
    public void Fish5Select()
    {
        HotbarFishSelect(4);
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
}
