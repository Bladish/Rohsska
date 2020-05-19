using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteObject : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    private PlaceObject placeObject;
    private bool deleteObjectAllowed = false;

    private void Start()
    {
        placeObject = GetComponent<PlaceObject>();
    }

    private void Update()
    {
        if (deleteObjectAllowed)
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
                        GameObject gameObject = hit.transform.gameObject;
                        placeObject.RemovePrefab(gameObject);
                    }   
                }
            }
        }
    }

    public void CanDeleteObject(bool acceptToDeleteObject)
    {
        deleteObjectAllowed = acceptToDeleteObject;
    }
}
