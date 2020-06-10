using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
[RequireComponent(typeof(ARTrackedImageManager))]

public class TrackedImage : MonoBehaviour
{
    [SerializeField]
    private GameObject placeablePrefab;
    private GameObject spawnedGameObject;
    private ARTrackedImageManager trackedImageManager;
    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;
    [SerializeField]
    private float offsetZ;
    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }

    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        if(trackedImage.referenceImage.name == "003" || trackedImage.referenceImage.name == "004")
        {
            if (spawnedGameObject != null)
            {
                Vector3 position = new Vector3(trackedImage.transform.position.x + offsetX, trackedImage.transform.position.y + offsetY, trackedImage.transform.position.z + offsetZ);
                spawnedGameObject.transform.position = position;
            }
            else
            {
                spawnedGameObject = Instantiate(placeablePrefab, trackedImage.transform);
            }
        }
    }
}
