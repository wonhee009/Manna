using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class confirmButton : MonoBehaviour {

    public GameObject inter;

    private void OnEnable()
    {
        Destroy(inter);
        SceneManager.LoadScene("0000000000000000/05.test2/twoScene");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
