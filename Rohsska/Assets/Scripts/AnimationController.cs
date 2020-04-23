using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public  Animator animator;

    IEnumerator PlayAnimation ()
    {
        animator.SetTrigger("UpDown");
        yield return new WaitForSeconds(0.2f);
    }

}
