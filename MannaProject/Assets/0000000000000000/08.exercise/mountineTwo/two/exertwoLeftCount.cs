using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exertwoLeftCount : MonoBehaviour {

    public bool start = false;
    public bool start2 = false;
    public GameObject ges;

    public GameObject player;
    private int playerIndex = 0;
    public int count = 0;
    public Text countInfo;

    public GameObject complete;

    private int level;

    /* 왼쪽 무릎 높이 */
    //KneeLeft 좌표
    private Vector3 kneeLeftJointPosition;
    //KneeLeft
    private KinectInterop.JointType kneeLeftJoint = KinectInterop.JointType.KneeLeft;
    //min kneeLeft.y
    private double minKneeLeftValueDouble;
    //max kneeLeft.y
    private double maxKneeLeftValueDouble;

    /* 올린 상태 */
    public bool up = false;
    public bool kneeLeftDegree = false;

    /* 왼쪽 무릎 각도 */
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
    //HipLeft 좌표
    private Vector3 hipLeftJointPosition;
    //AnkleLeft 좌표
    private Vector3 ankleLeftJointPosition;

    /* 칼만 필터 */
    private double Q = 0.000001;
    private double R = 0.01;
    private double P = 1, X = 0, K;
    //KneeLeft 칼만
    private double kalmanKneeLeft;

    // Use this for initialization
    void Start () {
        minKneeLeftValueDouble = 0;
        maxKneeLeftValueDouble = minKneeLeftValueDouble;
    }

    private void Awake()
    {
        level = GameObject.Find("userInfo").GetComponent<UserInfo>().test2_1level;
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
    void Update () {
		if(start == true)
        {
            if(start2 == false)
            {
                if (count >= 3)
                {
                    ges.GetComponent<twoExerGes>().mode = 2;
                    start2 = true;
                }
                else
                {
                    ges.GetComponent<twoExerGes>().mode = 0;
                }
            }

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

                        kneeLeftJointPosition = kneeLeftJointPos;
                        hipLeftJointPosition = hipLeftJointPos;
                        ankleLeftJointPosition = ankleLeftJointPos;

                        KLPL = kneeLeftJointPosition - hipLeftJointPosition;
                        ALKL = ankleLeftJointPosition - kneeLeftJointPosition;

                        KLA = GetDegree(KLPL, ALKL);

                        kalmanKneeLeft = (double)Mathf.Round((float)KalmanUpdate(kneeLeftJointPosition.y * 100));

                        if (KLA > 70)
                        {
                            kneeLeftDegree = true;
                        }

                        //무릎 내린 상태
                        if (up == false)
                        {
                            //최소값 최초 설정
                            if (minKneeLeftValueDouble == 0)
                            {
                                minKneeLeftValueDouble = kalmanKneeLeft;
                                maxKneeLeftValueDouble = minKneeLeftValueDouble;
                            }
                            //최소값 설정 이후
                            else
                            {
                                //최소값 보정
                                if (minKneeLeftValueDouble > kalmanKneeLeft)
                                {
                                    minKneeLeftValueDouble = kalmanKneeLeft;
                                    maxKneeLeftValueDouble = minKneeLeftValueDouble;
                                }
                                //최대값 보정
                                if (kalmanKneeLeft > maxKneeLeftValueDouble)
                                {
                                    maxKneeLeftValueDouble = kalmanKneeLeft;
                                }
                                //최대값 범위 벗어나면 앉은 상태
                                else if (kalmanKneeLeft <= maxKneeLeftValueDouble - 1)
                                {
                                    up = true;
                                }
                            }
                        }
                        //무릎 올린 상태
                        else
                        {
                            //최소 값 범위에 들어오면 무릎 내린 상태
                            if (kalmanKneeLeft <= minKneeLeftValueDouble + 10 & kneeLeftDegree)
                            {
                                this.GetComponent<Progress>().startProgress();
                                count++;

                                switch (level)
                                {
                                    case 1:
                                        if(count == 7)
                                        {
                                            complete.SetActive(true);
                                            complete.GetComponent<completeAnim>().enabled = true;
                                        }
                                        break;

                                    case 2:
                                        if(count == 9)
                                        {
                                            complete.SetActive(true);
                                            complete.GetComponent<completeAnim>().enabled = true;
                                        }
                                        break;

                                    case 3:
                                        if(count == 11)
                                        {
                                            complete.SetActive(true);
                                            complete.GetComponent<completeAnim>().enabled = true;
                                        }
                                        break;
                                }

                                string countMessage = string.Format("{0:F0}", count);
                                countInfo.text = countMessage;

                                up = false;
                                kneeLeftDegree = false;

                                minKneeLeftValueDouble = 0;
                                maxKneeLeftValueDouble = minKneeLeftValueDouble;
                            }
                        }
                    }
                }
            }
        }
	}
}
