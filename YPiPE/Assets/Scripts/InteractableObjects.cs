using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractableObjects : MonoBehaviour
{

	public GameObject lookUI;
    //public Transform setLocation;
    public string fungusBool;
    public Flowchart targetFlowchart;
  
	private void OnTriggerEnter2D(Collider2D collision)
	{
        lookUI.SetActive(true);
        if (targetFlowchart != null)
        {
            targetFlowchart.SetBooleanVariable(fungusBool, true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        lookUI.SetActive(false);
        if (targetFlowchart != null)
        {
            targetFlowchart.SetBooleanVariable(fungusBool, false);
        }
    }

    public void ChangeUI(GameObject newUI)
    {
        lookUI = newUI;
    }

    public void ChangeFlow(Flowchart newFlow )
    {
        targetFlowchart = newFlow;
    }
}
