using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour {
    public GameObject one;
    public GameObject two;
    public GameObject ok_not;
    public GameObject ok;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        if(two.GetComponent<Text>().text != "")
        {
            two.GetComponent<Text>().text = "";
            ok.SetActiveRecursively(false);
            ok.GetComponent<BoxCollider>().enabled = false;
            ok_not.SetActiveRecursively(true);
        }
        else if(one.GetComponent<Text>().text != "")
        {
            one.GetComponent<Text>().text = "";
        }
        this.GetComponent<DeleteButton>().enabled = false;
    }
}
