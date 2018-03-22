using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUser : MonoBehaviour {

    public GameObject userImage;
    public float time;

    private void Start()
    {
        Invoke("show", time);
    }

    private void OnEnable()
    {
        Invoke("show", time);
    }
    void show()
    {
        userImage.SetActive(true);
        this.GetComponent<startUser>().enabled = false;
    }
}
