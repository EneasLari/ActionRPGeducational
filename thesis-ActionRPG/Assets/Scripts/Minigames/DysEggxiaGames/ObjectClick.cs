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
                        print("You took out the extra letter BRAVO!");
                    }
                    else if (bc.gameObject.name.Equals("+(Clone)")) {
                        DestroyObject(bc.gameObject);
                        print("YOU SEPARATED THE WORDS EXCELLENT");
                    }
                }

            }
        }
	}
}
