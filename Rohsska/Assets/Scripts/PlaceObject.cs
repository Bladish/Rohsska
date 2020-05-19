using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class PlaceObject : MonoBehaviour
{
    private ARRaycastManager ARRaycastManager;
    static List<GameObject> placedPrefabList = new List<GameObject>();
    private GameObject spawnedObject;

    [SerializeField]
    private int maxPrefabSpawnCount = 0;
    private int placedPrefabCount;
    
    [SerializeField]
    private GameObject placedPrefab;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    private void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
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

                if (ARRaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = s_Hits[0].pose;
                    if (placedPrefabCount < maxPrefabSpawnCount)
                    {
                        SpawnPrefab(hitPose);
                    }
                }
            }
        }
    }

    public void SetPrefabType(GameObject prefabType)
    {
        placedPrefab = prefabType;
    }

    private void SpawnPrefab(Pose hitPose)
    {
        spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        placedPrefabList.Add(spawnedObject);
        placedPrefabCount++;
    }
}

