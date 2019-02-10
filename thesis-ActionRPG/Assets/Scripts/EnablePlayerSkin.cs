﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnablePlayerSkin : MonoBehaviour {
    public GameObject skinToEnable;
    public int minPointsToUnlock = 100;
    public void Start()
    {
        GameObject global = GameObject.FindGameObjectWithTag("GlobalVariables");
        
        if (gameObject.transform.GetSiblingIndex() < global.GetComponent<SkinsToUnlock>().skins.Length)
        {
            skinToEnable = global.GetComponent<SkinsToUnlock>().skins[gameObject.transform.GetSiblingIndex()];
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(EnableThisSkin);
        }
        
    }
    public void EnableThisSkin() {

        int count = gameObject.transform.parent.childCount;
        EnablePlayerSkin child;
        for (int i = 0; i < count; i++)
        {
            child = gameObject.transform.parent.GetChild(i).gameObject.GetComponent<EnablePlayerSkin>();
            if (child!=null && child.skinToEnable!=null &&  child.skinToEnable.activeInHierarchy==true) {
                child.skinToEnable.SetActive(false);
            }            
        }
        if (skinToEnable!=null) {
            if (GameObject.FindGameObjectWithTag("GlobalVariables").GetComponent<PlayerStats>().points > minPointsToUnlock)
            {
                skinToEnable.SetActive(true);
            }
            else {
                print("YOU HAVE NO ENOUGH POINTS");
            }
        }
    }

}