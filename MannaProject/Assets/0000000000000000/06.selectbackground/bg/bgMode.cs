using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMode : MonoBehaviour {

    public GameObject btnCon;
    public GameObject prev;

    /*
    public GameObject userInfo;
    */

    /*
    private int test1_level;
    private int test2_1_level;
    private int test2_2_level;
    private int test2_3_level;
    */

   // private int ran1;
    //private int ran2;

    //private bool ranCon = true;

    //private int total = 0;

    //private int[] levelArray;

    /*
    public GameObject bg1;
    public GameObject bg1_lock;
    public GameObject bg2;
    public GameObject bg2_lock;
    public GameObject bg3;
    public GameObject bg3_lock;
    public GameObject bg4;
    public GameObject bg4_lock;
    public GameObject bg5;
    public GameObject bg5_lock;
    public GameObject bg6;
    public GameObject bg6_lock;
    */

    //private GameObject[] backArray;
    //private GameObject[] backLockArray;

    private void Awake()
    {
        btnCon.GetComponent<btTotalBtn>().mode = 1;
        prev.SetActive(false);
        /*
        userInfo = GameObject.Find("userInfo");

        test1_level = userInfo.GetComponent<UserInfo>().test1level;
        test2_1_level = userInfo.GetComponent<UserInfo>().test2_1level;
        test2_2_level = userInfo.GetComponent<UserInfo>().test2_2level;

        levelArray = new int[2] {test2_1_level, test2_2_level};
        */

        //backArray = new GameObject[6] { bg1, bg2, bg3, bg4, bg5, bg6 };
        //backLockArray = new GameObject[6] { bg1_lock, bg2_lock, bg3_lock, bg4_lock, bg5_lock, bg6_lock };

        /*
        for(int i = 0; i < 2; i++)
        {
            if(levelArray[i] == 1)
            {
                total += 1;
            }
            else if(levelArray[i] == 2)
            {
                total += 2;
            }
            else if(levelArray[i] == 3)
            {
                total += 3;
            }
        }
        //1~3
        if(test1_level == 1)
        {
            ran1 = Random.Range(0, 3);
            
            //1
            if (total <= 2)
            {
                for(int i = 0; i < 6; i++)
                {
                    if(i == ran1)
                    //if(i == 0)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else
                    {
                        backLockArray[i].SetActiveRecursively(true);
                    }
                }
            }
            //2
            else if(2 < total && total <= 4)
            {
                while (ranCon)
                {
                    ran2 = Random.Range(0, 3);
                    if(ran2 != ran1)
                    {
                        ranCon = false;
                    }
                }

                for(int i = 0; i < 6; i++)
                {
                    if (i == ran1 || i == ran2)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else
                    {
                        backLockArray[i].SetActiveRecursively(true);
                    }
                }
            }
            //3
            else if(4 < total && total <= 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 1 || i == 2 || i == 3)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else
                    {
                        backLockArray[i].SetActiveRecursively(true);
                    }
                }
            }
        }
        //4~6
        else if(test1_level == 2)
        {
            ran1 = Random.Range(0, 3);
            ran1 += 3;

            //4
            if (total <= 2)
            {
                for (int i = 0; i < 6; i++)
                {
                    if(i < 3)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else if (i == ran1)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else
                    {
                        backLockArray[i].SetActiveRecursively(true);
                    }
                }
            }
            //5
            else if (2 < total && total <= 4)
            {
                while (ranCon)
                {
                    ran2 = Random.Range(0, 3);
                    ran2 += 3;
                    if (ran2 != ran1)
                    {
                        ranCon = false;
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if(i < 3)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else if (i == ran1 || i == ran2)
                    {
                        backArray[i].GetComponent<BoxCollider>().enabled = true;
                    }
                    else
                    {
                        backLockArray[i].SetActiveRecursively(true);
                    }
                }
            }
            //6
            else if (4 < total && total <= 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    backArray[i].GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
        */
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
