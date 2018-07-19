using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenShot : MonoBehaviour
{

    [SerializeField]

    public void TakePicture()
    {
       Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        transform.root.GetComponent<MasterSpriteHandler>().screenGrab = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        transform.root.GetComponent<MasterSpriteHandler>().ToggleToPreview();
           
    }



    //public void TakeShot()
    //{
    //    StartCoroutine("Capture");
    //}
    
    //IEnumerator Capture()
    //{
    //    string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
    //    string fileName = "Screenshot" + timeStamp + ".png";
    //    string pathToSave = fileName;
      
    //    ScreenCapture.CaptureScreenshot(pathToSave);
    //    yield return new WaitForEndOfFrame();
        
    //}


}
