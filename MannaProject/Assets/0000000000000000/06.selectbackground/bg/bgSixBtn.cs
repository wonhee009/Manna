using UnityEngine;
using System.Collections;

public class bgSixBtn : MonoBehaviour
{
    public GameObject six_check;

    public GameObject okButton;
    public GameObject notOkButton;

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 0)
        {
            six_check.SetActive(true);
            six_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 6;
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 6)
            {
                six_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                six_check.GetComponent<BoxCollider>().enabled = false;
                six_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgSixBtn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
