using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class finishTime : MonoBehaviour
{
    private Animator avator;
    private bool con = false;

    private void Awake()
    {
        avator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (avator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                SceneManager.LoadScene("0000000000000000/07.exercisetutorial/fiveTutorialScene");
                con = true;
            }
        }
    }
}
