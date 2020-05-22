using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Picture : MonoBehaviour
{
    public string PictureDirectory { get; private set; }
    public string fileType { get; private set; } = ".png";
    private string[] files = null;
    [SerializeField]
    private Image showImage;
    public TMP_Text debugText;

    private void Awake()
    {
        PictureDirectory = Application.persistentDataPath;
    }
    
    public void GetPicture()
    {
        files = null;
        files = Directory.GetFiles(PictureDirectory + "/", "*" + fileType);
        string pathToFile = files[WhichScreenShotIsShown()];
        Texture2D texture = GetScreenShootImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width * 0.5f, texture.height * 0.5f));
        showImage.sprite = sp;
    }

    Texture2D GetScreenShootImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public int WhichScreenShotIsShown()
    {
        int lastestFile = files.Length - 1;
        return lastestFile;
    }
}


