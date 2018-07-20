using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSpriteHandler : MonoBehaviour
{
    public Sprite screenGrab;
    public GameObject quadView;
    public GameObject previewView;
    public Image previewImage;

    public void ToggleToPreview()
    {
        quadView.SetActive(false);
        previewView.SetActive(true);
        if(screenGrab!=null)
        {
            previewImage.sprite = screenGrab;
        }
    }

    public void ToggleToCapture()
    {
        quadView.SetActive(true);
        previewView.SetActive(false);
      
    }

}
