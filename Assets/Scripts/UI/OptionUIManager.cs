using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUIManager : SingletonMonoBehaviourFast<OptionUIManager>
{
    [SerializeField] private Text playTime = null;
    [SerializeField] private Text throwCount = null;
    [SerializeField] private Text totalCarry = null;
    [SerializeField] private Text clearCount = null;
    [SerializeField] private Text perfectCount = null;
    [SerializeField] private Text continuousCount = null;

    [SerializeField] private Button japanBottan;
    [SerializeField] private Button englishBottan;

    [SerializeField] private GameObject achievementDisplayFrame;//prefab
    [SerializeField] private GameObject parentAchievementDisplayFrame;//アチーブメント表示の親
    [SerializeField] private AchievementManager achievementManager;
    [SerializeField] private GameObject achievementDisplay;
    private RectTransform rectAchievementDisplay;

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
    public void SetPerfectCount(string text)
    {
        perfectCount.text = text;
    }
    public void ContinuousCount(string text)
    {
        continuousCount.text = text;
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
    public void SetPerfectCount(int num)
    {
        perfectCount.text = num.ToString();
    }
    public void ContinuousCount(int text)
    {
        continuousCount.text = text.ToString();
    }

    private GameObject[] achievementDisplayFrames;

    private void Start()
    {
        rectAchievementDisplay = achievementDisplay.GetComponent<RectTransform>();
        CreateViewAchievementList();
    }

    public void OptionOpen()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        SetPlaytime((int)PlayerStatus.GetPlayTime());
        SetThrowCount(PlayerStatus.GetThorwCount());
        SetTotalCarry((int)PlayerStatus.GetTotalCarry());
        SetClearCount(PlayerStatus.GetClearCount());
        SetPerfectCount(PlayerStatus.GetPerfectsCount());
        ContinuousCount(0);
        CreateViewAchievementList();
        rectAchievementDisplay = achievementDisplay.GetComponent<RectTransform>();
    }

    public void OptionClose()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        DestroyViewAchievementList();
    }

    public void CreateViewAchievementList()
    {
        AchievementData[] achievementDatas = achievementManager.GetAchievementDatas();
        bool[] achievements = achievementManager.GetAchievements();

        var y = (rectAchievementDisplay.rect.height-15)/6;//パネルサイズ取得

        achievementDisplayFrames = new GameObject[achievementDatas.Length];
        for (int i = 0; i < achievementDatas.Length; i++)
        {
            GameObject frameObject = Instantiate(achievementDisplayFrame) as GameObject;
            frameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(frameObject.GetComponent<RectTransform>().sizeDelta.x, y);
            Debug.Log(frameObject);
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
