using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPhotoAnim : MonoBehaviour {

    private Animator avatar;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Debug.Log("fiinish1");
        }
    }
}
