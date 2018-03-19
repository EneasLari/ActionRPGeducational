using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int damageOfWeapon=1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) {

            //other.gameObject.GetComponent<PlayerStats>().TakeDamege(damageOfWeapon);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
