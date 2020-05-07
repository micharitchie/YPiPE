using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractableObjects : MonoBehaviour
{

	public GameObject lookUI;
    public Transform setLocation;
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
        //Vector3 buttonLocation = new Vector3(setLocation.position.x + 2.3f, setLocation.position.y + 4.2f, setLocation.position.z);
        //lookUI.transform.position = buttonLocation;
        lookUI.SetActive(true);
        if (targetFlowchart != null)
        {
            targetFlowchart.SetBooleanVariable(fungusBool, true);
        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 buttonLocation = new Vector3(setLocation.position.x + 2.3f, setLocation.position.y + 4.2f, setLocation.position.z);
        lookUI.transform.position = buttonLocation;
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        lookUI.SetActive(false);
        //lookIndicator.SetActive(false);
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
