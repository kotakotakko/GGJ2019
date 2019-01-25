using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
