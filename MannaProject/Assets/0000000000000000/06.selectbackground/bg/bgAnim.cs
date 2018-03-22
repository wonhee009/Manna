using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAnim : MonoBehaviour {

    private Animator avatar;

    public GameObject Cursor;
    public GameObject next;

    public bool con = false;

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
            if (con == false)
            {
                Cursor.SetActiveRecursively(true);
                next.SetActive(true);
                con = true;
            }
        }
    }
}
