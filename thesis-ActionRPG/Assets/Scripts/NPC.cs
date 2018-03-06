using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    //Dialogue Trigger script

    public Dialogue dialogue;

    // Use this for initialization
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
