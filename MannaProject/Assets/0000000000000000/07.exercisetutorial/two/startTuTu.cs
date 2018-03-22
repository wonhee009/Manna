using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTuTu : MonoBehaviour {

    public GameObject tu;

	// Use this for initialization
	void Start () {
        tu.GetComponent<goIntro>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
