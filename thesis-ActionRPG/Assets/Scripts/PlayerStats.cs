using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public int points=0;
    public Text pointsText;
    public int TxtIncrWhenAddingPoints = 20;

    public void AddPoints(int addpoints) {
        StopAllCoroutines();
        StartCoroutine(ScoreAdd(addpoints));
    }
    IEnumerator ScoreAdd(int addpoints)
    {
        yield return new WaitForSeconds(1.1f);
        Vector3 newpos = new Vector3(Screen.width/2, Screen.height / 2,0);
        Vector3 currentpos = pointsText.rectTransform.position;
        pointsText.rectTransform.position=newpos;
        for (int i=0;i<addpoints/10;i++) {            
            points = points + 10;
            pointsText.text = "" + points;
            pointsText.fontSize += TxtIncrWhenAddingPoints;
            pointsText.alignment = TextAnchor.MiddleCenter;
            yield return new WaitForSeconds(.1f);
            pointsText.fontSize -= TxtIncrWhenAddingPoints;
            yield return new WaitForSeconds(.1f);
        }
        pointsText.rectTransform.position = currentpos;
        pointsText.alignment = TextAnchor.UpperLeft;
    }

    // Use this for initialization
    void Start () {
           pointsText.text = "" + points;
    }	
}
