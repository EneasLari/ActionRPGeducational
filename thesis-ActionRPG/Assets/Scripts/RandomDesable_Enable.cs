using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDesable_Enable : MonoBehaviour {
    [Range(0,100)]
    public float enablePropability = 20;
	// Use this for initialization
	void Start () {

        if (enablePropability < Random.Range(0f, 100f)) {
            gameObject.SetActive(false);
        }
	}
	
}
