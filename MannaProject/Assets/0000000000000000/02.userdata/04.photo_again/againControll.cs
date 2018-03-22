using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class againControll : MonoBehaviour {

    public bool con = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(con == false)
        {
            this.GetComponent<againEmptyPath>().enabled = true;
            this.GetComponent<againShowCircle>().enabled = true;
            this.GetComponent<DeadScene>().enabled = true;
            con = true;
        }
    }
}
