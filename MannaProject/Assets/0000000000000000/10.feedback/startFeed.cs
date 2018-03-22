using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startFeed : MonoBehaviour {

    private GameObject user;

    public GameObject sc0;
    public GameObject sc1;
    public GameObject sc2;

    private int count = 0;

    private int ex1;
    private int ex2;
    private int te1;
    private int te2;

    private void Awake()
    {
        user = GameObject.Find("userInfo");

        te1 = (user.GetComponent<UserInfo>().test2_1_left + user.GetComponent<UserInfo>().test2_1_right) / 2;
        te2 = (user.GetComponent<UserInfo>().test2_2_left + user.GetComponent<UserInfo>().test2_2_right) / 2;
        ex1 = (user.GetComponent<UserInfo>().exercise1_left + user.GetComponent<UserInfo>().exercise1_right) / 2;
        ex2 = (user.GetComponent<UserInfo>().exercise2_left + user.GetComponent<UserInfo>().exercise2_right) / 2;
    }

    // Use this for initialization
    void Start () {
		if(ex1 > te1)
        {
            count++;
        }
        if(ex2 > te2)
        {
            count++;
        }

        switch (count)
        {
            case 0:
                sc0.SetActive(true);
                break;

            case 1:
                sc1.SetActive(true);
                break;

            case 2:
                sc2.SetActive(true);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
