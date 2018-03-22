using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class twoExerGes : MonoBehaviour, InteractionListenerInterface
{
    public Text footText;
    public GameObject gauge;
    public GameObject gaugeFull;

    public int playerIndex = 0;

    private int currentIndex = -1;
    private int prevIndex = -1;

    public GameObject userInfo;
    public GameObject exerCon;
    public GameObject btnCon;

    public GameObject inter;

    public Text count;

    public int mode = 0;

    public GameObject notYet;

    public GameObject pop;
    public GameObject onetwo;

    public GameObject userImage;

	// Use this for initialization
	void Start () {
        userInfo = GameObject.Find("userInfo");
    }
	
	// Update is called once per frame
	void Update () {
		
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
                case 0:
                    Debug.Log("rr");
                    if (notYet.GetComponent<onetwo>().con == true)
                    {
                        notYet.SetActiveRecursively(true);
                        notYet.GetComponent<onetwo>().enabled = true;
                    }
                    break;

                case 1:
                    Debug.Log("왼쪽 넘어가기");
                    exerCon.GetComponent<exertwoRightCount>().start = false;
                    count.text = "0";

                    footText.text = "왼발 운동 중";
                    Vector3 dd = new Vector3(-500f, 0, 0);
                    gauge.transform.Translate(dd);
                    gaugeFull.transform.Translate(dd);

                    exerCon.GetComponent<exertwoLeftCount>().count = 0;
                    userInfo.GetComponent<UserInfo>().exercise1_right = exerCon.GetComponent<exertwoRightCount>().count;
                    exerCon.GetComponent<exertwoLeftCount>().start = true;
                    mode = 0;

                    break;

                case 2:
                    onetwo.SetActiveRecursively(false);

                    userImage.SetActiveRecursively(false);
                    gauge.SetActive(false);
                    gaugeFull.SetActive(false);
                    pop.SetActiveRecursively(true);
                    pop.GetComponent<popDeadAudio>().enabled = true;
                    btnCon.GetComponent<twoPopCon>().mode = 1;
                    exerCon.GetComponent<exertwoLeftCount>().start = false;
                    break;

                case 3:
                    Debug.Log("왼쪽 넘어가기");
                    userInfo.GetComponent<UserInfo>().exercise1_right = exerCon.GetComponent<exerfiveRightCount>().count;

                    exerCon.GetComponent<exerfiveRightCount>().start = false;
                    count.text = "0";

                    footText.text = "왼발 운동 중";
                    Vector3 dd2 = new Vector3(-500f, 0, 0);
                    gauge.transform.Translate(dd2);
                    gaugeFull.transform.Translate(dd2);

                    exerCon.GetComponent<exerfiveLeftCount>().count = 0;
                   
                    exerCon.GetComponent<exerfiveLeftCount>().start = true;
                    mode = 0;

                    break;

                case 4:
                    onetwo.SetActiveRecursively(false);

                    userImage.SetActiveRecursively(false);
                    gauge.SetActive(false);
                    gaugeFull.SetActive(false);
                    pop.SetActiveRecursively(true);
                    pop.GetComponent<popDeadAudio>().enabled = true;
                    btnCon.GetComponent<twoPopCon>().mode = 2;
                    exerCon.GetComponent<exerfiveLeftCount>().start = false;
                    //mode = 0;
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
