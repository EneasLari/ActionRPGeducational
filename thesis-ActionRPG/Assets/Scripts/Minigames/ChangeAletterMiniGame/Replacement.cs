using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacement : MonoBehaviour {

    public GameObject replaceObject;

    public void replace() {
        Vector3 pos = this.transform.position;
        Instantiate(replaceObject, pos, replaceObject.transform.rotation);
        Destroy(gameObject);
    }
}
