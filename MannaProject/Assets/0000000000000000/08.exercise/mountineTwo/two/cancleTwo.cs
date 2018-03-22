using UnityEngine;
using System.Collections;

public class cancleTwo : MonoBehaviour
{
    public GameObject exerCon;

    public GameObject userImage;
    public GameObject gauge;
    public GameObject gaugeFull;

    public GameObject cancleBtn;
    // Use this for initialization
    void Start()
    {

    }

    private void OnEnable()
    {
        gauge.SetActiveRecursively(true);
        gauge.GetComponent<Animator>().enabled = false;
        gaugeFull.SetActive(true);
        cancleBtn.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        cancleBtn.GetComponent<ButtonScript>().stay = false;
        userImage.SetActiveRecursively(true);
        
        exerCon.GetComponent<exertwoLeftCount>().start = true;
        this.GetComponent<cancleTwo>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
