using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCursor : MonoBehaviour {

    public GameObject Cursor;

    private void Awake()
    {
        Cursor.SetActiveRecursively(true);
    }
    private void OnEnable()
    {
        Cursor.SetActiveRecursively(true);
    }
}
