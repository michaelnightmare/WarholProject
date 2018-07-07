using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{

    public static WebCamTexture webcamTexture;

	void Awake ()
    {

        webcamTexture = new WebCamTexture();

        webcamTexture.Play();
    }

    private void Update()
    {
        if(webcamTexture == null)
        {
            webcamTexture = new WebCamTexture();
            webcamTexture.Play();
        }

    }

    private void OnDisable()
    {
        webcamTexture.Stop();
    }

}
