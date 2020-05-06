using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ParticleAddToObjects : MonoBehaviour
{
    private ARRaycastManager m_ARRaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    public GameObject m_PlacedPrefab;
    private GameObject spawnedObject;


    private void Start()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        
        touchPosition = default;
        return false;
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
                if (!TryGetTouchPosition(out Vector2 touchPosition)) return;

                if (m_ARRaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = s_Hits[0].pose;

                    if (spawnedObject == null)
                    {
                        spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        spawnedObject.transform.position = hitPose.position;
                    }
                }
            }
        }
    }
}
