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
    public bool isDummy;
    public bool dummyReset;
    public int savedPointsPerSecond;
    private bool isRunning;

    void Start()
    {
        ionPoints = GameObject.Find("GameController").GetComponent<IonPoints>();
        if (isDummy)
        {
            pointsPerSecond = 0;
            dummyReset = false;
        }
    }
    void Update()
    {
        if (!isRunning)
        {
            isRunning = true;
            IEnumerator co = addPoints(pointsPerSecond);
            StartCoroutine(co);
        }

        if (!isDummy && !dummyReset)
        {
            pointsPerSecond = savedPointsPerSecond;
            dummyReset = true;
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
