using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fiveImage : MonoBehaviour {
    private Animator avatar;

    public GameObject image;
    public GameObject btnController;
    public GameObject exercise;

    public bool con = false;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
        con = true;
    }

    // Update is called once per frame
    void Update () {
        if (avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (con == true)
            {
                image.SetActive(true);
                btnController.GetComponent<Test2Btn>().mode = 0;
                exercise.GetComponent<testTwofiveRightCount>().start = true;
                con = false;
            }
        }
    }
}
