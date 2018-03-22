using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goteacher : MonoBehaviour {

    private Animator avatar;
    public bool con = false;
    public GameObject inter;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		if(avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                teacher();
                con = true;
            }
        }
	}

    void teacher()
    {
        SceneManager.LoadScene("0000000000000000/03.teacher/teachScene");
        Destroy(inter);
        con = true;
    }
}
