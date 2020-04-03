using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class HouseCtrl : MonoBehaviour
{
    public Sprite openDoor;
    public Sprite closedDoor;
    public GameObject doorUI;
    //public Transform transportLoc;
    public Transform playerLoc;
    public Flowchart targetFlowchart;
    public string fugusBool;

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
            if (targetFlowchart != null) { 
                targetFlowchart.SetBooleanVariable(fugusBool, true);
            }
            Vector3 buttonLocation = new Vector3(playerLoc.position.x + 2.3f, playerLoc.position.y + 4.2f, playerLoc.position.z);
            doorUI.transform.position = buttonLocation;
            doorUI.SetActive(true);
            doorAudio.Stop();
            doorAudio.clip = Resources.Load<AudioClip>("DoorOpen");
            doorAudio.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 buttonLocation = new Vector3(playerLoc.position.x + 2.3f, playerLoc.position.y + 4.2f, playerLoc.position.z);
        doorUI.transform.position = buttonLocation;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            mySpriteRenderer.sprite = closedDoor;
            if (targetFlowchart != null)
            {
                targetFlowchart.SetBooleanVariable(fugusBool, false);
            }
            doorUI.SetActive(false);
            doorAudio.Stop();
            doorAudio.clip = Resources.Load<AudioClip>("DoorClose");
            doorAudio.Play();
        }
    }

    /*public void goInside()
    {
        playerLoc.position = transportLoc.position;
    }*/

    public void changeFlowchart(Flowchart newFlow)
    {
        targetFlowchart = newFlow;
    }
}
