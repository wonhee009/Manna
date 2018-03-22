using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoControll : MonoBehaviour {

    public bool dead = false;
    public GameObject image;
    public GameObject border;
    public GameObject btnControll;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(dead == false)
        {
            this.GetComponent<deadAgain>().enabled = true;
            this.GetComponent<photoMode>().enabled = true;

            Invoke("startYN", 5);
            
            image.SetActive(true);
            border.SetActive(true);
            image.GetComponent<LoadImg>().enabled = true;
            dead = true;
        }
	}

    void startYN()
    {
        btnControll.GetComponent<StartYNBtnControll>().con = false;
    }
}
