using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChild : MonoBehaviour {

    public GameObject[] child;
    private Vector3 offset;
    void Start () {
        for (int i = 0; i < child.Length; i++)
        {
            if (child[i].gameObject.activeInHierarchy)
            {
                offset = transform.position - child[i].transform.position;

            }
        }
        
	}
	
	// Update is called once per frame
	void LateUpdate (){
        for (int i=0;i<child.Length;i++) {
            if (child[i].gameObject.activeInHierarchy) {
                    
                    transform.position = child[i].transform.position + offset; ;

            }
            if (!child[i].gameObject.activeInHierarchy)
            {
                
                child[i].transform.position=transform.position+ offset; ;

            }
        }
	}
}
