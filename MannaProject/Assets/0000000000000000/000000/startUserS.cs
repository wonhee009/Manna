using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUserS : MonoBehaviour {

    public GameObject con;
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
        con.GetComponent<testMove>().enabled = true;
        this.GetComponent<startUser>().enabled = false;
    }
}
