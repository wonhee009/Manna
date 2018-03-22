using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popDeadAudio : MonoBehaviour {

    public GameObject audio1;
    public GameObject audio2;

    private void OnEnable()
    {
        audio1.SetActive(false);
        audio2.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
