using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAPicture : MonoBehaviour
{
    private Picture picture;
    private string pictureName = "Picture";
    private void Start()
    {
        picture = GetComponent<Picture>();
    }
    public void ScreenShot()
    {
        string timpStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = pictureName + timpStamp + picture.fileType;
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
    }
    
    public void TakeScreenShot()
    {
        Invoke("ScreenShot", 0.1f);
    }
}
