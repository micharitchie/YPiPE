using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;
using Fungus;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static int[] partLocations = { 0, 1, 2, 3, 4, 5 };

    public GameObject[] dropTargets;//stores the droppable locations
    public int startTarget;//stores which drop target body part starts on
    public int partDirection;//0=up, 1=right, 2=down, 3=left
    //public Flowchart flowOutput;//stores a reference to the Fungus flowchart
    //public string fungusVariable;//targets flowchart variable to store body part location
    public int partLocationRef;

    private GameObject itemBeingDragged;//temporarily stores object being dragged
    private Vector3 startPos;//stores body part starting location, updates with each drag
    private GameObject swapRef;//temporarily stores object being replaced at a drop target
    private Droppable[] dropScripts;//provides access to drop target variables 
    private Draggable[] otherParts;//provides access to variables on other body parts
    //private RoryPartSwap RPSScript;//was storing a reference to player, but no longer accessing those methods from this script


    // Start is called before the first frame update
    void Awake()
    {
        dropScripts = new Droppable[dropTargets.Length];
        otherParts = new Draggable[dropTargets.Length];
        for(int i = 0; i < dropTargets.Length; i++)
        {
            dropScripts[i] = dropTargets[i].GetComponent<Droppable>();
            otherParts[i] = dropScripts[i].dropContents.GetComponent<Draggable>();
        }
        startPos = transform.position;
        //RPSScript = GameObject.Find("VirtualRory").GetComponent<RoryPartSwap>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPos = transform.position;
        itemBeingDragged.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        for(int i = 0; i < dropTargets.Length; i++)
        {
            float distance = Vector3.Distance(itemBeingDragged.transform.position, dropTargets[i].transform.position);
            GameObject glow = dropTargets[i].transform.GetChild(0).gameObject;
            if (distance < 100)
            {
                glow.SetActive(true);
            } else
            {
                glow.SetActive(false);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for(int i = 0; i < dropTargets.Length; i++)
        {
            float distance = Vector3.Distance(itemBeingDragged.transform.position, dropTargets[i].transform.position);
            GameObject glow = dropTargets[i].transform.GetChild(0).gameObject;
            if (distance < 100)
            {
                glow.SetActive(false);
                otherParts[i] = dropScripts[i].dropContents.GetComponent<Draggable>();
                dropScripts[i].dropContents.transform.position = startPos;
                otherParts[i].startTarget = startTarget;
                otherParts[i].rotateBodyParts();
                swapRef = dropScripts[i].dropContents;
                dropScripts[i].dropContents = itemBeingDragged;
                startPos = dropTargets[i].transform.position;
                dropScripts[startTarget].dropContents = swapRef;
                startTarget = i;
            }
        }
        transform.position = startPos;
        itemBeingDragged = null;
        swapRef = null;
        rotateBodyParts();
        
    }

    public void pullPartLoc()
    {
        startTarget = partLocations[partLocationRef];
        //startTarget = flowOutput.GetIntegerVariable(fungusVariable);
        startPos = dropTargets[startTarget].transform.position;
        transform.position = startPos;
        dropScripts[startTarget].dropContents = gameObject;
        rotateBodyParts();
    }

    public void rotateBodyParts()
    {
        if (partDirection == 0)
        {
            if (startTarget == 0 || startTarget == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (startTarget == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (startTarget == 3 || startTarget == 4)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        else if (partDirection == 1)
        {
            if (startTarget == 0 || startTarget == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (startTarget == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (startTarget == 3 || startTarget == 4)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        } else if( partDirection== 2)
        {
            if (startTarget == 0 || startTarget == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (startTarget == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (startTarget == 3 || startTarget == 4)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        } else
        {
            if (startTarget == 0 || startTarget == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (startTarget == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (startTarget == 3 || startTarget == 4)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void FinishSwap()
    {
        //write part location to static int variable
        partLocations[partLocationRef] = startTarget;
        //write to global variable in Fungus
        /*if (flowOutput != null)
        {
            flowOutput.SetIntegerVariable(fungusVariable, startTarget);
        }*/
    }
}
