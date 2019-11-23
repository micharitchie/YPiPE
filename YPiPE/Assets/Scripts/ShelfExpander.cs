using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfExpander : MonoBehaviour
{
	public float maxMaskWidth;
	private float expandSpeed;
	public static bool expandMask;
    private RectTransform maskSize;

    // Start is called before the first frame update
    void Start()
    {
		expandMask = false;
        maskSize = transform as RectTransform;
        expandSpeed = maxMaskWidth * 2;
    }

    // Update is called once per frame
    void Update()
    {
        float currentWidth = maskSize.sizeDelta.x;
        if (expandMask)
		{
            if (currentWidth >= maxMaskWidth)
            {
                maskSize.sizeDelta = new Vector2(maxMaskWidth, maskSize.sizeDelta.y);
            } else
            {
                maskSize.sizeDelta = new Vector2(currentWidth += expandSpeed * Time.deltaTime, maskSize.sizeDelta.y);
            }
        } else
        {
            if (currentWidth <= 20f)
            {
                maskSize.sizeDelta = new Vector2(20f, maskSize.sizeDelta.y);
            } else
            {
                maskSize.sizeDelta = new Vector2(currentWidth -= expandSpeed * Time.deltaTime, maskSize.sizeDelta.y);
            }
        }
    }

    public void SetMaxWidth(float newMaxWidth)
	{
		maxMaskWidth = newMaxWidth;
        expandSpeed = maxMaskWidth * 2;
    }

    public void ToggleExpandMask()
	{
		expandMask = !expandMask;
	}
}
