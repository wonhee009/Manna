using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnAudioControll : MonoBehaviour {

    AudioSource audio;

    public bool sound = false;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
	}

    private void OnEnable()
    {
        sound = false;
    }

    // Update is called once per frame
    void Update () {
        if (!audio.isPlaying)
        {
            if(sound == false)
            {
                audio.enabled = false;
                sound = true;
                this.GetComponent<btnAudioControll>().enabled = false;
            }
        }
	}
}
