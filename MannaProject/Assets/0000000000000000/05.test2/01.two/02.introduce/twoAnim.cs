using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoAnim : MonoBehaviour {

    private Animator avatar;
    public bool con = false;
    public GameObject doBtn;

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                doBtn.GetComponent<skipTu>().enabled = true;
                con = true;
            }
        }
	}
}
