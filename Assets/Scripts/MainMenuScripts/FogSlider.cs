using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSlider : MonoBehaviour
{
    public static float fogDensityValue = 0f;

    public void OnValueChanged(float value)
    {
        fogDensityValue = value;
    }

}
