using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    
    public static Animator animator;
    public static bool runAnimation;

    private void Update()
    {
        if (runAnimation) 
        {
            animator.Play("ScrollUpDown");
        } 
    }
}
