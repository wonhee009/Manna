using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTest2 : MonoBehaviour {

    private Animator avatar;
    public bool con = false;

    public GameObject inter;

    private void Awake()
    {
        avatar = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (avatar.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if(con == false)
            {
                Destroy(inter);
                SceneManager.LoadScene("0000000000000000/05.test2/twoScene");
                con = true;
            }
        }

    }
}
