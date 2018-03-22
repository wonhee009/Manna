using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartYNBtnControll : MonoBehaviour {

    public bool con = false;

    public GameObject one;
    public GameObject two;

    AudioSource oneAudio;
    AudioSource twoAudio;

	// Use this for initialization
	void Start () {
        oneAudio = one.GetComponent<AudioSource>();
        twoAudio = two.GetComponent<AudioSource>();
	}

    private void OnEnable()
    {
        con = false;
    }

    // Update is called once per frame
    void Update () {
		if(!oneAudio.isPlaying && !twoAudio.isPlaying)
        {
            if(con == false)
            {
                this.GetComponent<StartYNButton>().enabled = true;
                con = true;
            }
        }
	}
}
