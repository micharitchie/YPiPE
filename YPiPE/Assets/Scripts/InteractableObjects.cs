using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractableObjects : MonoBehaviour
{

	public GameObject lookUI;
    public string fungusBool;
    public Flowchart targetFlowchart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        lookUI.SetActive(true);
        lookUI.transform.position = transform.position;
        if (targetFlowchart != null)
        {
            targetFlowchart.SetBooleanVariable(fungusBool, true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        lookUI.SetActive(false);
        //lookIndicator.SetActive(false);
        if (targetFlowchart != null)
        {
            targetFlowchart.SetBooleanVariable(fungusBool, false);
        }
    }
}
