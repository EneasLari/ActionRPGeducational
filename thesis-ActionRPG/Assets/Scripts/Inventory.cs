using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    private Animator inventoryAnimator;
    private bool isOpen = false;

    public void OpenCloseInventory()
    {
        //print(isOpen);
        if (isOpen)
        {
            inventoryAnimator.SetBool("isOpen", false);
            isOpen = false;
        }
        else {

            inventoryAnimator.SetBool("isOpen", true);
            isOpen = true;
        }
        
    }


    // Use this for initialization
    void Start () {
        inventoryAnimator = gameObject.GetComponent<Animator>();
    }
	

}
