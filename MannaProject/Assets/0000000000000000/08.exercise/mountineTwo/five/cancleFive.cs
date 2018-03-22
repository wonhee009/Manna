using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancleFive : MonoBehaviour {

    public GameObject exerCon;

    public GameObject userImage;
    public GameObject gauge;
    public GameObject gaugeFull;

    public GameObject cancleBtn;

    private void OnEnable()
    {
        cancleBtn.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        cancleBtn.GetComponent<ButtonScript>().stay = false;
        userImage.SetActiveRecursively(true);
        gauge.GetComponent<Animator>().enabled = false;
        gauge.SetActiveRecursively(true);
        gaugeFull.SetActive(true);
        exerCon.GetComponent<exerfiveLeftCount>().start = true;
        this.GetComponent<cancleFive>().enabled = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
