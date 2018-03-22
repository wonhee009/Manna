using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSignUp : MonoBehaviour {

    AudioSource twoAudio;

    public GameObject two;

    public GameObject next;

    public bool con = false;

    public static StartSignUp instance;

    public int time;

	// Use this for initialization
	void Start ()
    {
        twoAudio = two.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!twoAudio.isPlaying)
        {
            if (con == false)
            {
                trueNext();
            }
            else { }
        }
	}

    void trueNext()
    {
        next.SetActiveRecursively(true);
        con = true;
    }
}
