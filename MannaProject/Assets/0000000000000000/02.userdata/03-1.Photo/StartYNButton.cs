using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartYNButton : MonoBehaviour {

    /*
    public GameObject prev;

    public GameObject image;
    public GameObject border;
    public GameObject ynButton;

    AudioSource prevAudio;
    AudioSource audio;

    public bool con = false;

    public static StartYNButton instance;
    */

    public GameObject image;
    public GameObject border;
    public GameObject ynButton;

    private void OnEnable()
    {
        border.SetActiveRecursively(false);
        image.SetActiveRecursively(false);
        ynButton.SetActiveRecursively(true);

        this.GetComponent<StartYNButton>().enabled = false;
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
