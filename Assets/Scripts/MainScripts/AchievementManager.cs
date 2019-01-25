using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ToiletType
{
    typeA,
    typeB
}

public enum AchievementConditionType
{
    ThrowCount,
    ClearStage,
    StageClearCount,
    MissCount,
    ContinuousCount,
    PerfectsCount
}

public class AchievementManager : MonoBehaviour
{

    [SerializeField] private int researchPoint = 0;//開放させる覚えさせるためのポイント
    private bool[] achievements = null;//開放しているかどうかのフラグ  
    [SerializeField] private AchievementData[] achievementDatas = null;//アチーブメントデータ
    [SerializeField] private List<ResearchData> researchDatas = new List<ResearchData>();//便器データ
    [SerializeField] private ResearchData defoResearchData = null;

    public Text ResearchText;

    private void Awake()
    {
        //スキル数分の配列を確保
        achievements = new bool[achievementDatas.Length];
    }

    private void Start()
    {
        researchDatas.Add(defoResearchData);
    }

    public List<ResearchData> GetResearchDatas()
    {
        return researchDatas;
    }

    public ResearchData GetResearchData(ToiletType toiletType)
    {
        return researchDatas[(int)toiletType];
    }

    //アチーブメントを達成にする
    public void SetAchievement(int i)
    {
        achievements[i] = true;
    }

    //アチーブメントが達成しているかをチェック
    public bool Check(AchievementData achievementData)
    {
        switch (achievementData.AchievementConditionType)
        {
            case AchievementConditionType.ClearStage:
                if (true)
                {
                    return true;
                }
            case AchievementConditionType.ContinuousCount:
                if (true)
                {
                    return true;
                }
            case AchievementConditionType.MissCount:
                if (true)
                {
                    return true;
                }
            case AchievementConditionType.PerfectsCount:
                if (true)
                {
                    return true;
                }
            case AchievementConditionType.StageClearCount:
                if (true)
                {
                    return true;
                }
            case AchievementConditionType.ThrowCount:
                if (true)
                {
                    return true;
                }
        }

        return false;
    }

    //スキルボタンを押した際に実行するメソッド
    public void OnClick()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            //アチーブメントを達成していなければ
            if (achievements[i] == false)
            {
                if (Check(achievementDatas[i]))
                {
                    SetAchievement(i);
                    researchDatas.Add(achievementDatas[i].ResearchData1);
                }
            }
        }
        
    }


}
