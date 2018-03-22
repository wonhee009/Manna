using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultBtnCon : MonoBehaviour, InteractionListenerInterface
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

    //skip
    public GameObject okButton;
    private bool okStay;

    private void Awake()
    {
        //InteractionManager instance 생성
        if (interactionManager == null)
        {
            interactionManager = InteractionManager.Instance;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactionManager != null && interactionManager.IsInteractionInited())
        {
            switch (mode)
            {
                case 1:
                    okStay = okButton.GetComponent<ButtonScript>().stay;

                    if (selectedObject == null)
                    {
                        if (lastHandEvent == InteractionManager.HandEventType.Grip && screenNormalPos != Vector3.zero)
                        {
                            if (okStay == true)
                            {
                                selectedObject = okButton;
                            }
                        }
                    }
                    else
                    {
                        bool isReleased = lastHandEvent == InteractionManager.HandEventType.Release;
                        if (selectedObject == okButton && isReleased && okStay == true)
                        {
                            this.GetComponent<AudioSource>().enabled = true;
                            this.GetComponent<btnAudioControll>().enabled = true;

                            doButton.GetComponent<goFeed>().enabled = true;
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
