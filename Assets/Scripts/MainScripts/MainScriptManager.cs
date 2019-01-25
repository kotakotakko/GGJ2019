using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MainScriptManager : SingletonMonoBehaviourFast<MainScriptManager>
{
    [SerializeField] PlayerController playerController = null;
    private GameObject toiletObject = null;
    private GameObject targetObject = null;

    // Start is called before the first frame update
    void Start()
    {
        playerController.SetIsInput(true);
        toiletObject = GameObject.Find("Toilet");
        targetObject = GameObject.Find("TargetPoint");
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
#endif

        Debug.Log(Vector2.Distance(toiletObject.transform.position, targetObject.transform.position) * 10.0f);
    }
}
