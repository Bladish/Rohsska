using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerInteractions : MonoBehaviour
{
    public GameObject PlayUI;
    public GameObject MenuUI;
    public void PlayUIEnable()
    {
        MenuUI.SetActive(false);
        PlayUI.SetActive(true);
    }
    public void MenuUIEnable()
    {
        MenuUI.SetActive(true);
        PlayUI.SetActive(false);
    }
}
