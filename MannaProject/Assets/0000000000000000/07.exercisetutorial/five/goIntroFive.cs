using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goIntroFive : MonoBehaviour {

    private Animator avator;
    public bool con = false;

    public GameObject duli;
    public GameObject intro;
    public Camera mainCamera;

    public GameObject ges;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
        ges.GetComponent<skipGesture>().mode = 1;
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
                intro.SetActiveRecursively(true);
                duli.GetComponent<Animator>().enabled = true;
                //mainCamera.GetComponent<Animator>().enabled = true;


                con = true;
            }
        }
    }
}
