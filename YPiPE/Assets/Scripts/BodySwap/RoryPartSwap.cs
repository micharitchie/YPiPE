using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RoryPartSwap : MonoBehaviour
{
    //public bool testParenting;
    public Transform[] locationRef;
    public Flowchart FlowInput;

    private Transform Head;
	private Transform Body;
    private Transform ArmL;
    private Transform ArmR;
    private Transform LegL;
    private Transform LegR;
    private Transform BodyParent;
    private Transform noParent;
    private Vector3[] slotPositions;

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
        noParent = transform.Find("VRMover");
        //slotPositions = new Vector3[] { Head.position, Body.position, ArmR.position, LegR.position, LegL.position, ArmL.position };
        slotPositions = new Vector3[] { locationRef[0].position, locationRef[1].position, locationRef[2].position, locationRef[3].position, locationRef[4].position, locationRef[5].position };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
        Head.position = slotPositions[FlowInput.GetIntegerVariable("HeadLocation")];
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
        locationRef[FlowInput.GetIntegerVariable("ArmLLocation")] = ArmL;
        SetRotation();
    }

    void SetRotation()
    {
        int headInt = FlowInput.GetIntegerVariable("HeadLocation");
        int bodyInt = FlowInput.GetIntegerVariable("BodyLocation");
        int armRInt = FlowInput.GetIntegerVariable("ArmRLocation");
        int legRInt = FlowInput.GetIntegerVariable("LegRLocation");
        int legLInt = FlowInput.GetIntegerVariable("LegLLocation");
        int armLInt = FlowInput.GetIntegerVariable("ArmLLocation");
        #region Head Conditionals
        if (headInt == 0)
        {
            Head.rotation = Quaternion.Euler(0, 0, 0);
        } else if (headInt == 1)
        {
            Head.rotation = Quaternion.Euler(0, 0, 0);
        } else if (headInt == 2)
        {
            Head.rotation = Quaternion.Euler(0, 0, -90);
        } else if(headInt == 3 || headInt == 4)
        {
            Head.rotation = Quaternion.Euler(0, 0, 180);
        } else if(headInt == 5)
        {
            Head.rotation = Quaternion.Euler(0, 0, 90);
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
            Body.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (bodyInt == 3 || bodyInt == 4)
        {
            Body.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (bodyInt == 5)
        {
            Body.rotation = Quaternion.Euler(0, 0, 90);
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
        else
        {
            LegR.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (legLInt <= 1)
        {
            LegL.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            LegL.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
    }

}