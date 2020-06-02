using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;
    public GameObject FitToScanOverlay;
    public static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        Application.targetFrameRate = 60;
        FitToScanOverlay.SetActive(true);
    }

    public void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            switch (trackedImage.referenceImage.name)
            {
                case "000":
                    SceneManager.LoadScene("Scroll");
                    FitToScanOverlay.SetActive(false);
                    break;
        
                case "001":
                    SceneManager.LoadScene("Colour");
                    FitToScanOverlay.SetActive(false);
                    break;
                case "002":
                    SceneManager.LoadScene("Fish");
                    FitToScanOverlay.SetActive(false);
                    break;
                case "003":
                    SceneManager.LoadScene("Tattoo");
                    FitToScanOverlay.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
