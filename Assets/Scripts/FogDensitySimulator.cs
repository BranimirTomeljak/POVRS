using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDensitySimulator : MonoBehaviour
{
    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = FogSlider.fogDensityValue;      //[0, 0.05f]
        RenderSettings.fogEndDistance = 3000f;                      //3000 metara
    }

}
