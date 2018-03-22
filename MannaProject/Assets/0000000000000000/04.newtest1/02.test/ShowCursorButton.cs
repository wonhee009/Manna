using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursorButton : MonoBehaviour {

    public GameObject Cursor;
    public GameObject Button;

	// Use this for initialization
	void Awake () {
        Cursor.SetActiveRecursively(true);
        Button.SetActiveRecursively(true);
	}
}
