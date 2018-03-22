using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgOneBtn : MonoBehaviour {

    public GameObject one_check;

    public GameObject okButton;
    public GameObject notOkButton;

    // Use this for initialization
    void Start () {
		
	}


    private void OnEnable()
    {
        if(GameObject.Find("userInfo").GetComponent<UserInfo>().background == 0)
        {
            one_check.SetActive(true);
            one_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 1;
        }
        else if(GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if(GameObject.Find("userInfo").GetComponent<UserInfo>().background == 1)
            {
                one_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                one_check.GetComponent<BoxCollider>().enabled = false;
                one_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgOneBtn>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
