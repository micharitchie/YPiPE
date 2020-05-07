using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BodySwapPuzzle : MonoBehaviour
{
    public string[] possibleCombinations;
    public Flowchart outFlow;
    public string fungusBool;
    public int[] specificLocations;

    private string currentOrientation;
    private int headLoc;
    private int bodyLoc;
    private int armRLoc;
    private int legRLoc;
    private int legLLoc;
    private int armLLoc;
    private bool checkTrigger;
    private Collider2D blockPassage;

    // Start is called before the first frame update
    void Start()
    {
        headLoc = Draggable.partLocations[0];
        bodyLoc = Draggable.partLocations[1];
        armRLoc = Draggable.partLocations[2];
        legRLoc = Draggable.partLocations[3];
        legLLoc = Draggable.partLocations[4];
        armLLoc = Draggable.partLocations[5];
        blockPassage = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        headLoc = Draggable.partLocations[0];
        bodyLoc = Draggable.partLocations[1];
        armRLoc = Draggable.partLocations[2];
        legRLoc = Draggable.partLocations[3];
        legLLoc = Draggable.partLocations[4];
        armLLoc = Draggable.partLocations[5];
        
        currentOrientation = headLoc.ToString() + bodyLoc.ToString() + armRLoc.ToString() + legRLoc.ToString() + legLLoc.ToString() + armLLoc.ToString();
        for (int i = 0; i < possibleCombinations.Length; i++)
        {
            if (possibleCombinations[i] == currentOrientation)
            {
                if (fungusBool == "none")
                {
                    blockPassage.enabled = false;
                } else
                {
                    outFlow.SetBooleanVariable(fungusBool, true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        checkTrigger = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (fungusBool == "none")
        {
            blockPassage.enabled = true;
        } else
        {
            outFlow.SetBooleanVariable(fungusBool, false);
        }
        checkTrigger = false;
    }

    public void CheckParts()
    {
        if (checkTrigger)
        {
            headLoc = Draggable.partLocations[0];
            bodyLoc = Draggable.partLocations[1];
            armRLoc = Draggable.partLocations[2];
            legRLoc = Draggable.partLocations[3];
            legLLoc = Draggable.partLocations[4];
            armLLoc = Draggable.partLocations[5];
            currentOrientation = headLoc.ToString() + bodyLoc.ToString() + armRLoc.ToString() + legRLoc.ToString() + legLLoc.ToString() + armLLoc.ToString();
            Debug.Log(currentOrientation);
            for (int i = 0; i < possibleCombinations.Length; i++)
            {
                if (possibleCombinations[i] == currentOrientation)
                {
                    if (fungusBool == "none")
                    {
                        blockPassage.enabled = false;
                        break;
                    }
                    else
                    {
                        outFlow.SetBooleanVariable(fungusBool, true);
                        break;
                    }
                } else
                {
                    if (fungusBool == "none")
                    {
                        blockPassage.enabled = true;
                    }
                    else
                    {
                        outFlow.SetBooleanVariable(fungusBool, false);
                    }
                }
            }
        }
    }

    public void CheckSpecificParts(bool checkHead, bool checkBody, bool checkArmR, bool checkLegR, bool checkLegL, bool checkArmL)
    {
        headLoc = Draggable.partLocations[0];
        bodyLoc = Draggable.partLocations[1];
        armRLoc = Draggable.partLocations[2];
        legRLoc = Draggable.partLocations[3];
        legLLoc = Draggable.partLocations[4];
        armLLoc = Draggable.partLocations[5];
        bool partsMatch = false;

        if (checkHead)
        {
            if (headLoc == specificLocations[0])
            {
                partsMatch = true;
            } else
            {
                partsMatch = false;
            }
        }

        if (checkBody)
        {
            if (bodyLoc == specificLocations[1])
            {
                partsMatch = true;
            }
            else
            {
                partsMatch = false;
            }
        }

        if (checkArmR)
        {
            if(armRLoc == specificLocations[2]||armRLoc == specificLocations[5])
            {
                partsMatch = true;
                //Debug.Log("ArmR match");
            }
            else
            {
                partsMatch = false;
                //Debug.Log(armRLoc);
            }
        }

        if (checkLegR)
        {
            if(legRLoc == specificLocations[3] || legRLoc == specificLocations[4])
            {
                partsMatch = true;
            }
            else
            {
                partsMatch = false;
            }
        }

        if (checkLegL)
        {
            if (legLLoc == specificLocations[3] || legLLoc == specificLocations[4])
            {
                partsMatch = true;
            }
            else
            {
                partsMatch = false;
            }
        }

        if (checkArmL)
        {
            if (armLLoc == specificLocations[2] || armLLoc == specificLocations[5])
            {
                partsMatch = true;
                //Debug.Log("ArmL Match");
            }
            else
            {
                partsMatch = false;
                //Debug.Log(armLLoc);
            }
        }


        outFlow.SetBooleanVariable(fungusBool, partsMatch);
    }

    public void ShelfCheck()
    {
        armRLoc = Draggable.partLocations[2];
        armLLoc = Draggable.partLocations[5];
        if (armLLoc == 0 || armRLoc == 0)
        {
            outFlow.SetBooleanVariable(fungusBool, true);
        } else
        {
            outFlow.SetBooleanVariable(fungusBool, false);
            Debug.Log("Left Arm" + armLLoc + "Right Arm" + armRLoc);
        }
    }

}
