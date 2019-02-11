using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag.Equals("Player")) {
            //print("(TRIGGER ENTER)");
            this.GetComponentInParent<Animator>().SetFloat("isWalking", 0);
            
            GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>().DialogTrigerer = gameObject;
            gameObject.GetComponentInParent<NPC>().TriggerDialogue();
            this.GetComponentInParent<NavMeshAgent>().enabled = false;
            this.GetComponentInParent<Wander>().enabled = false;                   
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            this.GetComponentInParent<Animator>().SetFloat("isWalking", 1);
            //print("(TRIGGER EXIT)");
            GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>().DialogTrigerer = null;
            this.GetComponentInParent<NavMeshAgent>().enabled = true;
            this.GetComponentInParent<Wander>().enabled = true;           
            gameObject.GetComponentInParent<NPC>().TriggerEndDialogue();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
