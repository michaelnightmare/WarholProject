using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TakeScreenShot : MonoBehaviour
{

    [SerializeField]

    public Text countnum;
    public Image flash;
    public float flashA = 1;
    public Button TakePhotoB;
    public Image TakePhotoBArt;
    public ScreenShotPreview previewimage;





    void Start()
    {
        countnum.gameObject.SetActive(false);
        TakePhotoB.enabled = true;
        TakePhotoBArt.enabled = true;
        
    }

    public void startCountdown()
    {
        countnum.gameObject.SetActive(true);
        TakePhotoB.enabled = false;
        TakePhotoBArt.enabled = false;
     
        StartCoroutine(countingDown());
    }

    IEnumerator countingDown()
    {
        
        for (int i= 4; i >= 0;i--)
        {
            countnum.text = (i + 1).ToString();
        yield return new WaitForSeconds(1);
        }

        countnum.gameObject.SetActive(false);
        flash.enabled = true;
        
        float t = 0f;
        while(t <.15f)
        {
            t += Time.deltaTime;
            float AlphaC= Mathf.Lerp(0,flashA,t/.15f);
            flash.color = new Color(1, 1, 1, AlphaC);
            yield return null; 
        }
      
        flash.enabled = false;
       
        yield return null;
        TakePicture();
        yield break;
    }


    //public void TakePicture()
    //{

    //    Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();

    //    Rect rex = new Rect(40, 175, 300, 400);
    //    //Debug.LogError("here");

    //    transform.root.GetComponent<MasterSpriteHandler>().screenGrab = Sprite.Create(tex, rex, new Vector2(0.5f, 0.5f), 100.0f);


    //    transform.root.GetComponent<MasterSpriteHandler>().ToggleToPreview();
    //    TakePhotoB.enabled = true;
    //    TakePhotoBArt.enabled = true;



    //}



    public void TakePicture()
    {
        StartCoroutine("Capture");
    }

    IEnumerator Capture()
    {


        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;

        ScreenCapture.CaptureScreenshot(pathToSave);

        yield return new WaitForEndOfFrame();

        transform.root.GetComponent<MasterSpriteHandler>().ToggleToPreview();

        TakePhotoB.enabled = true;
        TakePhotoBArt.enabled = true;

    }


}
