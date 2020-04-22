using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layering : MonoBehaviour
{

    public SpriteRenderer[] spriteObjects;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spriteObjects.Length; i++)
        {
            spriteObjects[i].sortingOrder += (int)(transform.position.y * -100);
        }
    }
}
