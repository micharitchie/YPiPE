using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPartSwap : MonoBehaviour
{

    public Transform Head;
    public Transform Body;
    public Transform ArmL;
    public Transform LegL;
    public Transform LegR;
    public Transform ArmR;

    private Transform[] slotTransforms;
    private Vector3[] slotPositions;
    //public Vector3[] swappedSlotPositions;
    public int[] newSlotNumbers;

    // Start is called before the first frame update
    void Awake()
    {
        //slotTransforms = new Transform[] { Head, Body, ArmL, LegL, LegR, ArmR };
        slotPositions = new Vector3[] { Head.position, Body.position, ArmL.position, LegL.position, LegR.position, ArmR.position };
    }

    public void SwapParts()
    {
        Head.position = slotPositions[newSlotNumbers[0]];
        Body.position = slotPositions[newSlotNumbers[1]];
        ArmL.position = slotPositions[newSlotNumbers[2]];
        LegL.position = slotPositions[newSlotNumbers[3]];
        LegR.position = slotPositions[newSlotNumbers[4]];
        ArmR.position = slotPositions[newSlotNumbers[5]];
        SetRotation();
    }

    private void SetRotation()
    {
        #region Head Conditionals
        if (newSlotNumbers[0] == 0 || newSlotNumbers[0] == 1)
        {
            Head.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        else if (newSlotNumbers[0] == 2)
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
        else if (newSlotNumbers[0] == 3 || newSlotNumbers[0] == 4)
        {
            Head.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (newSlotNumbers[0] == 5)
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
        if (newSlotNumbers[1] == 0 || newSlotNumbers[1] == 1)
        {
            Body.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (newSlotNumbers[1] == 2)
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
        else if (newSlotNumbers[1] == 3 || newSlotNumbers[1] == 4)
        {
            Body.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (newSlotNumbers[1] == 5)
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
        //right arm
        if (newSlotNumbers[5] <= 1)
        {
            ArmR.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            ArmR.rotation = Quaternion.Euler(0, 0, 0);
        }
        //left arm
        if (newSlotNumbers[2] <= 1)
        {
            ArmL.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            ArmL.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion
        #region Leg Conditionals
        //right leg
        if (newSlotNumbers[4] <= 1)
        {
            LegR.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (newSlotNumbers[4] == 2)
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
        else if (newSlotNumbers[4] == 3 || newSlotNumbers[4] == 4)
        {
            LegR.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (newSlotNumbers[4] == 5)
        {
            if (transform.localScale.x < 0)
            {
                LegR.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                LegR.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        // left leg
        if (newSlotNumbers[3] <= 1)
        {
            LegL.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (newSlotNumbers[3] == 2)
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
        else if (newSlotNumbers[3] == 3 || newSlotNumbers[2] == 4)
        {
            LegL.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (newSlotNumbers[3] == 5)
        {
            if (transform.localScale.x < 0)
            {
                LegL.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                LegL.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        #endregion
    }
}
