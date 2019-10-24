using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoryAnimStates : MonoBehaviour
{
	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
	}

    public void StopLook()
	{
		anim.SetBool("RoryLook", false);
	}
    
}
