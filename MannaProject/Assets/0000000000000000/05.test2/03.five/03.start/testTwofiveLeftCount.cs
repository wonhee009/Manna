using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTwofiveLeftCount : MonoBehaviour
{
    public bool start = false;
    public bool start2 = false;
    public GameObject ges;

    public GameObject player;
    private int playerIndex = 0;
    public int count = 0;
    public Text countInfo;

    /* 왼쪽 발목 x */
    //AnkleLeft 좌표
    private Vector3 ankleLeftJointPosition;
    //AnkleLeft
    private KinectInterop.JointType ankleLeftJoint = KinectInterop.JointType.AnkleLeft;

    /* 오른쪽 발목 x */
    //AnkleRight 좌표
    private Vector3 ankleRightJointPosition;
    //AnkleRight
    private KinectInterop.JointType ankleRightJoint = KinectInterop.JointType.AnkleRight;

    /* 오-왼 x */
    //min R-L.x
    private double minAnkleRLValueDouble;
    //max R-L.x
    private double maxAnkleRLValueDouble;
    //R-L.x
    private double ankleRLValue;

    /* 바깥 상태 */
    public bool outState = false;
    public bool degreeState = false;

    /* 칼만 필터 */
    private double Q = 0.000001;
    private double R = 0.01;
    private double P = 1, X = 0, K;
    //ankleRLValue 칼만
    private double kalmanAnkleRL;

    /* 다리 각도 */
    private Vector3 kneeLeftJointPosition;
    //KneeLeft
    private KinectInterop.JointType kneeLeftJoint = KinectInterop.JointType.KneeLeft;
    //KLA
    private float KLA;
    //side
    private Vector3 Side = new Vector3(-1, -1, 0);
    //ALKL
    private Vector3 ALKL;

    private GameObject user;

    private void Awake()
    {
        user = GameObject.Find("userInfo");
    }

    // Use this for initialization
    void Start()
    {
        minAnkleRLValueDouble = 0;
        maxAnkleRLValueDouble = minAnkleRLValueDouble;
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
            if (start2 == false)
            {
                ges.GetComponent<fiveGesture>().mode = 2;
                start2 = true;
            }
            KinectManager manager = KinectManager.Instance;

            if (manager && manager.IsInitialized())
            {
                if (manager.IsUserDetected(playerIndex))
                {
                    long userId = manager.GetUserIdByIndex(playerIndex);
                    if (manager.IsJointTracked(userId, (int)ankleLeftJoint))
                    {
                        //AnkleLeft Joint Position
                        Vector3 ankleLeftJointPos = manager.GetJointPosition(userId, (int)ankleLeftJoint);
                        //AnkleRight Joint Position
                        Vector3 ankleRightJointPos = manager.GetJointPosition(userId, (int)ankleRightJoint);

                        //KneeLeft Joint Position
                        Vector3 kneeLeftJointPos = manager.GetJointPosition(userId, (int)kneeLeftJoint);
                        kneeLeftJointPosition = kneeLeftJointPos;

                        ankleLeftJointPosition = ankleLeftJointPos;
                        ankleRightJointPosition = ankleRightJointPos;

                        ALKL = ankleLeftJointPosition - kneeLeftJointPosition;
                        KLA = GetDegree(ALKL, Side);

                        if (KLA > 30)
                        {
                            degreeState = true;
                        }

                        ankleRLValue = ankleRightJointPos.x - ankleLeftJointPos.x;

                        kalmanAnkleRL = (double)Mathf.Round((float)KalmanUpdate(ankleRLValue * 100));

                        if (outState == false)
                        {
                            if (minAnkleRLValueDouble == 0)
                            {
                                minAnkleRLValueDouble = kalmanAnkleRL;
                                maxAnkleRLValueDouble = minAnkleRLValueDouble;
                            }
                            else
                            {
                                if (minAnkleRLValueDouble > kalmanAnkleRL)
                                {
                                    minAnkleRLValueDouble = kalmanAnkleRL;
                                    maxAnkleRLValueDouble = minAnkleRLValueDouble;
                                }
                                if (kalmanAnkleRL > maxAnkleRLValueDouble)
                                {
                                    maxAnkleRLValueDouble = kalmanAnkleRL;
                                }
                                else if (kalmanAnkleRL <= maxAnkleRLValueDouble - 2)
                                {
                                    if (degreeState == true)
                                    {
                                        outState = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (kalmanAnkleRL <= minAnkleRLValueDouble + 8)
                            {
                                this.GetComponent<Progress>().startProgress();
                                count++;

                                user.GetComponent<UserInfo>().test2_2_left = count;

                                string countMessage = string.Format("{0:F0}", count);
                                countInfo.text = countMessage;

                                outState = false;
                                degreeState = false;

                                minAnkleRLValueDouble = 0;
                                maxAnkleRLValueDouble = minAnkleRLValueDouble;
                            }
                        }
                    }
                }
            }
        }
    }
}
