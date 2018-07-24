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
    string folderPath = "C:/Users/Michael/Documents/GitHub/WarholProject/WarholProject";
    
  
    void Start()
    {
        //canvas.GetComponent<Image>().sprite = defaultImage;
        files = Directory.GetFiles(folderPath + "/", "*.png");
     
        if(files.Length > 0)
        {
         
            GetPictureAndShowIt();
        }
        if (files.Length > 1)
        {

            DeleteImage();
        }
    }


    public void GetPictureAndShowIt()
    {
      
        string pathToFile = files[whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    
        GetComponent<Image> ().sprite = sp;
        transform.root.GetComponent<MasterSpriteHandler>().screenGrab = sp;


    }

    Texture2D GetScreenshotImage(string filePath)
    {

        Texture2D texture = null;
        byte[] fileBytes;
        if(File.Exists (filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public void DeleteImage()
    {
        if (files.Length > 0)
        {
            string pathToFile = files[whichScreenShotIsShown];
            if (File.Exists(pathToFile))
                File.Delete(pathToFile);
            files = Directory.GetFiles(folderPath + "/", "*.png");
        }
    }


}
