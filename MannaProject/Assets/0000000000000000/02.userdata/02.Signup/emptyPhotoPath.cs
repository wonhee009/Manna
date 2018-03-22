using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyPhotoPath : MonoBehaviour {

    AudioSource audio;

    public GameObject userObject;

    public static emptyPhotoPath instance;

    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audio.isPlaying)
        {
            if(userObject.GetComponent<UserInfo>().photoPath == "nothing")
            {
                userObject.GetComponent<UserInfo>().photoPath = "";
            }
            else
            {
                this.GetComponent<emptyPhotoPath>().enabled = false;
            }
        }
    }
}
