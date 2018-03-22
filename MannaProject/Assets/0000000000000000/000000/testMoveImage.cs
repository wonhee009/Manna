using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveImage : MonoBehaviour {
    [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
    public int playerIndex = 0;

    [Tooltip("Whether to use the face-rectangle provided by the FacetrackingManager, or not.")]
    //public bool useTrackedFaceRect = false;
    public bool useTrackedBodyRect = false;

    [Tooltip("Width of the rectangle around the head joint, in meters.")]
    //public float faceWidth = 1.0f;
    public float bodyWidth = 4.0f;
    [Tooltip("Height of the rectangle around the head joint, in meters.")]
    //public float faceHeight = 1.9f;
    public float bodyHeight = 4.0f;

    [Tooltip("Game object renderer, used to display the face image as 2D texture.")]
    public Renderer targetObject;


    //private Renderer targetRenderer;
    //private Rect faceRect;
    private Rect bodyRect;
    //private Texture2D colorTex, faceTex;
    private Texture2D colorTex, bodyTex;
    private KinectManager kinectManager;
    private FacetrackingManager faceManager;

    private BackgroundRemovalManager backManager;
    private RenderTexture foregroundTex = null;

    //private const int pixelAlignment = -2;  // must be negative power of 2

    /// <summary>
    /// Determines whether the face rectange and face texture are valid.
    /// </summary>
    /// <returns><c>true</c> if the face rectangle is valid; otherwise, <c>false</c>.</returns>
    /*
    public bool IsFaceRectValid()
    {
        return faceRect.width > 0 && faceRect.height > 0;
    }
    */
    public bool IsBodyRectValid()
    {
        return bodyRect.width > 0 && bodyRect.height > 0;
    }


    /// <summary>
    /// Gets the face rectangle, in pixels.
    /// </summary>
    /// <returns>The face rectangle.</returns>
    /*
    public Rect GetFaceRect()
    {
        return faceRect;
    }
    */
    public Rect GetBodyRect()
    {
        return bodyRect;
    }

    /// <summary>
    /// Gets the tracked face texture.
    /// </summary>
    /// <returns>The face texture.</returns>
    /*
    public Texture GetFaceTex()
    {
        return faceTex;
    }
    */
    public Texture GetBodyTex()
    {
        return bodyTex;
    }


    void Start()
    {
        kinectManager = KinectManager.Instance;
        //faceTex = new Texture2D(100, 100, TextureFormat.ARGB32, false);
        bodyTex = new Texture2D(100, 100, TextureFormat.ARGB32, false);

        if (!targetObject)
        {
            targetObject = GetComponent<Renderer>();
        }

        if (targetObject && targetObject.material)
        {
            targetObject.material.SetTextureScale("_MainTex", new Vector2(1, -1));
        }
    }

    void Update()
    {
        if (faceManager == null)
        {
            faceManager = FacetrackingManager.Instance;
        }

        if (!kinectManager || !kinectManager.IsInitialized())
            return;
        if (!faceManager || !faceManager.IsFaceTrackingInitialized())
            return;

        long userId = kinectManager.GetUserIdByIndex(playerIndex);
        if (userId == 0)
        {
            if (targetObject && targetObject.material && targetObject.material.mainTexture != null)
            {
                targetObject.material.mainTexture = null;
            }

            return;
        }

        if (!backManager)
        {
            backManager = BackgroundRemovalManager.Instance;

            if (backManager)
            {
                // re-initialize the texture
                colorTex = null;
            }
        }

        if (!foregroundTex && backManager && backManager.IsBackgroundRemovalInitialized())
        {
            // use foreground image
            foregroundTex = (RenderTexture)backManager.GetForegroundTex();

        }
        else
        {
            // use color camera image
            if (!colorTex)
            {
                colorTex = kinectManager.GetUsersClrTex();
            }
        }

        //faceRect = GetHeadJointFaceRect(userId);
        bodyRect = GetHeadAnkleJointBodyRect(userId);

        if (bodyRect.width > 0 && bodyRect.height > 0)
        {

            int bodyX = (int)bodyRect.x;
            int bodyY = (int)bodyRect.y;
            int bodyW = (int)bodyRect.width;
            int bodyH = (int)bodyRect.height;
            if (bodyX < 0) bodyX = 0;
            if (bodyY < 0) bodyY = 0;

            Debug.Log(bodyX);
            Debug.Log(bodyY);
            Debug.Log(bodyW);
            Debug.Log(bodyH);


            if (foregroundTex)
            {
                if ((bodyX + bodyW) > foregroundTex.width) bodyW = foregroundTex.width - bodyX;
                if ((bodyY + bodyH) > foregroundTex.height) bodyH = foregroundTex.height - bodyY;
            }
            else if (colorTex)
            {
                if ((bodyX + bodyW) > colorTex.width) bodyW = colorTex.width - bodyX;
                if ((bodyY + bodyH) > colorTex.height) bodyH = colorTex.height - bodyY;
            }

            if (bodyTex.width != bodyW || bodyTex.height != bodyH)
            {
                bodyTex.Resize(bodyW, bodyH);
            }

            if (foregroundTex)
            {
                KinectInterop.RenderTex2Tex2D(foregroundTex, bodyX, foregroundTex.height - bodyY - bodyH, bodyW, bodyH, ref bodyTex);
            }
            else if (colorTex)
            {
                Color[] colorPixels = colorTex.GetPixels(bodyX, bodyY, bodyW, bodyH, 0);
                bodyTex.SetPixels(colorPixels);
                bodyTex.Apply();
            }

            if (targetObject && !targetObject.gameObject.activeSelf)
            {
                targetObject.gameObject.SetActive(true);
            }

            if (targetObject && targetObject.material)
            {
                targetObject.material.mainTexture = bodyTex;
            }

            // don't rotate the transform - mesh follows the head rotation
            if (targetObject.transform.rotation != Quaternion.identity)
            {
                targetObject.transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            if (targetObject && targetObject.gameObject.activeSelf)
            {
                targetObject.gameObject.SetActive(false);
            }

            if (targetObject && targetObject.material && targetObject.material.mainTexture != null)
            {
                targetObject.material.mainTexture = null;
            }
        }
    }

    //private Rect GetHeadJointFaceRect(long userId)
    private Rect GetHeadAnkleJointBodyRect(long userId)
    {
        Rect BodyJointRect = new Rect();

        if(useTrackedBodyRect && faceManager && 
            faceManager.IsFaceTrackingInitialized() && faceManager.IsTrackingFace(userId))
        {
            BodyJointRect = faceManager.GetFaceColorRect(userId);
            return BodyJointRect;
        }

        if (kinectManager.IsJointTracked(userId, (int)KinectInterop.JointType.Head))
        {
            Vector3 posHeadRaw = kinectManager.GetJointKinectPosition(userId, (int)KinectInterop.JointType.Head);

            Vector3 posAnkleRaw = kinectManager.GetJointKinectPosition(userId, (int)KinectInterop.JointType.AnkleLeft);

            if (posHeadRaw != Vector3.zero && posAnkleRaw != Vector3.zero)
            {
                Vector2 posDepthHead = kinectManager.MapSpacePointToDepthCoords(posHeadRaw);
                ushort depthHead = kinectManager.GetDepthForPixel((int)posDepthHead.x, (int)posDepthHead.y);

                Vector2 posDepthAnkle = kinectManager.MapSpacePointToDepthCoords(posAnkleRaw);
                ushort depthAnkle = kinectManager.GetDepthForPixel((int)posDepthAnkle.x, (int)posDepthAnkle.y);

                Vector3 sizeHalfFace = new Vector3(bodyWidth / 2f, (posHeadRaw.y - posAnkleRaw.y) / 2, 0f);
                //Vector3 sizeHalfFace = new Vector3(bodyWidth / 2f, bodyHeight / 2f, 0f);
                Vector3 posFaceRaw1 = posHeadRaw - sizeHalfFace;
                Vector3 posFaceRaw2 = posHeadRaw + sizeHalfFace;

                Vector2 posDepthFace1 = kinectManager.MapSpacePointToDepthCoords(posFaceRaw1);
                Vector2 posDepthFace2 = kinectManager.MapSpacePointToDepthCoords(posFaceRaw2);

                if (posDepthFace1 != Vector2.zero && posDepthFace2 != Vector2.zero && depthHead > 0)
                {
                    Vector2 posColorFace1 = kinectManager.MapDepthPointToColorCoords(posDepthFace1, depthHead);
                    Vector2 posColorFace2 = kinectManager.MapDepthPointToColorCoords(posDepthFace2, depthHead);

                    if (!float.IsInfinity(posColorFace1.x) && !float.IsInfinity(posColorFace1.y) &&
                       !float.IsInfinity(posColorFace2.x) && !float.IsInfinity(posColorFace2.y))
                    {
                        BodyJointRect.x = posColorFace1.x;
                        BodyJointRect.y = posColorFace2.y;
                        BodyJointRect.width = Mathf.Abs(posColorFace2.x - posColorFace1.x);
                        BodyJointRect.height = Mathf.Abs(posColorFace2.y - posColorFace1.y);
                    }
                }
            }
        }

        return BodyJointRect;
    }

}
