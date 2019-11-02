using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorInteraction : MonoBehaviour
{
    public GameObject Rory;
    public GameObject MayorHead;
    public GameObject MayorBody;
    public GameObject MayorArmR;
    public GameObject MayorArmL;
    public GameObject MayorLegR;
    public GameObject MayorLegL;
    public GameObject speachBubble;
    public bool mayorDeactivated;
    public bool mayorWalk;
    public Sprite speakSprite;

    private SpriteRenderer MH;
    private SpriteRenderer MB;
    private SpriteRenderer MAR;
    private SpriteRenderer MAL;
    private SpriteRenderer MLR;
    private SpriteRenderer MLL;
    private SpriteRenderer speachGraphic;
    private Animator anim;
    private Collider2D interactableArea;

    // Start is called before the first frame update
    void Start()
    {
        //mayorSprite = GetComponent<SpriteRenderer>();
        MH = MayorHead.GetComponent<SpriteRenderer>();
        MB = MayorBody.GetComponent<SpriteRenderer>();
        MAR = MayorArmR.GetComponent<SpriteRenderer>();
        MAL = MayorArmL.GetComponent<SpriteRenderer>();
        MLR = MayorLegR.GetComponent<SpriteRenderer>();
        MLL = MayorLegL.GetComponent<SpriteRenderer>();
        speachGraphic = speachBubble.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        interactableArea = GetComponent<Collider2D>();
        if (mayorDeactivated)
        {
            interactableArea.enabled = false;
        }
        if (mayorWalk)
        {
            toggleWalk();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "VirtualRory")
        {
            if (speachGraphic.sprite != speakSprite)
            {
                speachGraphic.sprite = speakSprite;
            } 
            speachBubble.SetActive(true);
            if (Rory.transform.position.x <= transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if(Rory.transform.position.y <= transform.position.y)
            {
                MH.sortingLayerName = "NPC Behind";
                MB.sortingLayerName = "NPC Behind";
                MAL.sortingLayerName = "NPC Behind";
                MAR.sortingLayerName = "NPC Behind";
                MLL.sortingLayerName = "NPC Behind";
                MLR.sortingLayerName = "NPC Behind";

            } else
            {
                MH.sortingLayerName = "NPC Front";
                MB.sortingLayerName = "NPC Front";
                MAL.sortingLayerName = "NPC Front";
                MAR.sortingLayerName = "NPC Front";
                MLL.sortingLayerName = "NPC Front";
                MLR.sortingLayerName = "NPC Front";
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "VirtualRory")
        {

            if (Rory.transform.position.x <= transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Rory.transform.position.y <= transform.position.y)
            {
                MH.sortingLayerName = "NPC Behind";
                MB.sortingLayerName = "NPC Behind";
                MAL.sortingLayerName = "NPC Behind";
                MAR.sortingLayerName = "NPC Behind";
                MLL.sortingLayerName = "NPC Behind";
                MLR.sortingLayerName = "NPC Behind";

            }
            else
            {
                MH.sortingLayerName = "NPC Front";
                MB.sortingLayerName = "NPC Front";
                MAL.sortingLayerName = "NPC Front";
                MAR.sortingLayerName = "NPC Front";
                MLL.sortingLayerName = "NPC Front";
                MLR.sortingLayerName = "NPC Front";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            speachBubble.SetActive(false);
        }
    }
    public void toggleWalk()
    {
        anim.SetBool("MayorWalking", true);
    }

    public void toggleInteractable()
    {
        interactableArea.enabled = !interactableArea.enabled;
    }

}
