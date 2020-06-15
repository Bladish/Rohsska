using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{
    public GameObject uiPanel;
    public GameObject bottomPanel;

    public void SetUIActive()
    {
        bottomPanel.SetActive(false);
        uiPanel.SetActive(true);
    }

    public void SetUIDeactive()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(true);
    }

    public void SetUICameraMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
    }

    public void SetUIPhotoMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
        Invoke("SetUICameraMode", 1f);
    }

    public void SetUIPictureMode()
    {
        uiPanel.SetActive(false);
        bottomPanel.SetActive(false);
    }
}
