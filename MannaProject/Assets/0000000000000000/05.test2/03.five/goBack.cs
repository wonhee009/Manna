using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour {

    public GameObject inter;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        Destroy(inter);
        SceneManager.LoadScene("0000000000000000/06.selectbackground/selectBackgroundScene");
        this.GetComponent<goBack>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
