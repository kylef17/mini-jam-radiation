using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionAction : MonoBehaviour
{
    public FishPlacement fishPlacement;

    void OnMouseOver()
    {
        Debug.Log("mouse over");
        fishPlacement.placeable = false;
    }

    void OnMouseExit()
    {
        fishPlacement.placeable = true;
    }
}
