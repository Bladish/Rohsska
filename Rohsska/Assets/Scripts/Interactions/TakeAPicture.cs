using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAPicture : Picture
{
    public void ScreenShot()
    {
        numberOfPictures++;
        string picture = "/" + pictureName + numberOfPictures;
        ScreenCapture.CaptureScreenshot(PictureDirectory + picture, 4);
        PlayerPrefs.SetInt(PlayerPrefsKey, numberOfPictures);
        AddImageToList();
    }
    
    public void TakeScreenShot()
    {
        Invoke("ScreenShot", 0.1f);
    }
}
