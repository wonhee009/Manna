using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prev : MonoBehaviour {

    public GameObject prevv;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        prevv.SetActiveRecursively(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
