using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class InteractableObjects : MonoBehaviour
{

	public GameObject lookUI;
    public GameObject lookIndicator;
    public string fungusBool;
    public Flowchart partyFlowchart;

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
        lookIndicator.SetActive(true);
        partyFlowchart.SetBooleanVariable(fungusBool, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        lookUI.SetActive(false);
        lookIndicator.SetActive(false);
        partyFlowchart.SetBooleanVariable(fungusBool, false);
    }
}
