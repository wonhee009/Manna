using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fiveGesture : MonoBehaviour, InteractionListenerInterface
{
    public Text footText;
    public GameObject gauge;
    public GameObject gaugeFull;

    public int playerIndex = 0;

    private int currentIndex = -1;
    private int prevIndex = -1;

    public GameObject userInfo;
    public GameObject exerCon;
    public GameObject Cursor;

    public GameObject can;
    public GameObject one;
    public GameObject two;
    public GameObject result;
    public GameObject userImg;
    public GameObject start;

    public Text count;

    public int mode = 0;

    // Use this for initialization
    void Start()
    {
    }

    public void UserLost(long userId, int userIndex)
    {
        if (userIndex != playerIndex)
            return;

        currentIndex = -1;
    }

    public void HandGripDetected(long userId, int userIndex, bool isRightHand, bool isHandInteracting, Vector3 handScreenPos)
    {
        if (userIndex != playerIndex)
            return;

        if (isRightHand && handScreenPos.y >= 0.5f)
        {

            switch (mode)
            {
                case 1:
                    Debug.Log("왼쪽 넘어가기");
                
                    exerCon.GetComponent<testTwofiveRightCount>().start = false;
                    count.text = "0";

                    footText.text = "왼발 운동 중";
                    Vector3 dd = new Vector3(-500f, 0, 0);
                    gauge.transform.Translate(dd);
                    gaugeFull.transform.Translate(dd);
                    gaugeFull.GetComponent<Image>().fillAmount = 0;

                    exerCon.GetComponent<testTwofiveLeftCount>().count = 0;    
                    exerCon.GetComponent<testTwofiveLeftCount>().start = true;
                    break;

                case 2:
                    Debug.Log("test2 결과");
            
                    can.SetActiveRecursively(true);
                    one.SetActiveRecursively(false);
                    two.SetActiveRecursively(false);
                    userImg.SetActiveRecursively(false);
                    start.SetActiveRecursively(false);
                    
                    result.SetActiveRecursively(true);
                    Cursor.SetActiveRecursively(true);
                    mode = 0;
                    break;
            }
        }
    }

    public void HandReleaseDetected(long userId, int userIndex, bool isRightHand, bool isHandInteracting, Vector3 handScreenPos)
    {
        if (userIndex != playerIndex)
            return;

    }

    public bool HandClickDetected(long userId, int userIndex, bool isRightHand, Vector3 handScreenPos)
    {
        if (userIndex != playerIndex)
            return false;

        return true;
    }
}
