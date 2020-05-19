using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveOjbect : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;
    public static bool AllowToMoveObject { get; private set; }
    private PlaceObject placeObject;
    void Start()
    {
        placeObject = GetComponent<PlaceObject>();
    }

    void Update()
    {
        if (AllowToMoveObject)
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
                        placeObject.SetMovingPrefab(gameObject);
                    }
                }
            }
        }
    }

    public void CanMoveObject(bool moveObject) 
    {
        AllowToMoveObject = moveObject;
    }
}
