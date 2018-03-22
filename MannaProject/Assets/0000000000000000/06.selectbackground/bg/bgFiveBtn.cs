using UnityEngine;
using System.Collections;

public class bgFiveBtn : MonoBehaviour
{
    public GameObject five_check;

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
            five_check.SetActive(true);
            five_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 5;
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 5)
            {
                five_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                five_check.GetComponent<BoxCollider>().enabled = false;
                five_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgFiveBtn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
