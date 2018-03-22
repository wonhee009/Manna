using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    public GameObject user;

    public int playerIndex = 0;

    private KinectManager kinectManager;
    private FacetrackingManager faceManager;

    // Use this for initialization
    void Start()
    {
        kinectManager = KinectManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(faceManager == null)
        {
            faceManager = FacetrackingManager.Instance;
        }

        if (!kinectManager || !kinectManager.IsInitialized())
            return;
        if (!faceManager || !faceManager.IsFaceTrackingInitialized())
            return;

        long userId = kinectManager.GetUserIdByIndex(playerIndex);

        if(userId == 0)
        {
            return;
        }
    }
}
