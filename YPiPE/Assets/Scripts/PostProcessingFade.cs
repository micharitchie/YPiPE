using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using RetroLookPro.Enums;

public class PostProcessingFade : MonoBehaviour
{

    //private PostProcessVolume activeVolume;
    private RLProColormapPalette CMPVolume;
    private bool fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        //CMPVolume = Get(Shader.Find("RetroLookPro/ColorPalette"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PixelsFade()
    {
        CMPVolume.pixelSize.value = 100;
    }
}
