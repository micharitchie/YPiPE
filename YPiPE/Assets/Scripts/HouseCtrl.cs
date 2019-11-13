using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCtrl : MonoBehaviour
{
    public Sprite openDoor;
    public Sprite closedDoor;
    public GameObject doorUI;
    public Transform transportLoc;
    public Transform playerLoc;

    private SpriteRenderer mySpriteRenderer;
    private AudioSource doorAudio;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        doorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            mySpriteRenderer.sprite = openDoor;
            //Debug.Log(transportLoc.position);
            //playerLoc.position = transportLoc.position;
            doorUI.SetActive(true);
            doorAudio.Stop();
            doorAudio.clip = Resources.Load<AudioClip>("DoorOpen");
            doorAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            mySpriteRenderer.sprite = closedDoor;
            doorUI.SetActive(false);
            doorAudio.Stop();
            doorAudio.clip = Resources.Load<AudioClip>("DoorClose");
            doorAudio.Play();
        }
    }

    public void goInside()
    {
        playerLoc.position = transportLoc.position;
    }
}
