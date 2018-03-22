using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class twoGesture : MonoBehaviour, InteractionListenerInterface {

    public Text footText;
    public GameObject gauge;
    public GameObject gaugeFull;

    public int playerIndex = 0;

    private int currentIndex = -1;
    private int prevIndex = -1;

    public GameObject userInfo;
    public GameObject exerCon;

    public GameObject inter;

    public Text count;

    public int mode = 0;

    // Use this for initialization
    void Start () {
      
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
                case 1:
                    Debug.Log("왼쪽 넘어가기");
                    exerCon.GetComponent<testTwotwoRightCount>().start = false;
                    count.text = "0";

                    footText.text = "왼발 운동 중";
                    Vector3 dd = new Vector3(-500f, 0, 0);
                    gauge.transform.Translate(dd);
                    gaugeFull.transform.Translate(dd);
                    
                    exerCon.GetComponent<testTwotwoLeftCount>().count = 0;
                    gaugeFull.GetComponent<Image>().fillAmount = 0;

                    exerCon.GetComponent<testTwotwoLeftCount>().start = true;
                    break;

                case 2:
                    Debug.Log("다음 동작");
                    Destroy(inter);
                    SceneManager.LoadScene("0000000000000000/05.test2/fiveScene");
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
