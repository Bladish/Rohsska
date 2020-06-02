using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
[RequireComponent(typeof(ARTrackedImageManager))]
// Prefab name needs to bee the same as the trackedImage name
public class TrackedImage : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (var prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
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
        
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            StartCoroutine(DeactivatePrefab(trackedImage.name));
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        if(prefab.name == "003")
        {
            prefab.GetComponentInChildren<Animator>().SetBool("FishJump", true);
        }
        prefab.SetActive(true);

        foreach (GameObject item in spawnedPrefabs.Values)
        {
            if(item.name != name)
            {
                item.SetActive(false);
                prefab.GetComponentInChildren<Animator>().SetBool("FishJump", false);
            }
        }
    }

    IEnumerator DeactivatePrefab(string key)
    {
        yield return new WaitForSeconds(3f);
        if(key == "003") spawnedPrefabs[key].GetComponentInChildren<Animator>().SetBool("FishJump", false);
        spawnedPrefabs[key].SetActive(false);
    }
}
