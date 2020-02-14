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
            CheckImage();
        }

        public void CheckImage()
        {
            if(Image.Name == "Earth") SceneManager.LoadScene("Earth");
            if (Image.Name == "Cafe") SceneManager.LoadScene("Cafe");
            if (Image.Name == "Keyboard") SceneManager.LoadScene("Fish");
        }
    }

