using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipTwoTu : MonoBehaviour {

    public GameObject inter;
    public int back;

	// Use this for initialization
	void Start () {
		
	}

    private void OnEnable()
    {
        
        back = GameObject.Find("userInfo").GetComponent<UserInfo>().background;

        switch (back)
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
        this.GetComponent<skipTwoTu>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
