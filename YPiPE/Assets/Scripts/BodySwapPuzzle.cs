using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BodySwapPuzzle : MonoBehaviour
{
    public string[] possibleCombinations;
    public Flowchart outFlow;
    public string fungusBool;

    private string currentOrientation;
    private int headLoc;
    private int bodyLoc;
    private int armRLoc;
    private int legRLoc;
    private int legLLoc;
    private int armLLoc;
    private Collider2D blockPassage;

    // Start is called before the first frame update
    void Start()
    {
        headLoc = outFlow.GetIntegerVariable("HeadLocation");
        bodyLoc = outFlow.GetIntegerVariable("BodyLocation");
        armRLoc = outFlow.GetIntegerVariable("ArmRLocation");
        legRLoc = outFlow.GetIntegerVariable("LegRLocation");
        legLLoc = outFlow.GetIntegerVariable("LegLLocation");
        armLLoc = outFlow.GetIntegerVariable("ArmLLocation");
        blockPassage = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        headLoc = outFlow.GetIntegerVariable("HeadLocation");
        bodyLoc = outFlow.GetIntegerVariable("BodyLocation");
        armRLoc = outFlow.GetIntegerVariable("ArmRLocation");
        legRLoc = outFlow.GetIntegerVariable("LegRLocation");
        legLLoc = outFlow.GetIntegerVariable("LegLLocation");
        armLLoc = outFlow.GetIntegerVariable("ArmLLocation");
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

  /*  private void OnTriggerStay2D(Collider2D collision)
    {
        headLoc = outFlow.GetIntegerVariable("HeadLocation");
        bodyLoc = outFlow.GetIntegerVariable("BodyLocation");
        armRLoc = outFlow.GetIntegerVariable("ArmRLocation");
        legRLoc = outFlow.GetIntegerVariable("LegRLocation");
        legLLoc = outFlow.GetIntegerVariable("LegLLocation");
        armLLoc = outFlow.GetIntegerVariable("ArmLLocation");
        currentOrientation = headLoc.ToString() + bodyLoc.ToString() + armRLoc.ToString() + legRLoc.ToString() + legLLoc.ToString() + armLLoc.ToString();
        for (int i = 0; i < possibleCombinations.Length; i++)
        {
            if (possibleCombinations[i] == currentOrientation)
            {
                blockPassage.enabled = false;
            } else
            {
                blockPassage.enabled = true;
            }
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (fungusBool == "none")
        {
            blockPassage.enabled = true;
        } else
        {
            outFlow.SetBooleanVariable(fungusBool, false);
        }
    }

}
