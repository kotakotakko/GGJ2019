using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviourFast<UIManager>
{
    [SerializeField] PowerSliderUI powerSliderUI = null;

    public void SetMinPower(float value)
    {
        powerSliderUI.SetMinPower(value);
    }

    public void SetMaxPower(float value)
    {
        powerSliderUI.SetMaxPower(value);
    }

    public void SetValue(float value)
    {
        powerSliderUI.SetValue(value);
    }
}
