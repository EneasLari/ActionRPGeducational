using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag.Equals("Player")) {
            print("(TRIGGER ENTER)");
<<<<<<< HEAD
            //GetComponentInParent<Animator>().SetFloat("isWalking", 0, 0.2f, Time.deltaTime);

            GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>().DialogTrigerer = gameObject;
            gameObject.GetComponentInParent<NPC>().TriggerDialogue();
=======
>>>>>>> parent of 682910f... inventory for changing apearence ,fixing dialogue system and making inventory slots unlockable by score
            this.GetComponentInParent<NavMeshAgent>().enabled = false;
            this.GetComponentInParent<Wander>().enabled = false;                   
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && Input.GetKeyDown(KeyCode.Return)) {
            //print("(TRIGGER STAY)");
            gameObject.GetComponentInParent<NPC>().TriggerDialogue();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {
            //GetComponentInParent<Animator>().SetFloat("isWalking", 1, 0.2f, Time.deltaTime);
            print("(TRIGGER EXIT)");
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
