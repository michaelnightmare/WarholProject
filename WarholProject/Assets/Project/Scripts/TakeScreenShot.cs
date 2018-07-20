using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TakeScreenShot : MonoBehaviour
{

    [SerializeField]

    


    public void TakePicture()
    {
       Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        Rect rex = new Rect(40, 175, 300, 400);
        //Debug.LogError("here");

        transform.root.GetComponent<MasterSpriteHandler>().screenGrab = Sprite.Create(tex, rex, new Vector2(0f, 0f), 100.0f);
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
