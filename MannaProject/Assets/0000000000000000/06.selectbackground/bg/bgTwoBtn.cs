using UnityEngine;
using System.Collections;

public class bgTwoBtn : MonoBehaviour
{

    public GameObject two_check;

    public GameObject okButton;
    public GameObject notOkButton;


    private void OnEnable()
    {
        if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 0)
        {
            two_check.SetActive(true);
            two_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 2;
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 2)
            {
                two_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                two_check.GetComponent<BoxCollider>().enabled = false;
                two_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgTwoBtn>().enabled = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
