using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorModeSkip : MonoBehaviour {

    public GameObject controll;

	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        controll.GetComponent<Test2Btn>().mode = 1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
