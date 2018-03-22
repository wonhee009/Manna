using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

    public GameObject inter;
    public GameObject btnCon;
    public GameObject btnDo;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(inter);
        DontDestroyOnLoad(btnCon);
        DontDestroyOnLoad(btnDo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
