using UnityEngine;
using System.Collections;

public class bgFourBtn : MonoBehaviour
{
    public GameObject four_check;

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
            four_check.SetActive(true);
            four_check.GetComponent<BoxCollider>().enabled = true;
            notOkButton.SetActive(false);
            okButton.GetComponent<BoxCollider>().enabled = true;
            okButton.SetActive(true);
            GameObject.Find("userInfo").GetComponent<UserInfo>().background = 4;
        }
        else if (GameObject.Find("userInfo").GetComponent<UserInfo>().background != 0)
        {
            if (GameObject.Find("userInfo").GetComponent<UserInfo>().background == 4)
            {
                four_check.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
                four_check.GetComponent<BoxCollider>().enabled = false;
                four_check.SetActive(false);
                GameObject.Find("userInfo").GetComponent<UserInfo>().background = 0;
                notOkButton.SetActive(true);
                okButton.GetComponent<BoxCollider>().enabled = false;
                okButton.SetActive(false);
            }
        }
        this.GetComponent<bgFourBtn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
