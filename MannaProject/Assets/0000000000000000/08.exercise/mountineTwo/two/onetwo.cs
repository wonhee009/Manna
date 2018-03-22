using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onetwo : MonoBehaviour {

    private Animator avator;

    public bool con = true;
    public GameObject notYet;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        con = false;
    }

    // Update is called once per frame
    void Update () {
        if (avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                notYet.SetActiveRecursively(false);
                this.GetComponent<onetwo>().enabled = false;
                con = true;
            }
        }
	}
}
