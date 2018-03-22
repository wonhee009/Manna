using UnityEngine;
using System.Collections;

public class feedQuit : MonoBehaviour
{
    private Animator anim;

    private bool con = false;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                Application.Quit();
                con = true;
            }
        }
    }
}
