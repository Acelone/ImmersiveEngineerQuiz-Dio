using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIScript : MonoBehaviour
{
    public GameObject UI,PreviewUI;
    public Image PreviewImage; 
    public string ShareMessage;
    private string myFileName,myScreenshotLocation;

    void Update()
    {
        if(UI.activeSelf == true){
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        }
        else if(PreviewUI.activeSelf == true){
        if(Input.GetKey(KeyCode.Escape))
        {
            UI.SetActive(true);
            PreviewUI.SetActive(false);
        }
        }
    }
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
      myFileName = "Screenshot" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".png";
      string myDefaultLocation = Application.persistentDataPath + "/" + myFileName;
      string myFolderLocation = "/storage/emulated/0/DCIM/ArutalaLogo/";
      myScreenshotLocation = myFolderLocation + myFileName;
 
      if (!System.IO.Directory.Exists(myFolderLocation))
      {
          System.IO.Directory.CreateDirectory(myFolderLocation);
      }
      
      ScreenCapture.CaptureScreenshot(myFileName);
      var texture = ScreenCapture.CaptureScreenshotAsTexture();
      yield return new WaitForSeconds(3);
      PreviewUI.SetActive(true);
      Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
      PreviewImage.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width*0.7f, texture.height*0.7f);
      PreviewImage.GetComponent<Image>().sprite = sp;
    }
    private IEnumerator ShareImage(string title, string destination)
    {
       yield return new WaitForEndOfFrame();
        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "content://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("setType", "image/png");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share Image");
            currentActivity.Call("startActivity", chooser);
            yield return new WaitForSeconds(1);
        }
    }
    public void TakeScreenshot()
    {
        UI.SetActive(false);
        StartCoroutine(Screenshot());
    }
    public void Share()
    {
        StartCoroutine(ShareImage(myFileName,myScreenshotLocation));

    }
}
