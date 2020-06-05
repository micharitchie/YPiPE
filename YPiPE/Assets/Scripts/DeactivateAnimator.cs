using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAnimator : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    public void setAnim(bool animActive)
    {
        anim.enabled = animActive;
    }

}
