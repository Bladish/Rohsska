using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject information;


    public void SetUIInformation ()
    {
        if (information.activeInHierarchy == false)
        {
            information.SetActive(true);
        }
        else 
        {
            information.SetActive(false);
        }
    }


}
