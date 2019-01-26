using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MainScriptManager : SingletonMonoBehaviourFast<MainScriptManager>
{
    private const int DEFAULT_TOILET = 0;
    private const int DEFAULT_DISTANCE_SCORE = 5000;
    private const int DEFAULT_ROTATE_SCORE = 5000;
    private const int DEFAULT_TIME_SCORE = 3000;

    [SerializeField] private GameObject playerControllerObject = null;
    private PlayerController playerController = null;
    [SerializeField] private ResearchData toiletData = null;

    [SerializeField] private GameObject toiletSelectCanvas;

    private AchievementManager achievementManager = null;
    private ResearchData[] researchData;
    private GameObject toiletObject = null;
    private bool isPlay;
    private GameObject targetObject = null;

    [SerializeField] private GameObject parfectEffect = null;

    [SerializeField] private float timeLimit = 15.0f;
    [SerializeField] private float nowTime = 0.0f;

    [SerializeField] private float nearDistance = 0.0f;
    [SerializeField] private float limitDistance = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        achievementManager = this.gameObject.GetComponent<AchievementManager>();
        researchData = achievementManager.GetResearchDatas();
        achievementManager.OnCheck();
        playerController = playerControllerObject.GetComponent<PlayerController>();
        playerController.enabled = false;

        toiletSelectCanvas.SetActive(true);
        ToiletSelect toiletSelect = toiletSelectCanvas.GetComponent<ToiletSelect>();
        for(var i = 0;i < researchData.Length; i++)
        {
            if (achievementManager.GetResearchData(i)) { toiletSelect.UnLock(i); }
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
#endif

        if (isPlay)
        {
            nowTime += Time.deltaTime;
            if (nowTime > timeLimit)
            {
                isPlay = false;
            }
            UIManager.instance.SetTimeText(TimeLag());
        }
        if (toiletObject)
        {
            UIManager.instance.SetDistanceText(TargetDistance());
        }
    }

    public void Judge(bool inToilet, Quaternion toiletRotation)
    {
        //目標内なら5000点
        int score = inToilet ? DEFAULT_DISTANCE_SCORE : 0;
        Debug.Log(score);
        int distanceScore = (int)(Mathf.InverseLerp(limitDistance, nearDistance, TargetDistance()) * DEFAULT_DISTANCE_SCORE);
        Debug.Log(distanceScore);
        int timeScore = (int)((TimeLag() / timeLimit) * DEFAULT_TIME_SCORE);
        Debug.Log(timeScore);
        Debug.Log(18 - Mathf.RoundToInt(Quaternion.Angle(Quaternion.identity, toiletRotation) / 10.0f));
        Debug.Log(((18 - Mathf.RoundToInt(Quaternion.Angle(Quaternion.identity, toiletRotation) / 10.0f)) / 18.0f));
        int rotateScore = (int)((18 - Mathf.RoundToInt(Quaternion.Angle(Quaternion.identity, toiletRotation)/10.0f)) / 18.0f * DEFAULT_ROTATE_SCORE);
        Debug.Log(rotateScore);
        int totalScore = score + distanceScore + timeScore + rotateScore; 

        if(score + rotateScore == DEFAULT_DISTANCE_SCORE + DEFAULT_ROTATE_SCORE)
        {
            parfectEffect.SetActive(true);
        }

        ResultController.Instance.EnableResult(true, 0.0f, 0.0f, 0.0f);
        ResultController.instance.SetDistanceScoreText(distanceScore);
        ResultController.instance.SetTimeLimitScoreText(timeScore);
        ResultController.instance.SetRotateScoreText(rotateScore);
        ResultController.instance.SetTotalScoreText(totalScore);
    }

    private float TimeLag()
    {
        return timeLimit - nowTime;
    }

    public float TargetDistance()
    {
       return Vector2.Distance(toiletObject.transform.position, targetObject.transform.position) * 10.0f;
    }

    public void SetIsPlay(bool isPlay)
    {
        this.isPlay = isPlay;
    }

    public void SelectToilet(int type)
    {
//        toiletData = achievementManager.GetResearchData((ToiletType)type);
        playerController.enabled = true;
        playerController.SetIsInput(true);
        toiletObject = Instantiate(toiletData.Prefab, playerControllerObject.transform.position, Quaternion.identity);
        toiletObject.transform.SetParent(playerControllerObject.transform);
        toiletObject.transform.localPosition = Vector3.zero;
        playerController.SetToiletObject(toiletObject);
        targetObject = GameObject.Find("TargetPoint");
        toiletSelectCanvas.SetActive(false);
        isPlay = true;
    }
}
