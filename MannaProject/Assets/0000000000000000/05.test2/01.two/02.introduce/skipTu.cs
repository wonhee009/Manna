using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipTu : MonoBehaviour {

    public GameObject anim;
    public Camera main;
    public GameObject can;
    public GameObject Cursor;
    public GameObject next;
    public GameObject red;

    public Camera camera1;
    public Camera camera2;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        main.GetComponent<Animator>().enabled = false;
        camera1.enabled = false;
        camera2.enabled = false;
        Destroy(anim);
        Destroy(red);
        can.SetActiveRecursively(false);
        Cursor.SetActiveRecursively(false);
        
        Invoke("goNext", 1);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void goNext()
    {
        next.SetActiveRecursively(true);
        this.GetComponent<skipTu>().enabled = false;
    }
}
