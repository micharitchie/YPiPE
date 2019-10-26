using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PartyBlock : MonoBehaviour
{
    public GameObject Mayor;
    public GameObject MayorTeleport;
    public GameObject Rory;
    public Flowchart FirstFlowchart;


    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.collider.name == "VirtualRory")
        {
            Mayor.transform.position = transform.position;
            MayorTeleport.SetActive(true);
            if (Rory.transform.position.x <= Mayor.transform.position.x)
            {
                Mayor.transform.localScale = new Vector3( 1, 1, 1);
            } else
            {
                Mayor.transform.localScale = new Vector3(-1, 1, 1);
            }
            FirstFlowchart.ExecuteBlock("MayorBlock");
        }

    }
}
