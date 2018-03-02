using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAboveCube : MonoBehaviour {
    public GameObject[] alphabetprefabs;
    GameObject gm;
    // Use this for initialization
    void Start () {
        gm = alphabetprefabs[Random.Range(0, alphabetprefabs.Length)];
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + .5f, gameObject.transform.position.z);
        gm=Instantiate(gm, pos, gm.transform.rotation);
        gm.GetComponent<Rigidbody>().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
