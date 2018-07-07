using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WebCamDisplay : MonoBehaviour
{

    Material mat;

    public ColorScheme colorScheme;


	// Use this for initialization
	void Start ()
    {
        if(colorScheme == null)
        {
            Debug.LogError("Assign color scheme to " + gameObject.name + "!!!");
            return;
        }

        Renderer r = GetComponent<Renderer>();
        mat = r.material;
        mat.SetTexture("_WebcamTexture", WebCam.webcamTexture);
        mat.SetColor("_Color0", colorScheme.col1);
        mat.SetColor("_Color1", colorScheme.col2);
        mat.SetColor("_Color2", colorScheme.col3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
