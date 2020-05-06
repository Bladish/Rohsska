using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAnimationController : MonoBehaviour
{
    Animator fishAnimator;
    [SerializeField]
    ParticleSystem waterSplash;
    bool canRunAnimation = true;
    int startChance = 50;
    void Start()
    {
        fishAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (canRunAnimation)
        {
            fishAnimator.Play("NewFishJump");
            canRunAnimation = false;
        }
    }
    public void SplashParticles()
    {
        waterSplash.Play();
        canRunAnimation = true;
    }
}