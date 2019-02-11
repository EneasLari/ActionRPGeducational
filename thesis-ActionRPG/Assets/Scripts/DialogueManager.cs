using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {

    public Text npcNameText;
    public Text dialogueText;
    public Animator boxanimator;
    public GameObject DialogTrigerer;//Its being initialized by CollisionTrigger
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue) {
        boxanimator.SetBool("isOpen",true);
        //print("Starting dialogue");
        npcNameText.text = dialogue.npcName;

        sentences.Clear();//if sentences queue have previus elements we must clear it

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void  DisplayNextSentence() {
        if (sentences.Count == 0) {
            if (GameObject.FindGameObjectWithTag("MainCamera") != null && !GameObject.FindGameObjectWithTag("GlobalVariables").GetComponent<QuestsToComplete>().noQuests) {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadoutManager>().fadeIn = true;
            }           
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //print(sentence);
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue() {        
        boxanimator.SetBool("isOpen", false);
        if(DialogTrigerer!=null) {
            
            Destroy(DialogTrigerer);
            //print("END OF DIALOGUE");
        }
    }
    private void Update()
    {
        if (boxanimator.GetBool("isOpen")==true) {
            if (Input.GetMouseButtonDown(0)) {
                //print("LeftClick for next ");
                DisplayNextSentence();
            }
        }
    }
}
