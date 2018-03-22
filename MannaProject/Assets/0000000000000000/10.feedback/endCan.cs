using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCan : MonoBehaviour {

    public GameObject can;

    private void Awake()
    {
        can.SetActiveRecursively(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
