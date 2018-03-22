using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testOneCount : MonoBehaviour {

    public bool start = false;

    private float exerciseDone = 10.0f;

    public GameObject userInfo;

    public GameObject image;

    public GameObject player;
    private int playerIndex = 0;
    public int count = 0;
    public Text countInfo;

    /* 척추 높이 */
    //SpineBase 좌표
    private Vector2 spineJointPosition;
    //SpineBase
    private KinectInterop.JointType spineJoint = KinectInterop.JointType.SpineBase;
    //min SpineBase.y
    private double minSpineValueDouble;
    //max SpineBase.y
    private double maxSpineValueDouble;

    /* 앉은 상태 */
    public bool seat = false;
    public bool kneeLeftDegree = false;

    /* 왼쪽 무릎 각도 */
    //KneeLeft
    private KinectInterop.JointType kneeLeftJoint = KinectInterop.JointType.KneeLeft;
    //HipLeft
    private KinectInterop.JointType hipLeftJoint = KinectInterop.JointType.HipLeft;
    //AnkleLeft
    private KinectInterop.JointType ankleLeftJoint = KinectInterop.JointType.AnkleLeft;
    //KLA
    private float KLA;
    //KLPL
    private Vector3 KLPL;
    //ALKL
    private Vector3 ALKL;

    /* 왼쪽 좌표 */
    //KneeLeft 좌표
    private Vector3 kneeLeftJointPosition;
    //HipLeft 좌표
    private Vector3 hipLeftJointPosition;
    //AnkleLeft 좌표
    private Vector3 ankleLeftJointPosition;

    /* 오른쪽 좌표 */
    //KneeRight 좌표
    private Vector3 kneeRightJointPosition;
    //HipRight 좌표
    private Vector3 hipRightJointPosition;
    //AnkleRight 좌표
    private Vector3 ankleRightJointPosition;

    /* 칼만 필터 */
    private double Q = 0.000001;
    private double R = 0.01;
    private double P = 1, X = 0, K;
    //SpineBase 칼만
    private double kalmanSpine;

    private int age;
    private int age1;
    private int age2;
    private bool sex;
    public GameObject next;
    public GameObject gauge;

    // Use this for initialization
    void Start () {
       
        
    }

    private void Awake()
    {
        userInfo = GameObject.Find("userInfo");
        age1 = System.Convert.ToInt32(userInfo.GetComponent<UserInfo>().age_1) * 10;
        age2 = System.Convert.ToInt32(userInfo.GetComponent<UserInfo>().age_2);
        sex = userInfo.GetComponent<UserInfo>().MF;

        maxSpineValueDouble = 0;
        minSpineValueDouble = maxSpineValueDouble;

        age = age1 + age2;
    }

    private static float GetDegree(Vector3 test1, Vector3 test2)
    {

        float v;

        v = Mathf.Sqrt(test1.x * test1.x + test1.y * test1.y + test1.z * test1.z);
        test1.x /= v;
        test1.y /= v;
        test1.z /= v;

        v = Mathf.Sqrt(test2.x * test2.x + test2.y * test2.y + test2.z * test2.z);
        test2.x /= v;
        test2.y /= v;
        test2.z /= v;

        float theta = test1.x * test2.x + test1.y * test2.y + test1.z * test2.z;
        theta = Mathf.Acos(theta);

        float degree = theta * (180 / Mathf.PI);

        return degree;
    }

    void measurementUpdate()
    {
        K = (P + Q) / (P + Q + R);
        P = R * (P + Q) / (R + P + Q);
    }

    private double KalmanUpdate(double measurement)
    {
        measurementUpdate();
        double result = X + (measurement - X) * K;
        X = result;
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            exerciseDone -= Time.deltaTime;
            Debug.Log(exerciseDone);

            KinectManager manager = KinectManager.Instance;

            if (manager && manager.IsInitialized())
            {
                if (manager.IsUserDetected(playerIndex))
                {
                    long userId = manager.GetUserIdByIndex(playerIndex);
                    if (manager.IsJointTracked(userId, (int)kneeLeftJoint))
                    {
                        //KneeLeft Joint Position
                        Vector3 kneeLeftJointPos = manager.GetJointPosition(userId, (int)kneeLeftJoint);
                        //HipLeft Joint Position
                        Vector3 hipLeftJointPos = manager.GetJointPosition(userId, (int)hipLeftJoint);
                        //AnkleLeft Joint Position
                        Vector3 ankleLeftJointPos = manager.GetJointPosition(userId, (int)ankleLeftJoint);

                        //Spine Joint Position
                        Vector2 spineJointPos = manager.GetJointPosition(userId, (int)spineJoint);
                        spineJointPosition = spineJointPos;

                        kneeLeftJointPosition = kneeLeftJointPos;
                        hipLeftJointPosition = hipLeftJointPos;
                        ankleLeftJointPosition = ankleLeftJointPos;

                        KLPL = kneeLeftJointPosition - hipLeftJointPosition;
                        ALKL = ankleLeftJointPosition - kneeLeftJointPosition;

                        KLA = GetDegree(KLPL, ALKL);

                        kalmanSpine = (double)Mathf.Round((float)KalmanUpdate(spineJointPosition.y * 100));
                        if (exerciseDone > 30.3f) { }
                        else if (exerciseDone > 0.0f)
                        {
                            if (KLA > 60)
                            {
                                kneeLeftDegree = true;
                            }

                            //서 있는 상태 
                            if (seat == false)
                            {
                                //최대값 최초 설정
                                if (maxSpineValueDouble == 0)
                                {
                                    maxSpineValueDouble = kalmanSpine;
                                    minSpineValueDouble = maxSpineValueDouble;
                                }
                                //최대값 설정 이후
                                else
                                {
                                    //최대값 보정
                                    if (kalmanSpine > maxSpineValueDouble)
                                    {
                                        maxSpineValueDouble = kalmanSpine;
                                        minSpineValueDouble = maxSpineValueDouble;
                                    }
                                    //최소값 보정
                                    if (kalmanSpine < minSpineValueDouble)
                                    {
                                        minSpineValueDouble = kalmanSpine;
                                    }
                                    //최소값 범위 벗어나면 앉은 상태
                                    else if (kalmanSpine >= minSpineValueDouble + 1)
                                    {
                                        seat = true;
                                    }
                                }
                            }
                            //앉은 상태
                            else
                            {
                                //최대 값 범위에 들어오면 앉았다 선 상태
                                if (kalmanSpine >= maxSpineValueDouble - 10 & kneeLeftDegree)
                                {
                                    this.GetComponent<Progress>().startProgress();
                                    count++;

                                    string countMessage = string.Format("{0:F0}", count);
                                    countInfo.text = countMessage;

                                    seat = false;
                                    kneeLeftDegree = false;

                                    maxSpineValueDouble = 0;
                                    minSpineValueDouble = maxSpineValueDouble;
                                }
                            }
                        }
                        else if (exerciseDone <= 0.0f)
                        {
                            Debug.Log("exerciseDone");
                            count *= 3;
                            userInfo.GetComponent<UserInfo>().test1 = count;
                            image.SetActiveRecursively(false);
                            judge(count);
                        }
                    }

                }
            }
        }
    }
    void judge(int exerciseCount)
    {
        if (sex == true)
        {
            if (age < 60)
            {
                if (exerciseCount <= 19)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //60-64세
            else if (age >= 60 && age <= 64)
            {
                //운동 횟수 19회 이하
                if (exerciseCount <= 19)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 19회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //65-69세
            else if (age >= 65 && age <= 69)
            {
                //운동 횟수 18회 이하
                if (exerciseCount <= 18)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 18회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //70-74세
            else if (age >= 70 && age <= 74)
            {
                //운동 횟수 17회 이하
                if (exerciseCount <= 17)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 17회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //75-79세
            else if (age >= 75 && age <= 79)
            {
                //운동 횟수 17회 이하
                if (exerciseCount <= 17)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 17회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //80-84세
            else if (age >= 80 && age <= 84)
            {
                //운동 횟수 15회 이하
                if (exerciseCount <= 15)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 15회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //85-89세
            else if (age >= 85 && age <= 89)
            {
                //운동 횟수 14회 이하
                if (exerciseCount <= 14)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 14회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //90-94세
            else if (age >= 90 && age <= 94)
            {
                //운동 횟수 12회 이하
                if (exerciseCount <= 12)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 12회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //94세 이상
            else if(age > 94)
            {
                if(exerciseCount <= 13)
                {
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                else
                {
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
        }
        else
        {
            if (age < 60)
            {
                if (exerciseCount <= 18)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //60-64세
            else if (age >= 60 && age <= 64)
            {
                //운동 횟수 17회 이하
                if (exerciseCount <= 17)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 17회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //65-69세
            else if (age >= 65 && age <= 69)
            {
                //운동 횟수 16회 이하
                if (exerciseCount <= 16)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 16회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //70-74세
            else if (age >= 70 && age <= 74)
            {
                //운동 횟수 15회 이하
                if (exerciseCount <= 15)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 15회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //75-79세
            else if (age >= 75 && age <= 79)
            {
                //운동 횟수 15회 이하
                if (exerciseCount <= 15)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 15회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //80-84세
            else if (age >= 80 && age <= 84)
            {
                //운동 횟수 14회 이하
                if (exerciseCount <= 14)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 14회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //85-89세
            else if (age >= 85 && age <= 89)
            {
                //운동 횟수 13회 이하
                if (exerciseCount <= 13)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 13회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //90-94세
            else if (age >= 90 && age <= 94)
            {
                //운동 횟수 11회 이하
                if (exerciseCount <= 11)
                {
                    //1단계(의자 있음)
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                //운동 횟수 11회 초과
                else
                {
                    //2단계(의자 없음)
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
            //94세 이상
            else if (age > 94)
            {
                if(exerciseCount <= 9)
                {
                    userInfo.GetComponent<UserInfo>().test1level = 1;
                }
                else
                {
                    userInfo.GetComponent<UserInfo>().test1level = 2;
                }
            }
        }
        gauge.SetActiveRecursively(false);
        next.SetActiveRecursively(true);
        start = false;
    }
}
