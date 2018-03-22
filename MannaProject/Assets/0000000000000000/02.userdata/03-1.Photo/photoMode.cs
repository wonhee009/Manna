using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photoMode : MonoBehaviour {

    public GameObject confirmButton;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        confirmButton.GetComponent<totalConfirmButton>().mode = 1;
        this.GetComponent<photoMode>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
