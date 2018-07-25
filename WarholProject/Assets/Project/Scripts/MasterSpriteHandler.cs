using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSpriteHandler : MonoBehaviour
{
    public GameObject quadView;
    public GameObject previewView;
    public GameObject shareView;
    public Image previewImage;

    public void ToggleToPreview()
    {
        quadView.SetActive(false);
        previewView.SetActive(true);
        shareView.SetActive(false);
    }

    public void ToggleToCapture()
    {
        quadView.SetActive(true);
        previewView.SetActive(false);
        shareView.SetActive(false);

    }

    public void ToggleToShare()
    {
        quadView.SetActive(false);
        previewView.SetActive(true);
        shareView.SetActive(true);

    }

}
