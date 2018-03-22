using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScene : MonoBehaviour {

    public GameObject cursor;
    public GameObject sound;
    public GameObject dead;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        dead.SetActiveRecursively(false);
        cursor.SetActiveRecursively(false);
        sound.GetComponent<AudioSource>().enabled = false;
        this.GetComponent<DeadScene>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
