using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class againEmptyPath : MonoBehaviour {

    public GameObject userInfo;

	// Use this for initialization
	void Start () {

	}

    private void OnEnable()
    {
        userInfo.GetComponent<UserInfo>().photoPath = "";
        this.GetComponent<againEmptyPath>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
	}
}
