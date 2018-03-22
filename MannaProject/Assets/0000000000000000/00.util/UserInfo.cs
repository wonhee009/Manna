using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour {

    //사용자 사진 
    public string photoPath;
    //사용자 나이
    public string age_1;
    public string age_2;
    //사용자 성별 (ture->M/false->F)
    public bool MF;

    //test1 횟수
    public int test1;

    //test1 레벨
    public int test1level;

    //test2-1 횟수
    public int test2_1_left;
    public int test2_1_right;
    //test2-2 횟수
    public int test2_2_left;
    public int test2_2_right;

    public int test2_1level;
    public int test2_2level;

    //배경 갯수
    public int background;

    //운동 1 횟수
    public int exercise1_left;
    public int exercise1_right;
    //운동 2 횟수
    public int exercise2_left;
    public int exercise2_right;

    public int doExer;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
    }
}
