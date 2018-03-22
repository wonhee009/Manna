using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btTotalBtn : MonoBehaviour, InteractionListenerInterface
{

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

    //확인
    public GameObject okButton;
    private bool okStay;

    //랜덤
    public GameObject randomButton;
    private bool randomStay;

    //배경
    public GameObject oneBg;
    public GameObject twoBg;
    public GameObject threeBg;
    public GameObject fourBg;
    public GameObject fiveBg;
    public GameObject sixBg;
    private bool oneStay;
    private bool twoStay;
    private bool threeStay;
    private bool fourStay;
    private bool fiveStay;
    private bool sixStay;

    private int ran;

    private void Awake()
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
                    okStay = okButton.GetComponent<ButtonScript>().stay;
                    randomStay = randomButton.GetComponent<ButtonScript>().stay;

                    oneStay = oneBg.GetComponent<ButtonScript>().stay;
                    twoStay = twoBg.GetComponent<ButtonScript>().stay;
                    threeStay = threeBg.GetComponent<ButtonScript>().stay;
                    fourStay = fourBg.GetComponent<ButtonScript>().stay;
                    fiveStay = fiveBg.GetComponent<ButtonScript>().stay;
                    sixStay = sixBg.GetComponent<ButtonScript>().stay;

                    if (selectedObject == null)
                    {
                        if (lastHandEvent == InteractionManager.HandEventType.Grip && screenNormalPos != Vector3.zero)
                        {
                            if(oneStay == true)
                            {
                                selectedObject = oneBg;
                            }
                            else if(twoStay == true)
                            {
                                selectedObject = twoBg;
                            }
                            else if (threeStay == true)
                            {
                                selectedObject = threeBg;
                            }
                            else if (fourStay == true)
                            {
                                selectedObject = fourBg;
                            }
                            else if (fiveStay == true)
                            {
                                selectedObject = fiveBg;
                            }
                            else if (sixStay == true)
                            {
                                selectedObject = sixBg;
                            }
                            else if (okStay == true)
                            {
                                selectedObject = okButton;
                            }
                            else if (randomStay == true)
                            {
                                selectedObject = randomButton;
                            }
                        }
                    }
                    else
                    {
                        bool isReleased = lastHandEvent == InteractionManager.HandEventType.Release;
                        if(selectedObject == oneBg && isReleased && oneStay == true)
                        {
                                this.GetComponent<AudioSource>().enabled = true;
                                this.GetComponent<btnAudioControll>().enabled = true;

                                doButton.GetComponent<bgOneBtn>().enabled = true;
                                selectedObject = null;
                                isReleased = false;
                        }
                        else if(selectedObject == twoBg && isReleased && twoStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgTwoBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == threeBg && isReleased && threeStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgThreeBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == fourBg && isReleased && fourStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgFourBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == fiveBg && isReleased && fiveStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgFiveBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == sixBg && isReleased && sixStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgSixBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == okButton && isReleased && okStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<bgConfirmBtn>().enabled = true;
                            selectedObject = null;
                            isReleased = false;
                        }
                        else if (selectedObject == randomButton && isReleased && randomButton == true)
                        {

                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<selectRandombg>().enabled = true;
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
