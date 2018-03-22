using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTwotwoRightCount : MonoBehaviour {

    public bool start = false;
    public bool start2 = false;
    public GameObject ges;

    public GameObject player;
    private int playerIndex = 0;
    public int count = 0;
    public Text countInfo;

    /* 오른쪽 무릎 높이 */
    //KneeRight 좌표
    private Vector3 kneeRightJointPosition;
    //KneeRight
    private KinectInterop.JointType kneeRightJoint = KinectInterop.JointType.KneeRight;
    //min kneeRight.y
    private double minKneeRightValueDouble;
    //max kneeRight.y
    private double maxKneeRightValueDouble;

    /* 올린 상태 */
    public bool up = false;
    public bool kneeRightDegree = false;

    /* 오른쪽 무릎 각도 */
    //HipRight
    private KinectInterop.JointType hipRightJoint = KinectInterop.JointType.HipRight;
    //AnkleRight
    private KinectInterop.JointType ankleRightJoint = KinectInterop.JointType.AnkleRight;
    //KRA
    private float KRA;
    //KRPR
    private Vector3 KRPR;
    //ARKR
    private Vector3 ARKR;

    /* 오른쪽 좌표 */
    //HipRight 좌표
    private Vector3 hipRightJointPosition;
    //AnkleRight 좌표
    private Vector3 ankleRightJointPosition;


    /* 칼만 필터 */
    private double Q = 0.000001;
    private double R = 0.01;
    private double P = 1, X = 0, K;
    //KneeRight 칼만
    private double kalmanKneeRight;

    private GameObject user;

    private void Awake()
    {
        user = GameObject.Find("userInfo");
    }

    // Use this for initialization
    void Start () {
        minKneeRightValueDouble = 0;
        maxKneeRightValueDouble = minKneeRightValueDouble;
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
            if(start2 == false)
            {
                ges.GetComponent<twoGesture>().mode = 1;
                start2 = true;
            }

            KinectManager manager = KinectManager.Instance;

            if (manager && manager.IsInitialized())
            {
                if (manager.IsUserDetected(playerIndex))
                {
                    long userId = manager.GetUserIdByIndex(playerIndex);
                    if (manager.IsJointTracked(userId, (int)kneeRightJoint))
                    {
                        //KneeRight Joint Position
                        Vector3 kneeRightJointPos = manager.GetJointPosition(userId, (int)kneeRightJoint);
                        //HipRight Joint Position
                        Vector3 hipRightJointPos = manager.GetJointPosition(userId, (int)hipRightJoint);
                        //AnkleRight Joint Position
                        Vector3 ankleRightJointPos = manager.GetJointPosition(userId, (int)ankleRightJoint);

                        kneeRightJointPosition = kneeRightJointPos;
                        hipRightJointPosition = hipRightJointPos;
                        ankleRightJointPosition = ankleRightJointPos;

                        KRPR = kneeRightJointPosition - hipRightJointPosition;
                        ARKR = ankleRightJointPosition - kneeRightJointPosition;

                        KRA = GetDegree(KRPR, ARKR);

                        kalmanKneeRight = (double)Mathf.Round((float)KalmanUpdate(kneeRightJointPosition.y * 100));

                        if (KRA > 60)
                        {
                            kneeRightDegree = true;
                        }

                        //무릎 내린 상태
                        if (up == false)
                        {
                            //최소값 최초 설정
                            if (minKneeRightValueDouble == 0)
                            {
                                minKneeRightValueDouble = kalmanKneeRight;
                                maxKneeRightValueDouble = minKneeRightValueDouble;
                            }
                            //최소값 설정 이후
                            else
                            {
                                //최소값 보정
                                if (minKneeRightValueDouble > kalmanKneeRight)
                                {
                                    minKneeRightValueDouble = kalmanKneeRight;
                                    maxKneeRightValueDouble = minKneeRightValueDouble;
                                }
                                //최대값 보정
                                if (kalmanKneeRight > maxKneeRightValueDouble)
                                {
                                    maxKneeRightValueDouble = kalmanKneeRight;
                                }
                                //최대값 범위 벗어나면 앉은 상태
                                else if (kalmanKneeRight <= maxKneeRightValueDouble - 1)
                                {
                                    up = true;
                                }
                            }
                        }
                        //무릎 올린 상태
                        else
                        {
                            //최소 값 범위에 들어오면 무릎 내린 상태
                            if (kalmanKneeRight <= minKneeRightValueDouble + 10 & kneeRightDegree)
                            {
                                this.GetComponent<Progress>().startProgress();
                                count++;

                                user.GetComponent<UserInfo>().test2_1_right = count;

                                string countMessage = string.Format("{0:F0}", count);
                                countInfo.text = countMessage;

                                up = false;
                                kneeRightDegree = false;

                                minKneeRightValueDouble = 0;
                                maxKneeRightValueDouble = minKneeRightValueDouble;
                            }
                        }
                    }
                }
            }
        }
    }
}
