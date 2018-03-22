using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goTu : MonoBehaviour {

    private Animator avatar;
    public bool con = false;

    public GameObject can;
    public GameObject duli;

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
                can.SetActive(true);
                duli.SetActiveRecursively(true);
                con = true;
            }
        }
	}
}
