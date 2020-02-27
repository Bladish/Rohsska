using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using TMPro;

[RequireComponent(typeof(ReferencePoint))]
[RequireComponent(typeof(XRReferencePointSubsystem))]
public class AnchorController : MonoBehaviour
{
    private XRReferencePointSubsystem _arXRReferencePointSubsystem;
    public GameObject gamePrefab;
    public Pose pose;
    public TrackableId trackId;
    public TMP_Text debugtext;

    void Awake()
    {
        Application.targetFrameRate = 60;
        _arXRReferencePointSubsystem = GetComponent<XRReferencePointSubsystem>();
        _arXRReferencePointSubsystem.TryAddReferencePoint(pose, out trackId);
    }

    private void Update()
    {
        CreatAnchor();
    }
    public void CreatAnchor()
    {
        _arXRReferencePointSubsystem.TryGetReferencePoint(trackId, out ReferencePoint referencePoint);
        if (referencePoint.TrackingState == TrackingState.Tracking)
        {
            debugtext.text = gamePrefab.transform.position.ToString();
            gamePrefab.transform.position = referencePoint.Pose.position;
        }
    }
}
