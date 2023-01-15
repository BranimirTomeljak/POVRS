using UnityEngine;

public class FogDensitySimulator : MonoBehaviour
{
    void Awake()
    {
        RenderSettings.fog = true;
        RenderSettings.fogDensity = PlayerPrefs.GetFloat("fogDensityValue");    //[0, 0.05f]
        RenderSettings.fogEndDistance = 1500f;                                  //1500 metara
    }

}
