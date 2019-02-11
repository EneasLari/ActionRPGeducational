using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsToComplete : MonoBehaviour {
    //*******************************************************************************************************
    //TO DO:here we share the quests to npcs,every npc must have a list of quest,quests must be assigned here!

    public bool noQuests = false;
    public GameObject[] questsArray;
    private Queue<GameObject> quests=new Queue<GameObject>();

    private void Start()
    {
        foreach (GameObject g in questsArray) {
            //print("BAZO STOIXEIO"+g);
            quests.Enqueue(g);
        }
    }

    public GameObject getQuest() {
        if (quests.Count > 0)
        {
            if (quests.Count == 1) {
                noQuests = true;
            }            
            GameObject g = quests.Dequeue();
            return g;
        }
        return null;
    }
}
