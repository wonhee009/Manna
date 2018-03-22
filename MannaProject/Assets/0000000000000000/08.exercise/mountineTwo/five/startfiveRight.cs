using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startfiveRight : MonoBehaviour {

    private Animator avator;

    private bool con = false;

    public GameObject onetwo;

    public GameObject exer;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
        exer.GetComponent<exerfiveRightCount>().start = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (con == false)
            {
                onetwo.SetActive(true);
                onetwo.GetComponent<startOneTwoRight>().enabled = true;
                con = true;
            }
        }
    }
}
