using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class skipGesture : MonoBehaviour, InteractionListenerInterface
{
    public int mode = 0;
    public int playerIndex = 0;

    private int currentIndex = -1;
    private int prevIndex = -1;

    public GameObject inter;

    // Use this for initialization
    void Start () {
		
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
                    Debug.Log("넘어가기");
                    

                    switch (GameObject.Find("userInfo").GetComponent<UserInfo>().background)
                    {
                        case 1:
                            SceneManager.LoadScene("0000000000000000/08.exercise/monutineTwoScene");
                            break;

                        case 2:
                            SceneManager.LoadScene("0000000000000000/08.exercise/fieldOneScene");
                            break;

                        case 3:
                            SceneManager.LoadScene("0000000000000000/08.exercise/seaOneScene");
                            break;

                        case 4:
                            SceneManager.LoadScene("0000000000000000/08.exercise/mountineOneScene");
                            break;

                        case 5:
                            SceneManager.LoadScene("0000000000000000/08.exercise/fieldTwoScene");
                            break;

                        case 6:
                            SceneManager.LoadScene("0000000000000000/08.exercise/seaOneScene");
                            break;
                    }
                    Destroy(inter);
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
