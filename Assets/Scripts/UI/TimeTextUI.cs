using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextUI : MonoBehaviour
{
    private Text text = null;
    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    public void SetTimeText(float time)
    {
        text.text = "Time:" + time.ToString("f0");
    }
}
