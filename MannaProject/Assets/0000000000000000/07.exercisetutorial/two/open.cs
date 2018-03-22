using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour {

    public GameObject userInfo;
    private int ran;

    public GameObject one1M;
    public GameObject one1F;
    public GameObject one2M;
    public GameObject one2F;
    public GameObject one3M;
    public GameObject one3F;
    public GameObject two1M;
    public GameObject two1F;
    public GameObject two2M;
    public GameObject two2F;
    public GameObject two3M;
    public GameObject two3F;

    public GameObject can1;
    public GameObject can2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        userInfo = GameObject.Find("userInfo");
        ran = Random.Range(1, 4);

        if(userInfo.GetComponent<UserInfo>().test1level == 1)
        {
            can1.SetActive(true);
            if (ran == 1)
            {
                if(userInfo.GetComponent<UserInfo>().MF == true)
                {
                    one1M.SetActiveRecursively(true);
                }
                else
                {
                    one1F.SetActiveRecursively(true);
                }
            }
            else if (ran == 2)
            {
                if (userInfo.GetComponent<UserInfo>().MF == true)
                {
                    one2M.SetActiveRecursively(true);
                }
                else
                {
                    one2F.SetActiveRecursively(true);
                }
            }
            else if (ran == 3)
            {
                if (userInfo.GetComponent<UserInfo>().MF == true)
                {
                    one3M.SetActiveRecursively(true);
                }
                else
                {
                    one3F.SetActiveRecursively(true);
                }
            }
        }
        else if(userInfo.GetComponent<UserInfo>().test1level == 2)
        {
            can2.SetActive(true);
            if (ran == 1)
            {
                if (userInfo.GetComponent<UserInfo>().MF == true)
                {
                    two1M.SetActiveRecursively(true);
                }
                else
                {
                    two1F.SetActiveRecursively(true);
                }
            }
            else if (ran == 2)
            {
                if (userInfo.GetComponent<UserInfo>().MF == true)
                {
                    two2M.SetActiveRecursively(true);
                }
                else
                {
                    two2F.SetActiveRecursively(true);
                }
            }
            else if (ran == 3)
            {
                if (userInfo.GetComponent<UserInfo>().MF == true)
                {
                    two3M.SetActiveRecursively(true);
                }
                else
                {
                    two3F.SetActiveRecursively(true);
                }
            }
        }
    }
}
