using UnityEngine;
using System.Collections;

public class completeAnim : MonoBehaviour
{
    private Animator avator;

    public bool con = true;

    public GameObject complete;

    public GameObject onetwo;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        con = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                complete.SetActiveRecursively(false);
                onetwo.SetActiveRecursively(false);
                con = true;
            }
        }
    }
}
