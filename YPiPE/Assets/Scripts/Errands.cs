using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Errands : MonoBehaviour
{

    public static bool[] errandToggles = { true,true,true,true,true };
    public GameObject interactionUI;
    public string fungusInt;
    public Flowchart flowRef;
    public int errandNumber;
    public Sprite fullMail;

    private SpriteRenderer mailboxImage;

    private void Start()
    {
        if (fullMail)
        {
            if (errandToggles[errandNumber] == false)
            {
                mailboxImage = gameObject.GetComponent<SpriteRenderer>();
                mailboxImage.sprite = fullMail;
            }
        }
    }

    public void DeactivateButton(){
        errandToggles[errandNumber] = false;
        interactionUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flowRef.GetIntegerVariable(fungusInt) >= 1)
        {
            if (errandToggles[errandNumber] == true)
            {
                interactionUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionUI.SetActive(false);
    }

}
