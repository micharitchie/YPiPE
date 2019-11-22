using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentsScript : MonoBehaviour
{
    public Image ImageContainer;
    public Text TextContainer;

    public void setAnnounceImage(Sprite pImage)
    {
        ImageContainer.sprite = pImage;
    }

    public void setAnnounceText(string pText)
    {
        TextContainer.text = pText;
    }
    
}
