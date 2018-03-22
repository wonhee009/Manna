using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleController : MonoBehaviour {

    private GameObject userInfo;

    public GameObject handleO;
    public GameObject handleX;

    private int level;

	// Use this for initialization
	void Start () {

	}

    private void Awake()
    {
        if (GameObject.Find("userInfo").GetComponent<UserInfo>().test1level == 1)
        {
            handleO.SetActiveRecursively(true);
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().test1level == 2)
        {
            handleX.SetActiveRecursively(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
