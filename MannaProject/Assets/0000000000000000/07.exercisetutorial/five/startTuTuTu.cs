using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTuTuTu : MonoBehaviour {

    public GameObject tu;

    // Use this for initialization
    void Start () {
        tu.GetComponent<goIntroFive>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
