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
    Sprite defaultImage;
    public string[] files = null;
    int whichScreenShotIsShown = 0;
    string folderPath = "C:/Users/Michael/Documents/GitHub/WarholProject/WarholProject";

    void Start()
    {
        canvas.GetComponent<Image>().sprite = defaultImage;
        files = Directory.GetFiles(folderPath + "/", "*.png");
        Debug.Log(Application.persistentDataPath);
        if(files.Length > 0)
        {
            Debug.Log("here2");
            GetPictureAndShowIt();
        }
    }
    

    void GetPictureAndShowIt()
    {
        string pathToFile = files [whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        Debug.Log(sp);
        canvas.GetComponent<Image> ().sprite = sp;
        
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
    

}
