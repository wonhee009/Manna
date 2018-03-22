using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTu : MonoBehaviour {

    private Animator avatar;

    public GameObject tuto;
    public GameObject duli;
    public GameObject red;

    public GameObject open;

    public bool con = false;

    public Camera main;

	// Use this for initialization
	void Start () {
		
	}
    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        if (avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                open.SetActiveRecursively(false);
                tuto.SetActiveRecursively(true);
                duli.SetActiveRecursively(true);
                main.GetComponent<Animator>().enabled = true;
                Invoke("showRed", 1);
                con = true;
            }
        }
	}

    void showRed()
    {
        red.SetActiveRecursively(true);
    }
}
