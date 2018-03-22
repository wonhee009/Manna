using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testResult : MonoBehaviour
{
    public GameObject userInfo;

    public Text test1;
    public Text test2_1_left_text;
    public Text test2_1_right_text;
    public Text test2_2_left_text;
    public Text test2_2_right_text;

    public GameObject btnControll;

    private int test2_1_left;
    private int test2_1_right;
    private int test2_2_left;
    private int test2_2_right;

    private int test2_1;
    private int test2_2;

    private int[] testArray;
    private int[] infoArray;


    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        btnControll.GetComponent<Test2Btn>().mode = 2;
        userInfo = GameObject.Find("userInfo");

        test2_1_left = userInfo.GetComponent<UserInfo>().test2_1_left;
        test2_1_right = userInfo.GetComponent<UserInfo>().test2_1_right;
        test2_2_left = userInfo.GetComponent<UserInfo>().test2_2_left;
        test2_2_right = userInfo.GetComponent<UserInfo>().test2_2_right;

        test1.text = userInfo.GetComponent<UserInfo>().test1.ToString();
        test2_1_left_text.text = test2_1_left.ToString();
        test2_1_right_text.text = test2_1_right.ToString();
        test2_2_left_text.text = test2_2_left.ToString();
        test2_2_right_text.text = test2_2_right.ToString();

        test2_1 = (test2_1_left + test2_1_right) / 2;
        test2_2 = (test2_2_left + test2_2_right) / 2;

        testArray = new int[2] { test2_1, test2_2};
        infoArray = new int[2] { userInfo.GetComponent<UserInfo>().test2_1level, userInfo.GetComponent<UserInfo>().test2_2level};

        for(int i = 0; i < 2; i++)
        {
            if(testArray[i] <= 7)
            {
                infoArray[i] = 1;
            }
            else if(7 < testArray[i] && testArray[i] <= 9)
            {
                infoArray[i] = 2;
            }
            else if(9 < testArray[i])
            {
                infoArray[i] = 3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
