using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getInfo : MonoBehaviour {

    public GameObject Cursor;

    public GameObject age;
    public GameObject sex;

    public GameObject image;

    private string mf;

    public GameObject userInfo;

	// Use this for initialization
	void Start () {

        if(userInfo.GetComponent<UserInfo>().MF == true)
        {
            mf = "남 자";
        }
        else
        {
            mf = "여 자";
        }
        Cursor.SetActiveRecursively(false);
        age.GetComponent<Text>().text = userInfo.GetComponent<UserInfo>().age_1 + " " + userInfo.GetComponent<UserInfo>().age_2;
        sex.GetComponent<Text>().text = mf;
        image.SetActiveRecursively(true);
	}

}
