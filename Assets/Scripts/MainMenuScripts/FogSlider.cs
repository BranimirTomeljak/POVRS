using UnityEngine;

public class FogSlider : MonoBehaviour
{
    public void OnValueChanged(float value)
    {
        PlayerPrefs.SetFloat("fogDensityValue", value);
    }
}
