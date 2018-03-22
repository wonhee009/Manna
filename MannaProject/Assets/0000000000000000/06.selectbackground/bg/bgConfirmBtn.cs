using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgConfirmBtn : MonoBehaviour {

    public GameObject inter;
    public int exer;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        Destroy(inter);
        GameObject.Find("userInfo").GetComponent<UserInfo>().doExer = 1;
        SceneManager.LoadScene("0000000000000000/07.exerciseTutorial/twoTutorialScene");
        this.GetComponent<bgConfirmBtn>().enabled = false;
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
