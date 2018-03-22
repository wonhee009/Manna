using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class resultCon : MonoBehaviour
{
    public GameObject btnCon;
    //public GameObject prev;

    public Text test2_1_left;
    public Text test2_1_right;
    public Text test2_2_left;
    public Text test2_2_right;

    public Text exer1_left;
    public Text exer1_right;
    public Text exer2_left;
    public Text exer2_right;

    private void Awake()
    { 
        test2_1_left.text = GameObject.Find("userInfo").GetComponent<UserInfo>().test2_1_left.ToString();
        test2_1_right.text = GameObject.Find("userInfo").GetComponent<UserInfo>().test2_1_right.ToString();
        test2_2_left.text = GameObject.Find("userInfo").GetComponent<UserInfo>().test2_2_left.ToString();
        test2_2_right.text = GameObject.Find("userInfo").GetComponent<UserInfo>().test2_2_right.ToString();

        exer1_left.text = GameObject.Find("userInfo").GetComponent<UserInfo>().exercise1_left.ToString();
        exer1_right.text = GameObject.Find("userInfo").GetComponent<UserInfo>().exercise1_right.ToString();
        exer2_left.text = GameObject.Find("userInfo").GetComponent<UserInfo>().exercise2_left.ToString();
        exer2_right.text = GameObject.Find("userInfo").GetComponent<UserInfo>().exercise2_right.ToString();

        btnCon.GetComponent<resultBtnCon>().mode = 1;
        //prev.SetActiveRecursively(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
