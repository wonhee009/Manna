using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1CursorMode : MonoBehaviour {

    public GameObject btnController;

    private void Awake()
    {
        btnController.GetComponent<Test1Btn>().mode = 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
