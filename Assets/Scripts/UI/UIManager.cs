using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviourFast<UIManager>
{
    [SerializeField] PowerSliderUI powerSliderUI = null;
    //目標までの距離
    [SerializeField] DistanceUI distanceUI = null;
    //残り時間
    [SerializeField] TimeTextUI timeTextUI = null;

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

    public void SetDistanceText(float value)
    {
        distanceUI.SetDistanceText(value);
    }

    public void SetTimeText(float time)
    {
        timeTextUI.SetTimeText(time);
    }
}
