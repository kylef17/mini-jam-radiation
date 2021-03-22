using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public LayerMask fishLayer;
    public FishPlacement fishPlacement;

    public GameObject currentFish;

    private Vector3 mousePos;
    public bool overFish;

    void Start()
    {
        currentFish = null;
    }

    void Update()
    {
        SetMousePos();
        transform.position = mousePos;

        if (overFish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(currentFish);
                SoundManager.PlaySound(SoundManager.Sound.trash);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((fishLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            overFish = true;
            currentFish = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (true)
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
