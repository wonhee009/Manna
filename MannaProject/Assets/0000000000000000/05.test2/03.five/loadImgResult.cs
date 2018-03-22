using UnityEngine;
using System.Collections;

public class loadImgResult : MonoBehaviour
{
    WWW www;
    public GameObject userInfo;
    public string path;

    public Renderer rend;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        userInfo = GameObject.Find("userInfo");

        rend = GetComponent<Renderer>();

        path = userInfo.GetComponent<UserInfo>().photoPath;
        string temp_url = "file://";
        www = new WWW(temp_url + path);
        Texture2D texture = www.texture;

        rend.material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
