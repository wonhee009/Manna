using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour {
    public bool stay = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            stay = true;
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("keypad/ageselect") as Sprite;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            stay = false;
            this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("keypad/age") as Sprite;
        }
    }
}
