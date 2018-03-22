using UnityEngine;
using System.Collections;

public class exitTwo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        Application.Quit();
        this.GetComponent<exitTwo>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
