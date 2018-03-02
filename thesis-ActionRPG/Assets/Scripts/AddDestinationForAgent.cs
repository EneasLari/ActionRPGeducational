using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AddDestinationForAgent : MonoBehaviour {
    private GameObject[] global;
    // Use this for initialization
    void Start () {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        global[0].GetComponent<GlobalVariables>().wps.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
