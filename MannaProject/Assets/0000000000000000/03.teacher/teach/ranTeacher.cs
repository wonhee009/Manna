using UnityEngine;
using System.Collections;

public class ranTeacher : MonoBehaviour
{
    public GameObject teacher1;
    public GameObject teacher2;
    public GameObject teacher3;

    private int ran;

    // Use this for initialization
    void Start()
    {
        ran = Random.Range(1, 4);

        switch (ran)
        {
            case 1:
                teacher1.SetActive(true);
                break;

            case 2:
                teacher2.SetActive(true);
                break;

            case 3:
                teacher3.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
