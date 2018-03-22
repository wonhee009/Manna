using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class nextTwo : MonoBehaviour
{

    private GameObject userInfo;
    public GameObject exerCon;
    public GameObject inter;

    public GameObject nextBtn;

    public GameObject time;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        userInfo = GameObject.Find("userInfo");
    }

    private void OnEnable()
    {
        Debug.Log("next");
        nextBtn.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        nextBtn.GetComponent<ButtonScript>().stay = false;
        userInfo.GetComponent<UserInfo>().exercise1_left = exerCon.GetComponent<exertwoLeftCount>().count;
        userInfo.GetComponent<UserInfo>().doExer = 2;
        Destroy(inter);
        //SceneManager.LoadScene("0000000000000000/07.exercisetutorial/fiveTutorialScene");
        time.SetActive(true);
        this.GetComponent<nextTwo>().enabled = false;
        
;    }

    // Update is called once per frame
    void Update()
    {

    }
}
