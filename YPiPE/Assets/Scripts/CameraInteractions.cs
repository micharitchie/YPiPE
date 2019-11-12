using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractions : MonoBehaviour
{
    public float zoomSpeed;
    private bool zoomOut;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
		if (zoomOut)
		{
			Camera.main.orthographicSize += zoomSpeed * Time.deltaTime;
            if (Camera.main.orthographicSize >= 8f)
			{
				Camera.main.orthographicSize = 8f;
			}
		} else if (!zoomOut)
		{
			Camera.main.orthographicSize -= zoomSpeed * Time.deltaTime;
            if(Camera.main.orthographicSize <= 5f)
			{
				Camera.main.orthographicSize = 5f;
			}
		}
    }

    public void toggleZoom()
	{
		zoomOut = !zoomOut;
	}
}
