using UnityEngine;
using System.Collections;

public class bgThreeBtn : MonoBehaviour
{

    public GameObject three_check;

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
            three_check.SetActive(true);
            three_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 3;
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 3)
            {
                three_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                three_check.GetComponent<BoxCollider>().enabled = false;
                three_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgThreeBtn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
