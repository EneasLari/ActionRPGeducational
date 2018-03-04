using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacement : MonoBehaviour {
    //Script to replace the gameObject when the function is beeing called
    public GameObject replaceObject;

    public void replace() {
        Vector3 pos = this.transform.position;
        Instantiate(replaceObject, pos, replaceObject.transform.rotation);
        Destroy(gameObject);
    }
}
