using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layering : MonoBehaviour
{

    public SpriteRenderer[] spriteObjects;
    public Transform UILocation;
    public Transform UIObject;

    private int[] startingSort;

    private void Start()
    {
        startingSort = new int[spriteObjects.Length];
        for (int i = 0; i < startingSort.Length; i++)
        {
            startingSort[i] = spriteObjects[i].sortingOrder;
        }
        setLayering();
    }


    public void setLayering()
    {
        for (int i = 0; i < spriteObjects.Length; i++)
        {
            spriteObjects[i].sortingOrder = (int)(transform.position.y * -100) + startingSort[i];
        }
        if (UILocation)
        {
            UIObject.position = UILocation.position;
        }
    }
}
