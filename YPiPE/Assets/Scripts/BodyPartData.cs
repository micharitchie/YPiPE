using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class BodyPartData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int slotID; //Should be used to keep track of what bodypart is in what slot
    private Transform originalParent;
    private Vector2 offset;

    public void SetOriginalParent(Transform t) { originalParent = t; }
    public Transform GetOriginalParent() { return originalParent; }
    public void UpdateSlot() {
        this.transform.SetParent(originalParent);
        this.transform.position = originalParent.transform.position;
        GameObject obj = this.transform.parent.gameObject;
        obj.GetComponent<BodyPartSlot>().SetPart(this);

    }

    // Start is called before the first frame update
    void Start()
    {
        originalParent = this.transform.parent;

        //This is a sad attempt at implementing a swap between the current bodypart and another one. This should be implement in PartSwapper, not here.
        GameObject obj = this.transform.parent.gameObject;
        obj.GetComponent<BodyPartSlot>().SetPart(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData _EventData)
    {
        //Offset so that the sprite doesn't lock onto the mouse when you click
        offset = _EventData.position - new Vector2(this.transform.position.x, this.transform.position.y);

        //Save the slot that this current sprite is in
        originalParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        this.transform.position = _EventData.position;

        //This is so that we can click through the sprite when we end the drag
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData _EventData)
    {
        //Have the sprite follow the mouse while clicking
        this.transform.position = _EventData.position - offset;
    }

    public void OnEndDrag(PointerEventData _EventData)
    {
        //This locks the bodyPart to the slot that it is hovering over
        //If it is not hovering over any slot, then originalParent is its old slot
        this.transform.SetParent(originalParent);
        this.transform.position = originalParent.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
