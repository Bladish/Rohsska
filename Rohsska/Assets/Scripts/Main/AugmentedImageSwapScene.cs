namespace AugmentedImageSwapScene
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using UnityEngine.SceneManagement;



    public class AugmentedImageSwapScene : MonoBehaviour
    {
        public AugmentedImage Image;

        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking) return;

            SceneManager.LoadScene("StartMenu");
        }
    }
}
