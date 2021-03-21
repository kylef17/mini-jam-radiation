using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RadiationGun : MonoBehaviour
{

    public Animator anim;
    private Vector3 mousePos;
    private bool isBeaming;
    public float beamTime;
    public LayerMask collisionLayer;

    public List<GameObject> beamedFishList = new List<GameObject>();

    void Start()
    {
        anim = GetComponent<Animator>();
        isBeaming = false;
    }
    void Update()
    {
        SetMousePos();
        transform.position = mousePos;
        anim.SetBool("isBeaming", isBeaming);

        if (Input.GetMouseButton(0))
        {
            isBeaming = true;
        } else
        {
            isBeaming = false;
            foreach (GameObject fish in beamedFishList)
            {
                fish.GetComponent<FishEditor>().beenBeamed = false;
                if (fish.GetComponent<FishEditor>().beam != null)
                {
                    StopCoroutine(fish.GetComponent<FishEditor>().beam);
                }
            }
        }

        if (isBeaming && beamedFishList.Count != 0)
        {
            foreach (GameObject fish in beamedFishList)
            {
                if (!fish.GetComponent<FishEditor>().beenBeamed)
                {
                    fish.GetComponent<FishEditor>().beam = beamTheFish(fish);
                    StartCoroutine(fish.GetComponent<FishEditor>().beam);
                    fish.GetComponent<FishEditor>().beenBeamed = true;
                }
            }
        }
    }
    private void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((collisionLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            beamedFishList.Add(other.gameObject);
        }     
    }

    void OnTriggerExit2D(Collider2D other)
    {       
        if ((collisionLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            beamedFishList.Remove(other.gameObject);
            if (other.GetComponent<FishEditor>().beam != null)
            {
                StopCoroutine(other.GetComponent<FishEditor>().beam);
            }
            other.GetComponent<FishEditor>().beenBeamed = false;
        }
    }
    private IEnumerator beamTheFish(GameObject beamedFish)
    {
        yield return new WaitForSeconds(beamTime);
        Debug.Log("color change");
        beamedFish.GetComponent<FishEditor>().RandomColorChangeFullBody();
        beamedFish.GetComponent<FishEditor>().beenBeamed = false;
    }
}
