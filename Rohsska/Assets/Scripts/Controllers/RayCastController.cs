using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

//RayCastController for Unity physics.
public class RayCastController : MonoBehaviour
{
    public GameObject testingObject;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public Material red;
    public Material black;


    void Update()
    {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            return;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                int layerMask = 1 << 8;
                if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
                {
                    if (hit.transform.name == "Button1") testingObject.GetComponent<MeshRenderer>().material = black;
                    if (hit.transform.name == "Button2") testingObject.GetComponent<MeshRenderer>().material = red;
                }
            }
        }
    }
}
