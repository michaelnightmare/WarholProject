using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenShotPreview : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    //Sprite defaultImage;
    public string[] files = null;
    int whichScreenShotIsShown = 0;
    string folderPath = "C:/Users/Cameron Horst/Pictures/";
    
  
    void Start()
    { 
    }


    public void GetPictureAndShowIt()
    {
        Image i = GetComponent<Image>();

        Texture2D texture = GetScreenshotImage("C:/Users/Cameron Horst/Pictures/Screenshot.png");
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GetComponent<Image> ().sprite = sp;
    }

    Texture2D GetScreenshotImage(string filePath)
    {
        Debug.Log("Trying to load");
        Texture2D texture = null;
        byte[] fileBytes;
        if(File.Exists (filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        if (texture != null) Debug.Log("Loaded Texture");
        return texture;
    }

}
