using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : SingletonMonoBehaviourFast<ResultController>
{ 
    [SerializeField] Text distanceScoreText = null;
    [SerializeField] Text rotateScoreText = null;
    [SerializeField] Text timeLimitScoreText = null;
    [SerializeField] Text totalScoreText = null;
    public void EnableResult(bool win,float distance,float rotate,float time)
    {
        for(var i = 0;i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void SetDistanceScoreText(int value)
    {
        distanceScoreText.text = value.ToString();
    }

    public void SetRotateScoreText(int value)
    {
        rotateScoreText.text = value.ToString();
    }

    public void SetTimeLimitScoreText(int value)
    {
        timeLimitScoreText.text = value.ToString();
    }

    public void SetTotalScoreText(int value)
    {
        totalScoreText.text = value.ToString();
    }
}
