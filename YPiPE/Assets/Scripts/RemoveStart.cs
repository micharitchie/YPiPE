using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStart : MonoBehaviour
{
    public GameObject itemToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemToDestroy != null)
        {
            if (transform.position.x >= 0)
            {
                Destroy(itemToDestroy);
            }
        }
    }
}
