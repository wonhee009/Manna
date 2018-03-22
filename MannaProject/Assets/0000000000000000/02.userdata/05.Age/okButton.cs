using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okButton: MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject userInfo;
    public GameObject next;
    public GameObject prev;

    public GameObject btnController;

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        userInfo.GetComponent<UserInfo>().age_1 = one.GetComponent<Text>().text;
        userInfo.GetComponent<UserInfo>().age_2 = two.GetComponent<Text>().text;
        next.SetActiveRecursively(true);
        prev.SetActiveRecursively(false);
        btnController.GetComponent<totalConfirmButton>().mode = 3;
        this.GetComponent<okButton>().enabled = false;
    }
}
