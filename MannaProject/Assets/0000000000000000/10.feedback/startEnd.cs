using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startEnd : MonoBehaviour {

    private Animator anim;
    private bool con = false;
    public GameObject end;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                end.SetActive(true);
                con = true;
            }
        }
	}
}
