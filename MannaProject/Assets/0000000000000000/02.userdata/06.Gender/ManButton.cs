using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManButton : MonoBehaviour {

    public GameObject userInfo;
    public GameObject next;
    public GameObject prev;

    public GameObject btnController;

    // Use this for initialization
    void Start () {

    }

    private void OnEnable()
    {
        userInfo.GetComponent<UserInfo>().MF = true;
        next.SetActiveRecursively(true);
        prev.SetActiveRecursively(false);

        btnController.GetComponent<totalConfirmButton>().mode = 0;

        this.GetComponent<ManButton>().enabled = false;
    }
}
