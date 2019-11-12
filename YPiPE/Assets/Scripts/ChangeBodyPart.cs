using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBodyPart : MonoBehaviour
{

    public static Sprite changeSprite;
    public Sprite mSprite;
    public static bool Selected;
    public static bool NewSprite;
    public bool ImSelected;

    // Start is called before the first frame update
    void Start()
    {
        Selected = false;
        NewSprite = false;
        ImSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ImSelected && NewSprite)
        {
            this.GetComponent<SpriteRenderer>().sprite = changeSprite;
            mSprite = changeSprite;
            ImSelected = false;
            NewSprite = false;
            Selected = false;
        }
    }

    void OnMouseDown()
    {
        if(!Selected)
        {
            Debug.Log("No Other Selection");
            changeSprite = mSprite;
            Selected = true;
            ImSelected = true;
        }
        else if(Selected && ImSelected)
        {
            Debug.Log("Nullified");
            Selected = false;
            ImSelected = false;
        }
        else
        {
            Debug.Log("Swap");
            Sprite temp = mSprite;
            mSprite = changeSprite;
            changeSprite = temp;
            this.GetComponent<SpriteRenderer>().sprite = mSprite;
            Selected = false;
            ImSelected = false;
            NewSprite = true;   
        }
    }
}
