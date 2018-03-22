using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goFeed : MonoBehaviour {
    private bool con = false;
    public GameObject inter;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        if(con == false)
        {
            Destroy(inter);
            SceneManager.LoadScene("0000000000000000/10.feedback/feedback");
            con = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
