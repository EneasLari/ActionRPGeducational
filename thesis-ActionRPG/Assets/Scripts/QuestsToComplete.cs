using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsToComplete : MonoBehaviour {
    public bool noQuests = false;
    public GameObject[] questsArray;
    private Queue<GameObject> quests=new Queue<GameObject>();

    private void Start()
    {
        foreach (GameObject g in questsArray) {
            print("BAZO STOIXEIO"+g);
            quests.Enqueue(g);
        }
    }

    public void getQuest() {
        if (quests.Count > 0)
        {
            if (quests.Count == 1) {
                noQuests = true;
            }
            GameObject g = quests.Dequeue();
            g.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").transform.parent.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
    }
}
