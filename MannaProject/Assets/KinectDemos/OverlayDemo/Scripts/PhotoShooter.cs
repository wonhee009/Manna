using System.Collections;
using System.IO;
using UnityEngine;

using UnityEngine.UI;


public class PhotoShooter : MonoBehaviour
{
	[Tooltip("Camera used to render the background.")]
	public Camera backroundCamera;

	[Tooltip("Camera used to render the background layer-2.")]
	public Camera backroundCamera2;

	[Tooltip("Camera used to overlay the 3D-objects over the background.")]
	public Camera foreroundCamera;

	[Tooltip("Array of sprite transforms that will be used for displaying the countdown until image shot.")]
	public Transform[] countdown;

	[Tooltip("UI-Text used to display information messages.")]
	public UnityEngine.UI.Text infoText;

    public GameObject userInfo;
    public GameObject Photo;
    public GameObject userImage;
    public GameObject circle;
    public GameObject imagecon;


	/// <summary>
	/// Counts down (from 3 for instance), then takes a picture and opens it
	/// </summary>
	public void CountdownAndMakePhoto()
	{
		StartCoroutine(CoCountdownAndMakePhoto());
	}


	// counts down (from 3 for instance), then takes a picture and opens it
	private IEnumerator CoCountdownAndMakePhoto()
	{
		if (countdown != null && countdown.Length > 0) 
		{
			for(int i = 0; i < countdown.Length; i++)
			{
				if (countdown [i])
					countdown [i].gameObject.SetActive(true);
				
				yield return new WaitForSeconds(1.0f);

				if (countdown [i])
					countdown [i].gameObject.SetActive(false);
			}
		}

		MakePhoto();
		yield return null;
	}


	/// <summary>
	/// Saves the screen image as png picture, and then opens the saved file.
	/// </summary>
	public void MakePhoto()
	{
		MakePhoto(true);
	}

	/// <summary>
	/// Saves the screen image as png picture, and optionally opens the saved file.
	/// </summary>
	/// <returns>The file name.</returns>
	/// <param name="openIt">If set to <c>true</c> opens the saved file.</param>
	public string MakePhoto(bool openIt)
	{
        this.GetComponent<AudioSource>().enabled = true;

		int resWidth = Screen.width;
		int resHeight = Screen.height;

        int photoWidth = (int) (resWidth * 0.32f);
        int photoHeight = (int) (resHeight * 0.6f);

        int leftWhite = (int) (resWidth * 0.34f);
        int upWhite = (int) (resHeight * 0.17f);

		Texture2D screenShot = new Texture2D(photoWidth, photoHeight, TextureFormat.RGB24, false); //Create new texture
		RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);

		// hide the info-text, if any
		if (infoText) 
		{
			infoText.text = string.Empty;
		}

		// render background and foreground cameras
		if (backroundCamera && backroundCamera.enabled) 
		{
			backroundCamera.targetTexture = rt;
			backroundCamera.Render();
			backroundCamera.targetTexture = null;
		}

		if (backroundCamera2 && backroundCamera2.enabled) 
		{
			backroundCamera2.targetTexture = rt;
			backroundCamera2.Render();
			backroundCamera2.targetTexture = null;
		}

		if (foreroundCamera && foreroundCamera.enabled) 
		{
			foreroundCamera.targetTexture = rt;
			foreroundCamera.Render();
			foreroundCamera.targetTexture = null;
		}

		// get the screenshot
		RenderTexture prevActiveTex = RenderTexture.active;
		RenderTexture.active = rt;

		screenShot.ReadPixels(new Rect(leftWhite, upWhite, photoWidth, photoHeight), 0, 0);

		// clean-up
		RenderTexture.active = prevActiveTex;
		Destroy(rt);

		byte[] btScreenShot = screenShot.EncodeToJPG();
		Destroy(screenShot);

#if !UNITY_WSA
        // save the screenshot as jpeg file
        string sDirName = Application.persistentDataPath + "/Screenshots";
        //string sDirName = Application.dataPath + "/Resources";
        if (!Directory.Exists(sDirName))
			Directory.CreateDirectory (sDirName);

        //string name = string.Format("{0:F0}", Time.realtimeSinceStartup * 10f);


        string sFileName = sDirName + "/" + string.Format ("{0:F0}", Time.realtimeSinceStartup * 10f) + ".jpg";

        //string sFileName = sDirName + "/" + name + ".jpg";

        File.WriteAllBytes(sFileName, btScreenShot);

		Debug.Log("Photo saved to: " + sFileName);
		if (infoText) 
		{
			infoText.text = "Saved to: " + sFileName;
		}

        // open file
        /*
		if(openIt)
		{
			System.Diagnostics.Process.Start(sFileName);
		}
        */

        //////////////////////////////////////////////////////////////////////////
        userInfo.GetComponent<UserInfo>().photoPath = sFileName;
        Photo.SetActiveRecursively(true);
        Photo.GetComponent<photoControll>().dead = false;
        userImage.SetActiveRecursively(false);
        circle.SetActiveRecursively(false);
        imagecon.GetComponent<testMove>().enabled = false;

        return sFileName;
#elif NETFX_CORE
        System.Threading.Tasks.Task<string> task = null;

        string sFileName = string.Format("{0:F0}", Time.realtimeSinceStartup * 10f) + ".jpg";
        string sFileUrl = string.Empty; // "ms-appdata:///local/" + sFileName;

		UnityEngine.WSA.Application.InvokeOnUIThread(() =>
		{
        	task = SaveImageFileAsync(sFileName, btScreenShot, openIt);
		}, true);

        while (task != null && !task.IsCompleted && !task.IsFaulted)
        {
            task.Wait(100);
        }

        if (task != null)
        {
            if (task == null)
                throw new Exception("Could not create task for SaveImageFileAsync()");
            else if (task.IsFaulted)
                throw task.Exception;

            sFileUrl = task.Result;
            Debug.Log(sFileUrl);
        }

        return sFileUrl;
#else
		return string.Empty;
#endif
	}

#if NETFX_CORE
    private async System.Threading.Tasks.Task<string> SaveImageFileAsync(string imageFileName, byte[] btImageContent, bool openIt)
    {
        Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        Windows.Storage.StorageFile imageFile = await storageFolder.CreateFileAsync(imageFileName,
            Windows.Storage.CreationCollisionOption.ReplaceExisting);

        await Windows.Storage.FileIO.WriteBytesAsync(imageFile, btImageContent);

        if(openIt)
        {
            await Windows.System.Launcher.LaunchFileAsync(imageFile);
        }

        return imageFile.Path;
    }
#endif

}

