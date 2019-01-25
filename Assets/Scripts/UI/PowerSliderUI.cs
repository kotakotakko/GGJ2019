using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class PowerSliderUI : MonoBehaviour
{

    [SerializeField] private Slider _slider;

    public void SetMinPower(float value)
    {
        _slider.minValue = value;
    }
    public void SetMaxPower(float value)
    {
        _slider.maxValue = value;
    }
    public void SetValue(float value)
    {
        _slider.value = value;
    }
}