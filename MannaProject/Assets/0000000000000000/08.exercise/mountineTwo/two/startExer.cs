using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startExer : MonoBehaviour {

    private Animator avator;

    public GameObject can1;
    public GameObject can2;

    public GameObject can1_R;
    public GameObject can2_R;

    public GameObject userImage;

    public GameObject exercon;

    private bool con = false;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (con == false)
            {
                switch (GameObject.Find("userInfo").GetComponent<UserInfo>().doExer)
                {
                    case 1:
                        
                        can1.SetActive(true);
                        can1_R.SetActive(true);
                        userImage.SetActive(true);

                        //exercon.GetComponent<testTwotwoRightCount>().start = true;
                        con = true;
                        
                        break;

                    case 2:
                        
                        can2.SetActive(true);
                        can2_R.SetActive(true);
                        userImage.SetActive(true);

                        //exercon.GetComponent<testTwotwoLeftCount>().start = true;
                        con = true;
                        
                        break;
                }
            }
        }
	}
}
