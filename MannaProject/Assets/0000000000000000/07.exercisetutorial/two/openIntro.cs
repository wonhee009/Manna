using UnityEngine;
using System.Collections;

public class openIntro : MonoBehaviour
{
    public GameObject btnCon;
    public GameObject ges;

    private Animator anim;

    public bool con = false;
    public GameObject doBtn;

    private void Awake()
    {
        btnCon.GetComponent<TuBtnControl>().mode = 1;
        ges.GetComponent<skipGesture>().mode = 0;
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
                doBtn.GetComponent<skipTwoTu>().enabled = true;
                con = true;
            }
        }
    }
}
