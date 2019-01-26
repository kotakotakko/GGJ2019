using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    OP,
    Title,
    StageSelect,
    Option,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
}

public class SceneChangeManager : SingletonMonoBehaviourFast<SceneChangeManager>
{

    public void LoadScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void LoadScene(int sceneNum)
    {
        Debug.Log("load");
        SceneManager.LoadScene(((SceneName)sceneNum).ToString());
    }
}
