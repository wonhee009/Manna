using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1Anim : MonoBehaviour {

    private Animator avatar;

    public GameObject btnDo;
    public GameObject btnControll;
    public GameObject Cursor;
    public GameObject skip;

    public bool con = false;

	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
        btnControll.GetComponent<Test1Btn>().mode = 1;
    }

    // Update is called once per frame
    void Update () {
        if (avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (con == false)
            {
                Cursor.SetActiveRecursively(false);
                btnDo.GetComponent<skipButton>().enabled = true;
                skip.SetActiveRecursively(false);
                con = true;
            }
        }
    }
}
