using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowTest1 : MonoBehaviour {

    AudioSource audio;

    public bool con = false;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (!audio.isPlaying)
        {
            if(con == false)
            {
                goTest1();
            }
        }
    }

    void goTest1()
    {
        SceneManager.LoadScene("0000000000000000/04.newtest1/newtest1");
        con = true;
    }
}
