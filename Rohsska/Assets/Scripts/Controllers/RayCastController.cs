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

    public AnimationController animationController; 

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
                            if (!animationController.animation.isPlaying)
                            {
                                animationController.PlayAnimation();
                                StartCoroutine(TextDelay(engObject, sweObject, orignalObject));
                            }
                            break;

                        case "Button2":
                            if (!animationController.animation.isPlaying)
                            {
                                animationController.PlayAnimation();
                                StartCoroutine(TextDelay(engObject, orignalObject, sweObject));
                            }
                            break;

                        case "Button3":
                            if (!animationController.animation.isPlaying)
                            {
                                animationController.PlayAnimation();
                                StartCoroutine(TextDelay(sweObject, orignalObject, engObject));
                            }
                            break;

                        default:
                            if (!animationController.animation.isPlaying)
                            {
                                engObject.SetActive(false);
                                sweObject.SetActive(false);
                                animationController.PlayAnimation();
                                orignalObject.SetActive(true);
                            }
                            break;
                    }
                }
            }
        }
    }
    IEnumerator TextDelay(GameObject firstGameObject, GameObject secondGameObject, GameObject enableGameObject)
    {
        yield return new WaitForSeconds(1f);
        firstGameObject.SetActive(false);
        secondGameObject.SetActive(false);
        enableGameObject.SetActive(true);
    }
}
