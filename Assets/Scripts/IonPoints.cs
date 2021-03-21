using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IonPoints : MonoBehaviour
{
    public int ionPoints;
    [SerializeField] Text ionPointsText;

    void Update()
    {
        if (ionPoints < 0)
        {
            ionPoints = 0;
        }

        if (ionPointsText.text != ionPoints.ToString())
        {
            UpdateText(ionPoints);
        }
    }

    public void AddIonPoints(int points)
    {
        ionPoints += points;
    }

    public void SubtractIonPoints(int points)
    {
        ionPoints -= points;
    }

    public bool checkIonPoints(int cost)
    {
        if (ionPoints >= cost)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void UpdateText(int points)
    {
        ionPointsText.text = points.ToString();
    }
}
