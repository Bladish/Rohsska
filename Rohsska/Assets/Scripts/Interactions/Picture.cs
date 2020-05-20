using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    protected string PictureDirectory;
    protected string PlayerPrefsKey = "NiceKey";
    protected int numberOfPictures;
    protected string pictureName = "Picture";
    protected string pictureFileType = ".png";
    protected List<RawImage> ScreenShots = new List<RawImage>();
    [SerializeField]
    private RawImage showImage;
    private RawImage image;
    
    private void Awake()
    {
        PictureDirectory = Application.persistentDataPath;
    }
    
    private void Start()
    {
        numberOfPictures = PlayerPrefs.GetInt(PlayerPrefsKey);
        StartLoadPicture();
    }

    private void StartLoadPicture()
    {
        if (numberOfPictures == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i <= numberOfPictures; i++)
            {
                ScreenShots.Add(GetPicture(i));
            }
        }
    }

    public void PopPicture()
    {
        showImage = GetPicture(numberOfPictures);
    }

    private RawImage GetPicture(int i)
    {
        string url = (PictureDirectory + "/" +pictureName + i.ToString() + pictureFileType);
        var bytes = File.ReadAllBytes(url);
        Texture2D texture = new Texture2D(Screen.width, Screen.height);
        texture.LoadImage(bytes);
        image.texture = texture;
        return image;
    }

    public void AddImageToList()
    {
        ScreenShots.Add(GetPicture(numberOfPictures));
    }
}


