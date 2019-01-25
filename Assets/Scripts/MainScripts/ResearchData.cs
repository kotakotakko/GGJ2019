using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchData", menuName = "ResearchData")]
public class ResearchData : ScriptableObject
{

    [SerializeField] private GameObject prefab = null;//ゲームオブジェクトのプレハブ
    [SerializeField] private string researchName = null;//object名
    [SerializeField] private string researchInfo = null;//objectinfo

    public GameObject Prefab { get => prefab; }
    public string ResearchName { get => researchName; }
    public string ResearchInfo { get => researchInfo; }

}
