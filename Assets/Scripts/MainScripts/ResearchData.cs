using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchData", menuName = "ResearchData")]
public class ResearchData : ScriptableObject
{

    [SerializeField] private GameObject prefab = null;//ゲームオブジェクトのプレハブ
    [SerializeField] private string researchName = null;//object名
    [SerializeField] private string researchInfo = null;//objectinfo
    [SerializeField] private int researchCost = 0;//研究コスト
    [SerializeField] private ResearchType researchType = ResearchType.typeA;//研究種別

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }

    public string ResearchName
    {
        get
        {
            return researchName;
        }
    }

    public string ResearchInfo
    {
        get
        {
            return researchInfo;
        }
    }

    public int ResearchCost
    {
        get
        {
            return researchCost;
        }
    }

    public ResearchType ResearchType
    {
        get
        {
            return researchType;
        }
    }
}
