using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResearchType
{
    typeA,
    typeB
}

public class ResearchManager : MonoBehaviour
{

    [SerializeField] private int researchPoint;//開放させる覚えさせるためのポイント
    private bool[] researchs;//開放しているかどうかのフラグ  
    [SerializeField] private ResearchData[] researchDatas;//パラメーター

    public Text ResearchText;

    private void Awake()
    {
        //スキル数分の配列を確保
        researchs = new bool[researchDatas.Length];
    }

    public ResearchData GetResearchData(ResearchType researchType)
    {
        return researchDatas[(int)researchType];
    }

    //スキルを覚える
    public void SetResearch(ResearchType type, int point)
    {
        researchs[(int)type] = true;
        SetResearchPoint(point);
        SetText();
        CheckOnOff();
    }

    //スキルを覚えているかどうかのチェック
    public bool IsResearch(ResearchType type)
    {
        return researchs[(int)type];
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
    public bool Check(ResearchType type, int spendPoint = 0)
    {
        for (int i = 0; i < researchDatas.Length; i++)
        {
            if (researchDatas[i].ResearchType == type)
            {
                return researchDatas[i].ResearchCost <= spendPoint;
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
    public void OnClick(ResearchType type)
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

    //他のスキルを取得した後の自身のボタンの処理
    public void CheckOnOff(ResearchType type)
    {
        //スキルを覚えられるかチェック
        if (!Check(type))
        {
            ChangeButtonColor(new Color(0.8f, 0.8f, 0.8f, 0.8f));
            //スキルをまだ覚えていない
        }
        else if (!IsResearch(type))
        {
            ChangeButtonColor(new Color(1f, 1f, 1f, 1f));
        }
    }

    //ボタンの色変更
    public void ChangeButtonColor(Color color)
    {
        //ボタンコンポーネントを取得
        Button button = gameObject.GetComponent<Button>();
        //ボタンのカラー情報を取得(一時変数を作成し、色情報を変えてからそれをbutton.colorsに設定。じゃないとエラーになる)
        ColorBlock cb = button.colors;
        //取得済みのスキルボタンの色を変える。
        cb.normalColor = color;
        cb.pressedColor = color;
        //ボタンのカラー情報を設定
        button.colors = cb;
    }
}
