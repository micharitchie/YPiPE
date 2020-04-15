using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Tripwire : MonoBehaviour
{
    public Flowchart myFlowchart;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myFlowchart.ExecuteBlock("Tripwire");
    }
}
