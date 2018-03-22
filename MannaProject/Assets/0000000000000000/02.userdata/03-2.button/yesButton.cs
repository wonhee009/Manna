using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesButton : MonoBehaviour {

    public GameObject age;
    public GameObject yButton;
    public GameObject nButton;
    public GameObject Cursor;

    public GameObject btnController;

    private void OnEnable()
    {
        Debug.Log("y");
        age.SetActiveRecursively(true);
        yButton.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        Cursor.transform.position = new Vector3(0, 0, 0);
        btnController.GetComponent<totalConfirmButton>().mode = 2;
        this.GetComponent<yesButton>().enabled = false;
    }

}
