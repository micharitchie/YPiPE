using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideableTile : MonoBehaviour
{
	public int row;
	public int collumn;
    public Vector2 startPos;
    public Vector2 endPos;
    public static bool slideIncomplete;


    // Start is called before the first frame update
    void Start()
    {
        startPos = endPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos != endPos)
        {
            if (Mathf.Abs(startPos.x - endPos.x) < .05f && Mathf.Abs(startPos.y - endPos.y) < .05f)
            {
                transform.position = endPos;
                startPos = transform.position;
            }
            else
            {
                transform.position = Vector2.Lerp(startPos, endPos, .3f);
            startPos = transform.position;
        }
            if (startPos == endPos)
            {
                slideIncomplete = false;
                transform.localScale = Vector3.one;
                
            } else
            {
                slideIncomplete = true;
            }
        }
    }
}
