using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUIManager : MonoBehaviour
{
    [SerializeField] private Text playTime = null;
    [SerializeField] private Text throwCount = null;
    [SerializeField] private Text totalCarry = null;
    [SerializeField] private Text clearCount = null;
    [SerializeField] private Text perfectCount = null;
    [SerializeField] private Text ContinuousCount = null;

    [SerializeField] private Button japanBottan;
    [SerializeField] private Button englishBottan;

    [SerializeField] private GameObject achievementDisplayFrame;//prefab
    [SerializeField] private GameObject parentAchievementDisplayFrame;//アチーブメント表示の親
    [SerializeField] private AchievementManager achievementManager;

    public void SetPlaytime(string text)
    {
        playTime.text = text;
    }
    public void SetThrowCount(string text)
    {
        throwCount.text = text;
    }
    public void SetTotalCarry(string text)
    {
        totalCarry.text = text;
    }
    public void SetClearCount(string text)
    {
        clearCount.text = text;
    }
    public void SetperfectCount(string text)
    {
        perfectCount.text = text;
    }
    public void SetPlaytime(int num)
    {
        playTime.text = num.ToString();
    }
    public void SetThrowCount(int num)
    {
        throwCount.text = num.ToString();
    }
    public void SetTotalCarry(int num)
    {
        totalCarry.text = num.ToString();
    }
    public void SetClearCount(int num)
    {
        clearCount.text = num.ToString();
    }
    public void SetperfectCount(int num)
    {
        perfectCount.text = num.ToString();
    }

    private GameObject[] achievementDisplayFrames;

    public void OptionOpen()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OptionClose()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void CreateViewAchievementList()
    {
        AchievementData[] achievementDatas = achievementManager.GetAchievementDatas();
        bool[] achievements = achievementManager.GetAchievements();

        for (int i = 0; i < achievementDatas.Length; i++)
        {
            GameObject frameObject = Instantiate(achievementDisplayFrame) as GameObject;
            achievementDisplayFrames[i] = frameObject;

            string tmpText = "?????";

            frameObject.transform.parent = parentAchievementDisplayFrame.transform;

            if (achievements[i])
            {
                tmpText = achievementDatas[i].Info;
            }

            frameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = tmpText;
        }
    }

    public void DestroyViewAchievementList()
    {
        for (int i = 0; i < achievementDisplayFrames.Length; i++)
        {
            Destroy(achievementDisplayFrames[i]);
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
