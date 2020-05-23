using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LimitlessDev.RetroLookPro;

//This script can be deleted
public class PostProcessingFade : MonoBehaviour
{

    ///private ColorPalettePreset myCPP;
    //private RLProColormapPalette CMPVolume;
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
        fadeIn = !fadeIn;
    }
}
