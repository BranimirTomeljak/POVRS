using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDensitySimulator : MonoBehaviour
{
    void Awake()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = PlayerPrefs.GetFloat("fogDensityValue");    //[0, 0.05f]
        RenderSettings.fogEndDistance = 3000f;                                  //3000 metara
    }

}
