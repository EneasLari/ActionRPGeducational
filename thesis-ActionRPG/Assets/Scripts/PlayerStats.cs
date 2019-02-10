using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public int health = 100;
    public int protection=0;


    public void TakeDamege(int damage){
        damage = damage - protection;
        health =health - damage;
        print("palyer took damage");
    }

    public void AddProtection(int prot) {
        protection = protection + prot;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
