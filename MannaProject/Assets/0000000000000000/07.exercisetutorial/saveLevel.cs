using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLevel : MonoBehaviour {

    private GameObject user;

    private int test2_1_left;
    private int test2_1_right;
    private int test2_2_left;
    private int test2_2_right;

    private int test2_1;
    private int test2_2;

    private void Awake()
    {
        user = GameObject.Find("userInfo");

        test2_1_left = user.GetComponent<UserInfo>().test2_1_left;
        test2_1_right = user.GetComponent<UserInfo>().test2_1_right;
        test2_2_left = user.GetComponent<UserInfo>().test2_2_left;
        test2_2_right = user.GetComponent<UserInfo>().test2_2_right;
    }

    // Use this for initialization
    void Start () {
        test2_1 = (test2_1_left + test2_1_right) / 2;
        test2_2 = (test2_2_left + test2_2_right) / 2;

        if(test2_1 <= 7)
        {
            user.GetComponent<UserInfo>().test2_1level = 1;
        }
        else if(test2_1 >7 && test2_1 <= 9)
        {
            user.GetComponent<UserInfo>().test2_1level = 2;
        }
        else if(test2_1 > 9)
        {
            user.GetComponent<UserInfo>().test2_1level = 3;
        }

        if (test2_2 <= 7)
        {
            user.GetComponent<UserInfo>().test2_2level = 1;
        }
        else if (test2_2 > 7 && test2_2 <= 9)
        {
            user.GetComponent<UserInfo>().test2_2level = 2;
        }
        else if (test2_2 > 9)
        {
            user.GetComponent<UserInfo>().test2_2level = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
