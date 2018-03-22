using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadImgFinal : MonoBehaviour {

    WWW www;
    public GameObject userInfo;
    public string path;

    public Renderer rend;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        rend = GetComponent<Renderer>();

        path = userInfo.GetComponent<UserInfo>().photoPath;
        string temp_url = "file://";
        www = new WWW(temp_url + path);
        Texture2D texture = www.texture;

        rend.material.mainTexture = texture;
    }
}
