using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MainScriptManager : SingletonMonoBehaviourFast<MainScriptManager>
{
    [SerializeField] private GameObject playerControllerObject = null;
    private PlayerController playerController = null;
    [SerializeField] private ResearchData toiletData = null;
    private GameObject toiletObject = null;
    private bool isPlay;
    private GameObject targetObject = null;

    // Start is called before the first frame update
    void Start()
    {
        playerController = playerControllerObject.GetComponent<PlayerController>();
        playerController.SetIsInput(true);
        toiletObject = Instantiate(toiletData.Prefab, playerControllerObject.transform.position, Quaternion.identity);
        toiletObject.transform.SetParent(playerControllerObject.transform);
        toiletObject.transform.localPosition = Vector3.zero;
        playerController.SetToiletObject(toiletObject);
        targetObject = GameObject.Find("TargetPoint");
        isPlay = true;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
#endif

        if (isPlay)
        {
            UIManager.instance.SetDistanceText(Vector2.Distance(toiletObject.transform.position, targetObject.transform.position) * 10.0f);
        }
    }
}
