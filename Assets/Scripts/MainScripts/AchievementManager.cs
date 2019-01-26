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
    private bool[] researchs = null;
    [SerializeField] private ResearchData[] researchDatas = null;//便器データ

    public Text ResearchText;

    private void Awake()
    {
        //スキル数分の配列を確保
        achievements = new bool[achievementDatas.Length];
        researchs = new bool[researchDatas.Length];
    }

    public ResearchData[] GetResearchDatas()
    {
        return researchDatas;
    }

    public bool GetResearchData(int i)
    {
        return researchs[i];
    }

    public AchievementData[] GetAchievementDatas()
    {
        return achievementDatas;
    }

    public bool[] GetAchievements()
    {
        return achievements;
    }

    public bool CheckResearchData(ResearchData researchData)
    {
        for (int i = 0; i < researchDatas.Length; i++)
        {
            if (researchDatas[i] == researchData)
            {
                return researchs[i];
            }
        }
        return false;
    }
    //アチーブメントを達成にする
    public void SetAchievement(int i)
    {
        achievements[i] = true;
    }

    //researchを達成にする
    public void SetResearch(int i)
    {
        if (achievementDatas[i].ResearchData1 == null)
        {
            return;
        }

        for (int j = 0; j < researchDatas.Length; j++)
        {
            if(researchDatas[j] == achievementDatas[i].ResearchData1)
            {
                researchs[j] = true;
            }
        }
        
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
                    SetResearch(i);
                }
            }
        }
        
    }


}
