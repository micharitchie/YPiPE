using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRestarts : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject ReloadButton;

    public void ActivateButtons()
    {
        RestartButton.SetActive(true);
        ReloadButton.SetActive(true);
    }
}
