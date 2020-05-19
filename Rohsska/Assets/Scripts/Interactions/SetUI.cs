using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUI : MonoBehaviour
{
    public GameObject uiPanel;

    public void SetUIActive()
    {
        uiPanel.SetActive(true);
    }

    public void SetUIDeactive()
    {
        uiPanel.SetActive(false);
    }
}
