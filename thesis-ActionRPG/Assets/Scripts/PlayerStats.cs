using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public int points=0;
    public Text pointsText;
    public Text pointsTextIncreasing;
    public int TxtIncrWhenAddingPoints = 20;

    public void AddPoints(int addpoints) {
        StopAllCoroutines();
        StartCoroutine(ScoreAdd(addpoints));
    }
    IEnumerator ScoreAdd(int addpoints)
    {
        yield return new WaitForSeconds(1.1f);
        pointsText.gameObject.SetActive(false);
        pointsTextIncreasing.gameObject.SetActive(true);
        for (int i=0;i<addpoints/10;i++) {            
            points = points + 10;
            pointsTextIncreasing.text = "" + points;
            pointsTextIncreasing.fontSize += TxtIncrWhenAddingPoints;
            yield return new WaitForSeconds(.1f);
            pointsTextIncreasing.fontSize -= TxtIncrWhenAddingPoints;
            yield return new WaitForSeconds(.1f);
        }
        pointsText.gameObject.SetActive(true);
        pointsText.text = "" + points;
        pointsTextIncreasing.gameObject.SetActive(false);

    }

    // Use this for initialization
    void Start () {
           pointsText.text = "" + points;
    }	
}
