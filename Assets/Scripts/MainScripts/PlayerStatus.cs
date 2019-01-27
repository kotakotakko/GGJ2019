using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StageData
{
    public string stageName;
    public string sceneName;        //シーン移行するやつ
    public int score;               //スコア
    public int clearCount;          //何回クリアしたか
    public int missCount;           //何回失敗したか(failedが好ましい気がする)
    public int continuousCount;     //連続クリア
    public int perfectsCount;       //連続パーフェクト
}

public class PlayerStatus : MonoBehaviour
{

    public static StageData[] stageDatas = new StageData[5];
    public static float playTime = 0.0f;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        for(var i = 0;i< stageDatas.Length; i++)
        {
            stageDatas[i].stageName = "";
            stageDatas[i].sceneName = "";
            stageDatas[i].clearCount = 0;
            stageDatas[i].missCount = 0;
            stageDatas[i].continuousCount = 0;
            stageDatas[i].perfectsCount = 0;
        }
        playTime = 0.0f;
    }

    public static StageData GetStageData(int stageId)
    {
        return stageDatas[stageId];
    }

    public static void StageClear(int stageId)
    {
        stageDatas[stageId].clearCount += 1;
    }

    public static float GetPlayTime()
    {
        return playTime;
    }

    public static void SetPlayTime(float value)
    {
        playTime = value;
    }

    public static float GetClearCount(int stageId)
    {
        return stageDatas[stageId].clearCount;
    }

    public static void AddClearCount(int stageId)
    {
        stageDatas[stageId].clearCount += 1;
    }

    public static float GetMissCount(int stageId)
    {
        return stageDatas[stageId].missCount;
    }

    public static void AddMissCount(int stageId)
    {
        stageDatas[stageId].missCount += 1;
    }

    public static float GetMissScore(int stageId)
    {
        return stageDatas[stageId].missCount;
    }

    public static void SetMissScore(int stageId, int value)
    {
        if (stageDatas[stageId].score > value)
        {
            stageDatas[stageId].score = value;
        }
    }
}
