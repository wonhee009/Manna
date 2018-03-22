using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalConfirmButton : MonoBehaviour, InteractionListenerInterface {

    [Tooltip("손 인터랙션을 추적할 Interaction manager 인스턴스 생성")]
    public InteractionManager interactionManager;
    //손 인터랙션 직전 상태 변수
    private InteractionManager.HandEventType lastHandEvent = InteractionManager.HandEventType.None;
    //커서의 위치-->초기 값은 0
    private Vector3 screenNormalPos = Vector3.zero;
    //선택된 오브젝트
    private GameObject selectedObject;
    public GameObject priorObject;

    public int mode = 0;

    //버튼 동작 오브젝트
    public GameObject doButton;

    //네, 아니오
    public GameObject yesButton;
    public GameObject noButton;
    private bool yesStay;
    private bool noStay;

    //나이
    public GameObject oneButton;
    public GameObject twoButton;
    public GameObject threeButton;
    public GameObject fourButton;
    public GameObject fiveButton;
    public GameObject sixButton;
    public GameObject sevenButton;
    public GameObject eightButton;
    public GameObject nineButton;
    public GameObject zeroButton;
    private bool oneStay;
    private bool twoStay;
    private bool threeStay;
    private bool fourStay;
    private bool fiveStay;
    private bool sixStay;
    private bool sevenStay;
    private bool eightStay;
    private bool nineStay;
    private bool zeroStay;

    //지우기, 확인
    public GameObject deleteButton;
    public GameObject okButton;
    private bool deleteStay;
    private bool okStay;

    //남자, 여자
    public GameObject manButton;
    public GameObject womanButton;
    private bool manStay;
    private bool womanStay;

    void Awake()
    {
        //InteractionManager instance 생성
        if (interactionManager == null)
        {
            interactionManager = InteractionManager.Instance;
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(interactionManager != null && interactionManager.IsInteractionInited())
        {
            switch (mode)
            {
                case 1:
                    yesStay = yesButton.GetComponent<ButtonScript>().stay;
                    noStay = noButton.GetComponent<ButtonScript>().stay;

                    if(selectedObject == null)
                    {
                        if (lastHandEvent == InteractionManager.HandEventType.Grip && screenNormalPos != Vector3.zero)
                        {
                            if (yesStay == true && noStay == false)
                            {
                                selectedObject = yesButton;
                            }
                            else if (noStay == true && yesStay == false)
                            {
                                selectedObject = noButton;
                            }

                        }
                    }
                    else
                    {
                        bool isReleased = lastHandEvent == InteractionManager.HandEventType.Release;
                        if (selectedObject == yesButton && isReleased && yesStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<yesButton>().enabled = true;
                            falseButton();
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == noButton && isReleased && noStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<noButton>().enabled = true;
                            falseButton();
                            selectedObject = null;
                            isReleased = false;
                        }
                    }
                    break;

                case 2:
                    oneStay = oneButton.GetComponent<KeyButton>().stay;
                    twoStay = twoButton.GetComponent<KeyButton>().stay;
                    threeStay = threeButton.GetComponent<KeyButton>().stay;
                    fourStay = fourButton.GetComponent<KeyButton>().stay;
                    fiveStay = fiveButton.GetComponent<KeyButton>().stay;
                    sixStay = sixButton.GetComponent<KeyButton>().stay;
                    sevenStay = sevenButton.GetComponent<KeyButton>().stay;
                    eightStay = eightButton.GetComponent<KeyButton>().stay;
                    nineStay = nineButton.GetComponent<KeyButton>().stay;
                    zeroStay = zeroButton.GetComponent<KeyButton>().stay;

                    deleteStay = deleteButton.GetComponent<ButtonScript>().stay;
                    okStay = okButton.GetComponent<ButtonScript>().stay;

                    if (lastHandEvent == InteractionManager.HandEventType.Grip && screenNormalPos != Vector3.zero)
                    {
                        if (oneStay == true)
                        {
                            selectedObject = oneButton;
                        }
                        else if (twoStay == true && oneStay == false && threeStay == false && sixStay == false && sevenStay == false && eightStay == false)
                        {
                            selectedObject = twoButton;
                        }
                        else if (threeStay == true && twoStay == false && fourStay == false && sevenStay == false && eightStay == false && nineStay == false)
                        {
                            selectedObject = threeButton;
                        }
                        else if (fourStay == true && threeStay == false && fiveStay == false && eightStay == false && nineStay == false && zeroStay == false)
                        {
                            selectedObject = fourButton;
                        }
                        else if (fiveStay == true && fourStay == false && nineStay == false && zeroStay == false)
                        {
                            selectedObject = fiveButton;
                        }
                        else if (sixStay == true && oneStay == false && twoStay == false && sevenStay == false)
                        {
                            selectedObject = sixButton;
                        }
                        else if (sevenStay == true && oneStay == false && twoStay == false && threeStay == false && sixStay == false && eightStay == false)
                        {
                            selectedObject = sevenButton;
                        }
                        else if (eightStay == true && twoStay == false && threeStay == false && fourStay == false && sevenStay == false && nineStay == false)
                        {
                            selectedObject = eightButton;
                        }
                        else if (nineStay == true && threeStay == false && fourStay == false && fiveStay == false && eightStay == false && zeroStay == false)
                        {
                            selectedObject = nineButton;
                        }
                        else if (zeroStay == true && fourStay == false && fiveStay == false && nineStay == false)
                        {
                            selectedObject = zeroButton;
                        }
                        else if (deleteStay == true)
                        {
                            selectedObject = deleteButton;
                        }
                        else if (okStay == true)
                        {
                            selectedObject = okButton;
                        }
                    }
                    else
                    {
                        //선택된 오브젝트가 있을때 손을 편 상태면
                        bool isReleased = lastHandEvent == InteractionManager.HandEventType.Release;

                        if (selectedObject == oneButton && isReleased && oneStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<oneButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == twoButton && isReleased && twoStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<twoButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == threeButton && isReleased && threeStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<threeButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == fourButton && isReleased && fourStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<fourButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == fiveButton && isReleased && fiveStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<fiveButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == sixButton && isReleased && sixStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<sixButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == sevenButton && isReleased && sevenStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<sevenButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == eightButton && isReleased && eightStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<eightButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == nineButton && isReleased && nineStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<nineButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == zeroButton && isReleased && zeroStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<zeroButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == deleteButton && isReleased && deleteStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<DeleteButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == okButton && isReleased && okStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<okButton>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                    }
                    break;

                case 3:
                    manStay = manButton.GetComponent<ButtonScript>().stay;
                    womanStay = womanButton.GetComponent<ButtonScript>().stay;

                    if (selectedObject == null)
                    {
                        if (lastHandEvent == InteractionManager.HandEventType.Grip && screenNormalPos != Vector3.zero)
                        {
                            if (manStay == true && womanStay == false)
                            {
                                selectedObject = manButton;
                            }
                            else if (womanStay == true && manStay == false)
                            {
                                selectedObject = womanButton;
                            }

                        }
                    }
                    else
                    {
                        bool isReleased = lastHandEvent == InteractionManager.HandEventType.Release;
                        if (selectedObject == manButton && isReleased && manStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<ManButton>().enabled = true;
                            falseButton();
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == womanButton && isReleased && womanStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;
                            doButton.GetComponent<WomanButton>().enabled = true;
                            falseButton();
                            selectedObject = null;
                            isReleased = false;
                        }
                    }
                    break;
            }
        }
	}

    //손을 쥐었을때
    public void HandGripDetected(long userId, int userIndex, bool isRightHand, bool isHandInteracting, Vector3 handScreenPos)
    {
        if (!isHandInteracting || !interactionManager)
            return;
        if (userId != interactionManager.GetUserID())
            return;

        //직전 손 상태를 Grip으로 지정
        lastHandEvent = InteractionManager.HandEventType.Grip;
        screenNormalPos = handScreenPos;
    }

    //손을 폈을때
    public void HandReleaseDetected(long userId, int userIndex, bool isRightHand, bool isHandInteraction, Vector3 handScreenPos)
    {
        if (!isHandInteraction || !interactionManager)
            return;
        if (userId != interactionManager.GetUserID())
            return;

        //직전 손 상태를 Release로 지정
        lastHandEvent = InteractionManager.HandEventType.Release;
        screenNormalPos = handScreenPos;
    }

    public bool HandClickDetected(long userId, int userIndex, bool isRightHand, Vector3 handScreenPos)
    {
        return true;
    }

    void falseButton()
    {
        priorObject.SetActiveRecursively(false);
    }
}
