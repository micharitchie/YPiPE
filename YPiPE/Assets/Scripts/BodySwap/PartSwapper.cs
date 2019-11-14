using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSwapper : MonoBehaviour
{
    int slotAmount = 6; //Hard-coded to the number of limbs we have to work with
    public List<BodyPartSlot> slots = new List<BodyPartSlot>();
    public List<BodyPartData> bodyParts = new List<BodyPartData>();

    // Start is called before the first frame update
    void Start()
    {
        //PartSwapper needs to be propagated with all of the specific slots and the current body parts in them

        //Should also have a way to communicate with the actual model that will be displayed

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
