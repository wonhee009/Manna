using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadAgain : MonoBehaviour {

    public GameObject deadObject;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        this.GetComponent<photoControll>().dead = true;
        deadObject.SetActiveRecursively(false);
        this.GetComponent<deadAgain>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
