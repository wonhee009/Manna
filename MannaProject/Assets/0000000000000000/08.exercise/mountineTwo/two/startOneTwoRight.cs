using UnityEngine;
using System.Collections;

public class startOneTwoRight : MonoBehaviour
{
    public GameObject prev_right;
    private void OnEnable()
    {
        prev_right.SetActiveRecursively(false);
        this.GetComponent<startOneTwoRight>().enabled = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
