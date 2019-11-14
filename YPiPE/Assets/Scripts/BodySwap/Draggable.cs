using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fungus;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject[] dropTargets;
    public int startTarget;
    public int partDirection;
    public Flowchart flowOutput;
    public string fungusVariable;

    private GameObject itemBeingDragged;
    private Vector3 startPos;
    private GameObject swapRef;
    private Droppable[] dropScripts;
    private Draggable[] otherParts;
    private RoryPartSwap RPSScript;


    // Start is called before the first frame update
    void Start()
    {
        dropScripts = new Droppable[dropTargets.Length];
        otherParts = new Draggable[dropTargets.Length];
        for(int i = 0; i < dropTargets.Length; i++)
        {
            dropScripts[i] = dropTargets[i].GetComponent<Droppable>();
            otherParts[i] = dropScripts[i].dropContents.GetComponent<Draggable>();
        }
        startPos = transform.position;
        RPSScript = GameObject.Find("VirtualRory").GetComponent<RoryPartSwap>();
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for(int i = 0; i < dropTargets.Length; i++)
        {
            float distance = Vector3.Distance(itemBeingDragged.transform.position, dropTargets[i].transform.position);
            if (distance < 50)
            {
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
        //write to global variable in Fungus
        if (flowOutput != null)
        {
            flowOutput.SetIntegerVariable(fungusVariable, startTarget);
        }
    }
}
