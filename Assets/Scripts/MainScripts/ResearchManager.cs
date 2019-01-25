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

    //スキルを覚える
    public void SetResearch(AchievementConditionType type, int point)
    {
        achievements[(int)type] = true;
        SetResearchPoint(point);
        SetText();
        CheckOnOff();
    }

    //スキルを覚えているかどうかのチェック
    public bool IsResearch(AchievementConditionType type)
    {
        return achievements[(int)type];
    }

    //スキルポイントを減らす
    public void SetResearchPoint(int point)
    {
        researchPoint -= point;
    }

    //スキルポイントを取得
    public int GetSkillPoint()
    {
        return researchPoint;
    }

    //ここforで回す。
    //スキルを覚えられるかチェック
    public bool Check(AchievementConditionType type, int spendPoint = 0)
    {
        for (int i = 0; i < achievementDatas.Length; i++)
        {
            if (achievementDatas[i].ReleaseConditionType == type)
            {
                return true;
            }
        }

        return false;
    }

    private void CheckOnOff()
    {
        //ボタン用の覚えれるかチェック
    }

    private void SetText()
    {
        ResearchText.text = "スキルポイント：" + researchPoint;
    }

    //スキルボタンを押した際に実行するメソッド
    public void OnClick(AchievementConditionType type)
    {
        //スキルを覚えていたら何もせずreturn
        if (IsResearch(type))
        {
            return;
        }
        //スキルを覚えられるかチェック
        if (Check(type, researchPoint))
        {
            SetResearch(type, researchPoint);
            //以下覚えた際のUI側処理
        }
        else
        {
            //以下覚えられなかった時のUI側処理
        }
    }


}
