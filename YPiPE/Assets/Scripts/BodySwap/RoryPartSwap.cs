using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RoryPartSwap : MonoBehaviour
{
    //public bool testParenting;
    public Transform[] locationRef;
    //public Flowchart FlowInput;

    private Transform Head;
	private Transform Body;
    private Transform ArmL;
    private Transform ArmR;
    private Transform LegL;
    private Transform LegR;
    private Transform BodyParent;
    private Transform parentHolder;
    private Vector3[] slotPositions;
    //private Draggable staticVarAccess;

    // Start is called before the first frame update
    private void Awake()
    {
        Head = transform.Find("VRMover/VRBody/VirtualRoryBody/VRHead");
        Body = transform.Find("VRMover/VRBody");
        ArmL = transform.Find("VRMover/VRBody/VirtualRoryBody/VRArmL");
        ArmR = transform.Find("VRMover/VRBody/VirtualRoryBody/VRArmR");
        LegL = transform.Find("VRMover/VRLegL");
        LegR = transform.Find("VRMover/VRLegR");
        BodyParent = transform.Find("VRMover/VRBody/VirtualRoryBody"); 
        //noParent = transform.Find("VRMover");
        //slotPositions = new Vector3[] { Head.position, Body.position, ArmR.position, LegR.position, LegL.position, ArmL.position };
        slotPositions = new Vector3[] { locationRef[0].position, locationRef[1].position, locationRef[2].position, locationRef[3].position, locationRef[4].position, locationRef[5].position };
    }
    
    public void ClearParent()
    {
        Transform[] tempChildren = new Transform[BodyParent.childCount];
        for (int i = 0; i < BodyParent.childCount; i++)
        {
            tempChildren[i] = BodyParent.GetChild(i);
        }
        BodyParent = transform.Find("VRMover");
        for (int i = 0; i < tempChildren.Length; i++)
        {
            tempChildren[i].parent = BodyParent;
        }
        slotPositions = new Vector3[] { locationRef[0].position, locationRef[1].position, locationRef[2].position, locationRef[3].position, locationRef[4].position, locationRef[5].position };
    }
    public void SwapParts()
    {
        ClearParent();
        Head.position = slotPositions[Draggable.partLocations[0]];
        Body.position = slotPositions[Draggable.partLocations[1]];
        ArmR.position = slotPositions[Draggable.partLocations[2]];
        LegR.position = slotPositions[Draggable.partLocations[3]];
        LegL.position = slotPositions[Draggable.partLocations[4]];
        ArmL.position = slotPositions[Draggable.partLocations[5]];
        locationRef[Draggable.partLocations[0]] = Head;
        locationRef[Draggable.partLocations[1]] = Body;
        locationRef[Draggable.partLocations[2]] = ArmR;
        locationRef[Draggable.partLocations[3]] = LegR;
        locationRef[Draggable.partLocations[4]] = LegL;
        locationRef[Draggable.partLocations[5]] = ArmL;
        /*Head.position = slotPositions[FlowInput.GetIntegerVariable("HeadLocation")];
        Body.position = slotPositions[FlowInput.GetIntegerVariable("BodyLocation")];
        ArmR.position = slotPositions[FlowInput.GetIntegerVariable("ArmRLocation")];
        LegR.position = slotPositions[FlowInput.GetIntegerVariable("LegRLocation")];
        LegL.position = slotPositions[FlowInput.GetIntegerVariable("LegLLocation")];
        ArmL.position = slotPositions[FlowInput.GetIntegerVariable("ArmLLocation")];
        locationRef[FlowInput.GetIntegerVariable("HeadLocation")] = Head;
        locationRef[FlowInput.GetIntegerVariable("BodyLocation")] = Body;
        locationRef[FlowInput.GetIntegerVariable("ArmRLocation")] = ArmR;
        locationRef[FlowInput.GetIntegerVariable("LegRLocation")] = LegR;
        locationRef[FlowInput.GetIntegerVariable("LegLLocation")] = LegL;
        locationRef[FlowInput.GetIntegerVariable("ArmLLocation")] = ArmL;*/
        SetRotation();
        //SetParent();
    }

    void SetParent()
    {
        BodyParent = locationRef[1].GetChild(0);
        locationRef[0].parent = BodyParent;
        locationRef[2].parent = BodyParent;
        locationRef[5].parent = BodyParent;
    }

    void SetRotation()
    {
        int headInt = Draggable.partLocations[0];
        int bodyInt = Draggable.partLocations[1];
        int armRInt = Draggable.partLocations[2];
        int legRInt = Draggable.partLocations[3];
        int legLInt = Draggable.partLocations[4];
        int armLInt = Draggable.partLocations[5];
        /*int headInt = FlowInput.GetIntegerVariable("HeadLocation");
        int bodyInt = FlowInput.GetIntegerVariable("BodyLocation");
        int armRInt = FlowInput.GetIntegerVariable("ArmRLocation");
        int legRInt = FlowInput.GetIntegerVariable("LegRLocation");
        int legLInt = FlowInput.GetIntegerVariable("LegLLocation");
        int armLInt = FlowInput.GetIntegerVariable("ArmLLocation");*/
        #region Head Conditionals
        if (headInt == 0)
        {
            Head.rotation = Quaternion.Euler(0, 0, 0);
        } else if (headInt == 1)
        {
            Head.rotation = Quaternion.Euler(0, 0, 0);
        } else if (headInt == 2)
        {
            if (transform.localScale.x < 0)
            {
                Head.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                Head.rotation = Quaternion.Euler(0, 0, -90);
            }
        } else if(headInt == 3 || headInt == 4)
        {
            Head.rotation = Quaternion.Euler(0, 0, 180);
        } else if(headInt == 5)
        {
            if (transform.localScale.x < 0)
            {
                Head.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                Head.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        #endregion
        #region Body Conditionals
        if (bodyInt == 0)
        {
            Body.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (bodyInt == 1)
        {
            Body.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (bodyInt == 2)
        {
            if (transform.localScale.x < 0)
            {
                Body.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                Body.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
        else if (bodyInt == 3 || bodyInt == 4)
        {
            Body.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (bodyInt == 5)
        {
            if (transform.localScale.x < 0)
            {
                Body.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                Body.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        #endregion
        #region Arm Conditionals
        if (armRInt <= 1)
        {
            ArmR.rotation = Quaternion.Euler(0, 0, 180);
        }
        else 
        {
            ArmR.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (armLInt <= 1)
        {
            ArmL.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            ArmL.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
        #region Leg Conditionals
        if (legRInt <= 1)
        {
            LegR.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (legRInt == 2)
        {
            if (transform.localScale.x < 0)
            {
                LegR.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                LegR.rotation = Quaternion.Euler(0, 0, 90);
            }
        } else if (legRInt == 3 || legRInt == 4)
        {
            LegR.rotation = Quaternion.Euler(0, 0, 0);
        } else if (legRInt == 5)
        {
            if (transform.localScale.x < 0)
            {
                LegR.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                LegR.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
        if (legLInt <= 1)
        {
            LegL.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if(legLInt == 2)
        {
            if (transform.localScale.x < 0)
            {
                LegL.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                LegL.rotation = Quaternion.Euler(0, 0, 90);
            }
        } else if(legLInt == 3 || legLInt == 4)
        {
            LegL.rotation = Quaternion.Euler(0, 0, 0);
        } else if (legLInt == 5)
        {
            if (transform.localScale.x < 0)
            {
                LegL.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                LegL.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
        #endregion
    }

}