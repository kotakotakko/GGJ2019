using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : SingletonMonoBehaviourFast<ResultController>
{

    public void EnableResult(bool win,float distance,float rotate,float time)
    {
        for(var i = 0;i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
