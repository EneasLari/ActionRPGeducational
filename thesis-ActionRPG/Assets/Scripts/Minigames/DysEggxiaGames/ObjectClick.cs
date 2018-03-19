using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit)) {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc!=null) {
                    bool rigidbodyIsNull = bc.gameObject.GetComponent<Rigidbody>() == null;
                    if (!rigidbodyIsNull && bc.gameObject.GetComponent<Rigidbody>().mass < 100)
                    {
                        bc.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadoutManager>().fadeIn = true;
                        print("You took out the extra letter BRAVO! Take 100 points");
                        GameObject.FindGameObjectWithTag("GlobalVariables").GetComponent<PlayerStats>().AddPoints(100);
                    }
                    else if (bc.gameObject.name.Equals("+(Clone)")) {
                        DestroyObject(bc.gameObject);
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadoutManager>().fadeIn = true;
                        print("YOU SEPARATED THE WORDS EXCELLENT take 150points");
                        GameObject.FindGameObjectWithTag("GlobalVariables").GetComponent<PlayerStats>().AddPoints(150);
                    }
                }

            }
        }
	}
}
