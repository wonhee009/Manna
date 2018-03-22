using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectRandombg : MonoBehaviour {

    public GameObject inter;

    private int ran;
    private bool ranCon = true;

    private GameObject[] backArray;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;
    public GameObject bg5;
    public GameObject bg6;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        backArray = new GameObject[6] {bg1, bg2, bg3, bg4, bg5, bg6};
    }

    private void OnEnable()
    {
        while (ranCon)
        {
            ran = Random.Range(0, 6);
            if(backArray[ran].GetComponent<BoxCollider>().enabled == true)
            {
                ranCon = false;
            }
        }

        GameObject.Find("userInfo").GetComponent<UserInfo>().background = ran + 1;
        Destroy(inter);
        GameObject.Find("userInfo").GetComponent<UserInfo>().doExer = 1;
        SceneManager.LoadScene("0000000000000000/07.exerciseTutorial/twoTutorialScene");
        this.GetComponent<selectRandombg>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
