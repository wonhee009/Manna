using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadAudio : MonoBehaviour {

    Animator anim;
    private bool con = false;
    public GameObject Audio;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetCurrentAnimatorStateInfo(0) .normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                Audio.SetActive(false);
            }
        }
	}
}
