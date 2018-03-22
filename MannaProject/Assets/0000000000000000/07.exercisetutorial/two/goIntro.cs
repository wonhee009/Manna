using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goIntro : MonoBehaviour
{
    private Animator avator;
    public bool con = false;

    public GameObject duli;
    public GameObject intro;
    public Camera mainCamera;

    public GameObject pre;

    public GameObject ges;

    private void Awake()
    {
        pre.SetActiveRecursively(false);
        avator = this.GetComponent<Animator>();
        ges.GetComponent<skipGesture>().mode = 1;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                intro.SetActiveRecursively(true);
                duli.GetComponent<Animator>().enabled = true;
                mainCamera.GetComponent<Animator>().enabled = true;
                

                con = true;
            }
        }
    }
}
