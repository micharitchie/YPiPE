using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodInteraction : MonoBehaviour
{
    public GameObject doorUI;
    //public GameObject doorIndicator;

    private Animator doorAnimator;
    //private Animation doorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        //doorAnimation = GetComponent<Animation>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorAnimator.SetFloat("Direction", 1);
        doorAnimator.Play("DoorOpen");
        doorUI.transform.position = transform.position;
        doorUI.SetActive(true);
        //doorIndicator.SetActive(true);
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        doorAnimator.SetFloat("Direction", -1);
        doorAnimator.Play("DoorOpen");
        doorUI.SetActive(false);
        //doorIndicator.SetActive(true);
        //Debug.Log(doorAnimator.GetCurrentAnimatorStateInfo(0).speed);
    }
     
   public void StopAnimationSpeed()
    {
        doorAnimator.SetFloat("Direction", 0);

    }
}
