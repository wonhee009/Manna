using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noButton : MonoBehaviour {

    public GameObject again;
    public GameObject Cursor;
    public GameObject nButton;
    public GameObject yButton;

    private void Start()
    {
    }

    private void OnEnable()
    {
        Debug.Log("n");
        if (nButton.GetComponent<ButtonScript>().stay == true)
        {
            nButton.transform.localScale -= new Vector3(0.1f, 0.1f, 0);

        }
        if (yButton.GetComponent<ButtonScript>().stay == true)
        {
            yButton.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
        nButton.GetComponent<ButtonScript>().stay = false;
        yButton.GetComponent<ButtonScript>().stay = false;
        Cursor.transform.position = new Vector3(0, 0, 0);
        again.SetActiveRecursively(true);
        again.GetComponent<againControll>().con = false;

        this.GetComponent<noButton>().enabled = false;
    }

}
