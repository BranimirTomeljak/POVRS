using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSlider : MonoBehaviour
{
    public void OnValueChanged(float value)
    {
        PlayerPrefs.SetFloat("fogDensityValue", value);
    }
}
