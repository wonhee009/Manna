using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public bool stay = false;

    public void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            stay = true;
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            stay = false;
            this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
}
