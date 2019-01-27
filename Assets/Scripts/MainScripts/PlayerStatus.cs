using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StageData
{
    public string stageName;
    public string sceneName;        //シーン移行するやつ
    public bool stageClear;
    public int score;               //スコア
    public int continuousCount;     //連続クリア
}

public class PlayerStatus : MonoBehaviour
{

    public static StageData[] stageDatas = new StageData[5];
    public static float playTime = 0.0f;
    public static int missCount;           //何回失敗したか(failedが好ましい気がする)
    public static int clearCount;          //何回クリアしたか
    public static int perfectsCount;
    public static int thorwCount;
    public static float totalCarry;

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
            stageDatas[i].continuousCount = 0;
        }
        perfectsCount = 0;       //連続パーフェクト
        clearCount = 0;
        missCount = 0;
        playTime = 0.0f;
        thorwCount = 0;
        totalCarry = 0.0f;
    }

    public static StageData GetStageData(int stageId)
    {
        return stageDatas[stageId];
    }

    public static void SetStageClear(int stageId)
    {
        stageDatas[stageId].stageClear = true;
    }

    public static bool GetStageClear(string stageName)
    {
        for (var i = 0; i < stageDatas.Length; i++)
        {
            if (stageDatas[i].stageName == stageName)
            {
                return stageDatas[i].stageClear;
            }
        }
        return false;
    }

    public static float GetPlayTime()
    {
        return playTime;
    }

    public static void SetPlayTime(float value)
    {
        playTime = value;
    }

    public static int GetClearCount()
    {
        return clearCount;
    }

    public static void AddClearCount()
    {
        clearCount += 1;
    }

    public static int GetMissCount()
    {
        return missCount;
    }

    public static void AddMissCount()
    {
        missCount += 1;
    }

    public static float GetScore(int stageId)
    {
        return stageDatas[stageId].score;
    }

    public static void SetScore(int stageId, int value)
    {
        if (stageDatas[stageId].score > value)
        {
            stageDatas[stageId].score = value;
        }
    }

    public static void AddPerfectsCount()
    {
        perfectsCount += 1;
    }

    public static int GetPerfectsCount()
    {
        return perfectsCount;
    }

    public static void AddThorwCount()
    {
        thorwCount += 1;
    }

    public static int GetThorwCount()
    {
        return thorwCount;
    }

    public static void AddPlayTime(float value)
    {
        playTime += value;
    }

    public static float GetPlayTIme()
    {
        return playTime;
    }

    public static void AddTotalCarry(float value)
    {
        totalCarry += value;
    }

    public static float GetTotalCarry()
    {
        return totalCarry;
    }
}
