using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHi : MonoBehaviour {

    public GameObject Hi;

	void Awake()
    {
        Hi.SetActive(true);
    }
}
