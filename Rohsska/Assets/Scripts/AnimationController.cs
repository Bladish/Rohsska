using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public new Animation animation;
    public Text text;

    public void PlayAnimation ()
    {
        text.text = "Triggered";
        animation.Play("ScrollUpDown");
    }
}
