using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatDisplay : MonoBehaviour
{
    private float xOffset;
    public float yOffset;
    public CanvasGroup cGroup;
    private Vector3 mousePos;

    void Start()
    {
        HideDisplay();
        xOffset = 3f;
    }

    void Update()
    {
        SetMousePos();
        transform.position = new Vector3(mousePos.x + xOffset, mousePos.y + yOffset, mousePos.z);
    }

    public void ShowDisplay(GameObject fish)
    {
        cGroup.alpha = 1f;
        int cost = fish.GetComponent<FishIonPoints>().cost;
        int radLevel = fish.GetComponent<FishIonPoints>().radLevel;
        int savedPointsPerSecond = (fish.GetComponent<FishIonPoints>().savedPointsPerSecond + (fish.GetComponent<FishIonPoints>().radLevel * fish.GetComponent<FishIonPoints>().radLevelIncrease));

        gameObject.transform.GetChild(0).GetComponent<Text>().text = "Cost: " + cost.ToString() + "\n" + "Rad. Level: " + radLevel.ToString() + "\n" + "Points/s: " + savedPointsPerSecond.ToString();
    }

    private bool xOffsetChanged;
    public void ShowDisplayRad()
    {
        cGroup.alpha = 1f;
        if (!xOffsetChanged)
        {
            Debug.Log("xoffset changed");
            xOffset = -xOffset;
            xOffsetChanged = true;
        }
        gameObject.transform.GetChild(0).GetComponent<Text>().text = "Cost: 400";
    }

    public void HideDisplay()
    {
        cGroup.alpha = 0f;
        if (xOffsetChanged)
        {
            xOffset = -xOffset;
            xOffsetChanged = false;
        }
        cGroup.blocksRaycasts = false;
    }

    private void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }
}
