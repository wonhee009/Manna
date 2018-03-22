using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCircle : MonoBehaviour {

    AudioSource audio;

    public GameObject circle;

    public bool con = false;

    public static ShowCircle instance;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (audio.isPlaying)
        {
            if(con == false)
            {
                trueNext();
            }
        }
	}

    void trueNext()
    {
        circle.SetActiveRecursively(true);
        con = true;
        this.GetComponent<ShowCircle>().enabled = false;
    }
}
