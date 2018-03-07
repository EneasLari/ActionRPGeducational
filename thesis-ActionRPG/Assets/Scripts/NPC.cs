using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    //Dialogue Trigger script
    public Dialogue dialogue;


    // Use this for initialization
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void TriggerEndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }

}
