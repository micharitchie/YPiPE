using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CharacterResponse : MonoBehaviour
{
    public Transform roryRef;
    public SpriteRenderer[] objectParts;
    public GameObject interactionUI;
    public string fungusBool;
    public Flowchart flowRef;
    public bool disableFlip;
    //public bool disableInteraction;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform == roryRef)
        {
            if (interactionUI)
            {
                interactionUI.transform.position = new Vector3(roryRef.position.x + 2.3f, roryRef.position.y + 4.2f, roryRef.position.z);
                interactionUI.SetActive(true);
            }
            if (flowRef) {
                flowRef.SetBooleanVariable(fungusBool, true);
            }
            if (!disableFlip)
            {
                if (roryRef.position.x <= transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            if (roryRef.position.y <= transform.position.y)
            {
                for (int i = 0; i < objectParts.Length; i++)
                {
                    objectParts[i].sortingLayerName = "NPC Behind";
                }

            }
            else
            {
                for (int i = 0; i < objectParts.Length; i++)
                {
                    objectParts[i].sortingLayerName = "NPC Front";
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactionUI)
        {
            interactionUI.transform.position = new Vector3(roryRef.position.x + 2.3f, roryRef.position.y + 4.2f, roryRef.position.z);
        }
        if (!disableFlip)
        {
            if (roryRef.position.x <= transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (roryRef.position.y <= transform.position.y)
        {
            for (int i = 0; i < objectParts.Length; i++)
            {
                objectParts[i].sortingLayerName = "NPC Behind";
            }

        }
        else
        {
            for (int i = 0; i < objectParts.Length; i++)
            {
                objectParts[i].sortingLayerName = "NPC Front";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == roryRef)
        {
            if (interactionUI)
            {
                interactionUI.SetActive(false);
            }
            if (flowRef)
            {
                flowRef.SetBooleanVariable(fungusBool, false);
            }
        }
    }

    public void ChangeButton(GameObject newButton)
    {
        interactionUI = newButton;
    }

    public void ToggleFlip()
    {
        disableFlip = !disableFlip;
    }

}
