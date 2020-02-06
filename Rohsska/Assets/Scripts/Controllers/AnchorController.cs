using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class AnchorController : MonoBehaviour
{
    private Anchor anchor;
    public Pose pose;
    public GameObject anchorPrefab;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        anchor = Session.CreateAnchor(pose , null);
        anchorPrefab = Instantiate(anchorPrefab, anchor.transform.position, anchor.transform.rotation);
    }
}
