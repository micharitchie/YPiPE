using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCtrl : MonoBehaviour
{
    public Sprite openDoor;
    public Sprite closedDoor;

    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            mySpriteRenderer.sprite = openDoor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "VirtualRory")
        {
            mySpriteRenderer.sprite = closedDoor;
        }
    }
}
