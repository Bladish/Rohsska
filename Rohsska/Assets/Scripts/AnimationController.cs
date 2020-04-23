using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public new Animation animation;
    public Animator animator;

    public void PlayAnimation ()
    {
        animator.Play("ScrollUpDown");
    }
}
