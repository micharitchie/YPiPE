using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideableTile : MonoBehaviour
{
	public int row;
	public int collumn;
    public Vector2 startPos;
    public Vector2 endPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = endPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startPos != endPos)
        {
            transform.position = Vector2.Lerp(startPos, endPos, .2f);
            startPos = transform.position;
        }
    }
}
