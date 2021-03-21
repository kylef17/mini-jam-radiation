using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStatDisplay : MonoBehaviour
{
    public GameObject fish;
    public StatDisplay statDisplay;

    void OnMouseOver()
    {
        if (fish != null)
        {
            statDisplay.ShowDisplay(fish);
        }      
    }

    void OnMouseExit()
    {
        statDisplay.HideDisplay();
    }
}
