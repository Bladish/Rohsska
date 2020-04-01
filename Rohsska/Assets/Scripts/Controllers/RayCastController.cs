using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

//RayCastController for Unity physics.
public class RayCastController : MonoBehaviour
{
    public GameObject orignalObject;
    public GameObject sweObject;
    public GameObject engObject;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public new Camera camera;

    public AnimationController animationController;  // patrik added for anim test


    private void Start()
    {
        sweObject.SetActive(false);
        engObject.SetActive(false);
    }
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
                Ray ray = camera.ScreenPointToRay(Input.GetTouch(i).position);
                int layerMask = 1 << 8;
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
                {
                    string hitName = hit.transform.name;
                    switch (hitName)
                    {
                        case "Button1":
                            animationController.PlayAnimation(); // patrik added for anim test
                            orignalObject.SetActive(true);
                            engObject.SetActive(false);
                            sweObject.SetActive(false);
                            break;

                        case "Button2":
                            orignalObject.SetActive(false);
                            engObject.SetActive(false);
                            sweObject.SetActive(true);
                            break;

                        case "Button3":
                            orignalObject.SetActive(false);
                            engObject.SetActive(true);
                            sweObject.SetActive(false);
                            break;

                        default:
                            orignalObject.SetActive(false);
                            engObject.SetActive(false);
                            sweObject.SetActive(true);
                            break;
                    }
                }
            }
        }
    }
}
