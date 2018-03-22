using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPrev : MonoBehaviour {

    public GameObject photo;
    public GameObject photo_again;

	// Use this for initialization
	void Start () {
        
    }
    private void Awake()
    {
        Destroy(photo);
        Destroy(photo_again);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
