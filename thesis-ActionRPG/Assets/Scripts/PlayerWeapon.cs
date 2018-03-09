using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public int damage = 10;
    public float range=100f;
	// Use this for initialization
	void Start () {
		
	}

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out hit,range)) {
            print(hit.transform.name);
            hit.transform.gameObject.GetComponent<EnemyController>().TakeDamage(damage);

        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}
}
