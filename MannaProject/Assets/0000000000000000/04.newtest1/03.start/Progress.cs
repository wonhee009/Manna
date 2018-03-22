using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Progress : MonoBehaviour {

    public Image Bar;
    public float start_state = 100f;
    public float cur_state = 0f;


    public GameObject Value;

    // Use this for initialization
    void Start () {
		
	}

    public void startProgress()
    {
        InvokeRepeating("increaseState", 0f, 0.1f);
        Value.SetActiveRecursively(true);
    }

    void setZero()
    {
        Bar.fillAmount = 0;
        cur_state = 0f;
    }

    void increaseState()
    {
        cur_state += (float)8.45;
        float calc_state = cur_state / start_state;
        SetState(calc_state);
        if (calc_state >= 1.1)
        {
            setZero();
            CancelInvoke("increaseState");
            //Value.SetActiveRecursively(false);

        }
    }

    void SetState(float myState)
    {
        Bar.fillAmount = myState;
    }
}
