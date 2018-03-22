using UnityEngine;
using System.Collections;
using System.IO;

//KinectGestures.GestureListenerInterface
public class PhotoBoothController : MonoBehaviour, InteractionListenerInterface
{

	[Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
	public int playerIndex = 0;

	private int maskCount = 0;
	private int currentIndex = -1;
	private int prevIndex = -1;

    public GameObject userInfo;


	void Start () 
	{

	}
	
	void Update () 
	{
	}

	public void UserLost(long userId, int userIndex)
	{
		if(userIndex != playerIndex)
			return;

		currentIndex = -1;
	}
	// InteractionListenerInterface
	public void HandGripDetected(long userId, int userIndex, bool isRightHand, bool isHandInteracting, Vector3 handScreenPos)
	{
		if (userIndex != playerIndex)
			return;

		if (isRightHand && handScreenPos.y >= 0.5f) 
		{

			PhotoShooter photoShooter = gameObject.GetComponent<PhotoShooter>();

            Debug.Log(userInfo.GetComponent<UserInfo>().photoPath);
			if (photoShooter && photoShooter.enabled && userInfo.GetComponent<UserInfo>().photoPath == "") 
			{
				photoShooter.CountdownAndMakePhoto();
                userInfo.GetComponent<UserInfo>().photoPath = "photo";
			}
		}
	}

	public void HandReleaseDetected(long userId, int userIndex, bool isRightHand, bool isHandInteracting, Vector3 handScreenPos)
	{
		if (userIndex != playerIndex)
			return;

	}

	public bool HandClickDetected(long userId, int userIndex, bool isRightHand, Vector3 handScreenPos)
	{
		if (userIndex != playerIndex)
			return false;

		return true;
	}

}
