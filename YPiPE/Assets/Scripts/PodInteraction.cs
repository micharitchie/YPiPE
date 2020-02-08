using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodInteraction : MonoBehaviour
{
    public GameObject doorUI;
    public Transform setLocation;

    private Animator doorAnimator;
    private AudioSource doorSound;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorAnimator.SetFloat("Direction", 1);
        doorAnimator.Play("DoorOpen");
        Vector3 buttonLocation = new Vector3(setLocation.position.x + 2.3f, setLocation.position.y + 4.2f, setLocation.position.z);
        doorUI.transform.position = buttonLocation;
        doorUI.SetActive(true);
        doorSound.Stop();
        doorSound.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 buttonLocation = new Vector3(setLocation.position.x + 2.3f, setLocation.position.y + 4.2f, setLocation.position.z);
        doorUI.transform.position = buttonLocation;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorAnimator.SetFloat("Direction", -1);
        doorAnimator.Play("DoorOpen");
        doorUI.SetActive(false);
        doorSound.Stop();
        doorSound.Play();
    }
     
   public void StopAnimationSpeed()
    {
        doorAnimator.SetFloat("Direction", 0);

    }
}
