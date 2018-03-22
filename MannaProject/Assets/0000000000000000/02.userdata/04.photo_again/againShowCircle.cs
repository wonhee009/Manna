using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class againShowCircle : MonoBehaviour {

    public GameObject circle;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        circle.SetActive(true);
        circle.GetComponent<startUser>().enabled = true;
        this.GetComponent<againShowCircle>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
