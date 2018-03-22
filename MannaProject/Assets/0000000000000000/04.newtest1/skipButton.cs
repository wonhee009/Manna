using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipButton : MonoBehaviour {

    public GameObject anim;
    public GameObject can;
    public GameObject Cursor;
    public GameObject next;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Destroy(anim);
        Destroy(can);
        Cursor.SetActiveRecursively(false);
        Invoke("goNext", 1);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void goNext()
    {
        next.SetActiveRecursively(true);
        this.GetComponent<skipButton>().enabled = false;
    }
}
