using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLeft : MonoBehaviour {

    private Animator avator;

    private bool con = false;

    public GameObject onetwo;

    public GameObject exer;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
        exer.GetComponent<exertwoLeftCount>().start = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                onetwo.SetActive(true);
                onetwo.GetComponent<startOneTwoLeft>().enabled = true;
                con = true;
            }
        }
	}
}
