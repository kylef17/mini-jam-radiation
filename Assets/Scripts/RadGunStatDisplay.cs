using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RadGunStatDisplay : MonoBehaviour
{
    public StatDisplay statDisplay;
    public Image lockImage;
    public IonPoints ionPoints;

    void Update()
    {
        if (ionPoints.checkIonPoints(400))
        {
            lockImage.gameObject.SetActive(false);
        } else
        {
            lockImage.gameObject.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        statDisplay.ShowDisplayRad();
    }
    void OnMouseExit()
    {
        statDisplay.HideDisplay();
    }
}
