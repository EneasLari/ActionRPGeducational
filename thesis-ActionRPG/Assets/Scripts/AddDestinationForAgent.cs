using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AddDestinationForAgent : MonoBehaviour {
    private GameObject[] global;
    // Use this for initialization
    void Start () {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        global[0].GetComponent<GlobalDestinations>().wps.Add(gameObject);
        //Wander.wps.Add(gmobj);
        //print("After:"+ Wander.wps[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
