using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

//RayCastController for Unity physics.
public class ColourController : MonoBehaviour
{
    public GameObject AnchorObject;
    //public GameObject backGroundObject;
    public GameObject startObject;
    public GameObject[] colours;
    public GameObject[] buttons;
    public new Camera camera;


    private void Awake()
    {
        foreach (var item in colours)
        {
            item.SetActive(false);
        }
        startObject.SetActive(true);
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
                RaycastHit hit;
                int layerMask = 1 << 8;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    string objectName = hit.transform.name;
                    switch (objectName)
                    {
                        case "Black":
                            startObject.SetActive(false);
                            colours[4].SetActive(false);
                            colours[3].SetActive(false);
                            colours[2].SetActive(false);
                            colours[1].SetActive(false);
                            colours[0].SetActive(true);
                            break;

                        case "Yellow":
                            startObject.SetActive(false);
                            colours[4].SetActive(false);
                            colours[3].SetActive(false);
                            colours[2].SetActive(false);
                            colours[0].SetActive(false);
                            colours[1].SetActive(true);
                            break;

                        case "Red":
                            startObject.SetActive(false);
                            colours[4].SetActive(false);
                            colours[3].SetActive(false);
                            colours[1].SetActive(false);
                            colours[0].SetActive(false);
                            colours[2].SetActive(true);
                            break;

                        case "White":
                            startObject.SetActive(false);
                            colours[4].SetActive(false);
                            colours[2].SetActive(false);
                            colours[1].SetActive(false);
                            colours[0].SetActive(false);
                            colours[3].SetActive(true);
                            break;

                        case "Green":
                            startObject.SetActive(false);
                            colours[3].SetActive(false);
                            colours[2].SetActive(false);
                            colours[1].SetActive(false);
                            colours[0].SetActive(false);
                            colours[4].SetActive(true);
                            break;



                        default:
 
                            colours[4].SetActive(false);
                            colours[3].SetActive(false);
                            colours[2].SetActive(false);
                            colours[1].SetActive(false);
                            colours[0].SetActive(false);
                            startObject.SetActive(true);
                            break;
                    }
                }
            }
        }
    }
}
