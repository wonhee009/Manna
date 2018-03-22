using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranTime : MonoBehaviour {

    public GameObject time1;
    public GameObject time2;
    public GameObject time3;
    public GameObject time4;

    public int ran;

    public GameObject[] timeArray;

    private void Awake()
    {
        timeArray = new GameObject[4] { time1, time2, time3, time4};
    }
    // Use this for initialization
    void Start () {
        ran = Random.Range(0, 4);
        timeArray[ran].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
