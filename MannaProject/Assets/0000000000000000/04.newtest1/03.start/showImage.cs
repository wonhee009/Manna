using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showImage : MonoBehaviour {

    private Animator avatar;

    public GameObject image;
    public GameObject btnController;
    public GameObject exercise;

    public bool con = false;

	// Use this for initialization
	void Start () {
		
	}
	
	void Awake()
    {
        avatar = this.GetComponent<Animator>();
        con = true;
    }

    private void Update()
    {
        if(avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == true)
            {
                image.SetActive(true);
                btnController.GetComponent<Test1Btn>().mode = 0;
                exercise.GetComponent<testOneCount>().start = true;
                con = false;
            }
        }
    }
}
