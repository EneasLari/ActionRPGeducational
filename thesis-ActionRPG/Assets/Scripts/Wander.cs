using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour {

    private GameObject[] global;
    NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        global = GameObject.FindGameObjectsWithTag("GlobalVariables");
        StartCoroutine(Delay(3));
    }
	
	// Update is called once per frame
	void Update () {
        if (agent!=null && agent.remainingDistance < 0.5)
        {
            StartCoroutine(Delay(0));
        }
        
    }

    IEnumerator Delay(int delay)
    {
        yield return new WaitForSeconds(delay);
        agent = this.GetComponent<NavMeshAgent>();
        int d = Random.Range(0, global[0].GetComponent<GlobalDestinations>().wps.Count);
        agent.SetDestination(global[0].GetComponent<GlobalDestinations>().wps[d].transform.position);

    }

}
