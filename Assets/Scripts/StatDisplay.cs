using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatDisplay : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    public CanvasGroup cGroup;
    private Vector3 mousePos;

    void Start()
    {
        HideDisplay();
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
        int pointsPerSecond = fish.GetComponent<FishIonPoints>().pointsPerSecond;

        gameObject.transform.GetChild(0).GetComponent<Text>().text = "Cost: " + cost.ToString() + "\n" + "Rad. Level: " + radLevel.ToString() + "\n" + "Points/s: " + pointsPerSecond.ToString();
    }

    public void HideDisplay()
    {
        cGroup.alpha = 0f;
        cGroup.blocksRaycasts = false;
    }

    private void SetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }
}
