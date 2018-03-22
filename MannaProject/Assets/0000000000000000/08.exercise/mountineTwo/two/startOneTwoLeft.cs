using UnityEngine;
using System.Collections;

public class startOneTwoLeft : MonoBehaviour
{

    public GameObject prev_left;

    private void OnEnable()
    {
        prev_left.SetActiveRecursively(false);
        this.GetComponent<startOneTwoLeft>().enabled = false;
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
