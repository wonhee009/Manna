using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImg : MonoBehaviour {

    WWW www;
    public GameObject userInfo;
    public string path;

    public Renderer rend;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        rend = GetComponent<Renderer>();

        path = userInfo.GetComponent<UserInfo>().photoPath;
        string temp_url = "file://";
        www = new WWW(temp_url + path);
        Texture2D texture = www.texture;

        rend.material.mainTexture = texture;

        this.GetComponent<LoadImg>().enabled = false;
    }
}
