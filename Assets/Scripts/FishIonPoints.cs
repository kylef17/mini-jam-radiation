using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishIonPoints : MonoBehaviour
{
    public int pointsPerSecond;
    public int radLevel;
    public int radLevelIncrease;
    public int radLevelCostIncrease;
    public int cost;
    public IonPoints ionPoints;

    private bool isRunning;

    void Start()
    {
        ionPoints = GameObject.Find("GameController").GetComponent<IonPoints>();
    }
    void Update()
    {
        if (!isRunning)
        {
            isRunning = true;
            IEnumerator co = addPoints(pointsPerSecond);
            StartCoroutine(co);
        }
    }

    public void AddRadLevel()
    {
        radLevel += 1;
        pointsPerSecond += radLevelIncrease;
        cost += radLevelCostIncrease;
    }

    
    private IEnumerator addPoints(int pointsPerSecond)
    {
        yield return new WaitForSeconds(1);
        ionPoints.AddIonPoints(pointsPerSecond);
        isRunning = false;
    }
}
