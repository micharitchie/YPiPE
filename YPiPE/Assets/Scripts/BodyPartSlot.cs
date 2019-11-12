using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPartSlot : MonoBehaviour, IDropHandler
{
    public int id; //Currently unused - Should be used to keep track of what part this slot is supposed to hold

    private BodyPartData currPart;

    public void SetPart(BodyPartData b) {
        currPart = b;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //This allows the part to lock onto the slot it is dropped into
        //We also swap the parts here
        BodyPartData part = eventData.pointerDrag.GetComponent<BodyPartData>();
        currPart.SetOriginalParent(part.GetOriginalParent());
        currPart.UpdateSlot();
        part.SetOriginalParent(this.transform);
        currPart = part;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
