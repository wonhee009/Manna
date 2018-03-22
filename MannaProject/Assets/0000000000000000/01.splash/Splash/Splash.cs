using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    private Animator avatar;
    public bool con = false;

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if(avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                userdata();
                con = true;
            }
        }
    }

    void userdata()
    {
        SceneManager.LoadScene("0000000000000000/02.userdata/finalUserData");
        con = true;
        this.GetComponent<Splash>().enabled = false;
    }
}
