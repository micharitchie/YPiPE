using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFader : MonoBehaviour
{

	public string animState;
	private Animator doorAnimator;

	void Start()
	{
		doorAnimator = GetComponent<Animator>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		doorAnimator.SetFloat("Direction", 1);
		doorAnimator.Play(animState);
	}

	

	private void OnTriggerExit2D(Collider2D collision)
	{
		doorAnimator.SetFloat("Direction", -1);
		doorAnimator.Play(animState);
	}

	public void StopAnimationSpeed()
	{
		doorAnimator.SetFloat("Direction", 0);

	}
}
