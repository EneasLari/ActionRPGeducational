using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCorrectLetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int randchild=Random.Range(0, transform.childCount);
        transform.GetChild(randchild).GetComponent<Dragable>().isThecorrect=true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
