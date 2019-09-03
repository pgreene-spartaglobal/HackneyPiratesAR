using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour 
{
    private bool camAvailable;
    private WebCamTexture frontCam;
    private Texture defaultBackground;

    [SerializeField] RawImage background;
    [SerializeField] AspectRatioFitter fit;
	
    [SerializeField] private Text persistentDataPathText;
    [SerializeField] private Text saveText;
    [SerializeField] private GameObject[] objectsToHide;

	private void Start() 
    {
        persistentDataPathText.text = Application.persistentDataPath + "/PiratePhoto.png";

        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            print("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (frontCam == null)
        {
            print("No front facing camera detected");
            return;
        }

        frontCam.Play();
        background.texture = frontCam;

        camAvailable = true;
	}
		
	private void Update() 
    {
        if (!camAvailable)
        {
            return;
        }

        float ratio = (float)frontCam.width / (float)frontCam.height;
        fit.aspectRatio = ratio;

        float scaleY;

        if (frontCam.videoVerticallyMirrored)
        {
            scaleY = -1f;
        }
        else
        {
            scaleY = 1f;
        }

        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -frontCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}

    public void TakeScreenshot()
    {
        StartCoroutine("DisableUI");
    }

    IEnumerator DisableUI()
    {
        SetUIActive(false);
        yield return new WaitForSeconds(0.1f);
        ScreenCapture.CaptureScreenshot("PiratePhoto.png");
        yield return new WaitForSeconds(1f);
        SetUIActive(true);
        StartCoroutine("ScreenshotEffect");
    }

    IEnumerator ScreenshotEffect()
    {
        saveText.enabled = true;
        yield return new WaitForSeconds(1f);
        saveText.enabled = false;
        yield return null;
    }

    private void SetUIActive(bool value)
    {
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(value);
        }
    }
}
