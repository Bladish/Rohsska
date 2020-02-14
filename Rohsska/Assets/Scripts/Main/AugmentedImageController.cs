namespace GoogleARCore.Examples.AugmentedImage
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class AugmentedImageController : MonoBehaviour
    {
        public AugmentedImageSwapScene AugmentedImageVisualizerPrefab;
        public GameObject FitToScanOverlay;
        

        private Dictionary<int, AugmentedImageSwapScene> m_Visualizers = new Dictionary<int, AugmentedImageSwapScene>();

        private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();
        public void Awake()
        {
            Application.targetFrameRate = 60;
        }

        public void Update()
        {
            if(Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            Session.GetTrackables<AugmentedImage>(m_TempAugmentedImages, TrackableQueryFilter.Updated);

            foreach (var image in m_TempAugmentedImages)
            {
                AugmentedImageSwapScene visualizer = null;
                m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
                if(image.TrackingState == TrackingState.Tracking && visualizer == null)
                {
                    visualizer = (AugmentedImageSwapScene)Instantiate(AugmentedImageVisualizerPrefab);
                    visualizer.Image = image;
                    m_Visualizers.Add(image.DatabaseIndex, visualizer);
                }
                else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
                {
                    m_Visualizers.Remove(image.DatabaseIndex);
                    GameObject.Destroy(visualizer.gameObject);
                }
            }
            
            // Show the fit-to-scan overlay if there are no images that are Tracking.
            foreach (var visualizer in m_Visualizers.Values)
            {
                if (visualizer.Image.TrackingState == TrackingState.Tracking)
                {
                    FitToScanOverlay.SetActive(false);
                    return;
                }
            }

            FitToScanOverlay.SetActive(true);
            
        }

    }
}
