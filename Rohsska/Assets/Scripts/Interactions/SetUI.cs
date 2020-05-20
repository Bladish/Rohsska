using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{
    public GameObject uiPanel;
    public GameObject bottomPanel;
    public GameObject cameraPanel;
    public GameObject picturePanel;

    public void SetUIActive()
    {
        cameraPanel.SetActive(false);
        bottomPanel.SetActive(false);
        picturePanel.SetActive(false);
        uiPanel.SetActive(true);
    }

    public void SetUIDeactive()
    {
        uiPanel.SetActive(false);
        cameraPanel.SetActive(false);
        picturePanel.SetActive(false);
        picturePanel.SetActive(false);
        bottomPanel.SetActive(true);
    }

    public void SetUICameraMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
        picturePanel.SetActive(false);
        cameraPanel.SetActive(true);
    }

    public void SetUIPhotoMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
        picturePanel.SetActive(false);
        cameraPanel.SetActive(false);
        Invoke("SetUICameraMode", 1f);
    }

    public void SetUIPictureMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
        cameraPanel.SetActive(false);
        picturePanel.SetActive(true);
    }
}
