﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fourButton : MonoBehaviour {

    public GameObject one;
    public GameObject two;
    public GameObject ok_not;
    public GameObject ok;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        if (one.GetComponent<Text>().text == "")
        {
            one.GetComponent<Text>().text = "4";
            this.GetComponent<fourButton>().enabled = false;
        }
        else if (two.GetComponent<Text>().text == "")
        {
            two.GetComponent<Text>().text = "4";
            ok_not.SetActiveRecursively(false);
            ok.SetActiveRecursively(true);
            ok.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<fourButton>().enabled = false;
        }
    }
}