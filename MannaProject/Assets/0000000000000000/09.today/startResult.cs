using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startResult : MonoBehaviour {

    private Animator anim;

    private bool con;

    public GameObject result;
    public GameObject resultCon;
    public GameObject Cursor;
    public GameObject okBtn;

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
                result.SetActiveRecursively(true);
                resultCon.SetActiveRecursively(true);
                Cursor.SetActive(true);
                okBtn.SetActive(true);
            }
        }
	}
}
