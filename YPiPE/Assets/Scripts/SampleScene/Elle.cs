using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Elle : MonoBehaviour
{
    public Flowchart flowchartRef;

    public void Mergey(float Floaty, string Stringy)
    {
        string Holdy;
        Holdy = Stringy + Floaty.ToString();
        flowchartRef.SendFungusMessage(Holdy);
    }
}
