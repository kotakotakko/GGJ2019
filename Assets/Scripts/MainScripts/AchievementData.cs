using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementData", menuName = "AchievementData")]
public class AchievementData : ScriptableObject
{
    [SerializeField] private int ThrowCount = 0;//投げた回数
    [SerializeField] private string ClearStage = null;//ステージ名
    [SerializeField] private int StageClearCount = 0;//ステージをclearした回数
    [SerializeField] private int MissCount = 0;//間違えた回数
    [SerializeField] private int ContinuousCount = 0;//連続クリア
    [SerializeField] private int PerfectsCount = 0;//連続パーフェクト
    [SerializeField] private AchievementConditionType achievementConditionType = AchievementConditionType.ClearStage;//アチーブメント
    [SerializeField] private ResearchData researchData = null;

    public int ThrowCount1 { get => ThrowCount; }
    public string ClearStage1 { get => ClearStage; }
    public int StageClearCount1 { get => StageClearCount; }
    public int MissCount1 { get => MissCount; }
    public int ContinuousCount1 { get => ContinuousCount; }
    public int PerfectsCount1 { get => PerfectsCount; }
    public AchievementConditionType AchievementConditionType { get => achievementConditionType; }
    public ResearchData ResearchData1 { get => researchData; }
}
