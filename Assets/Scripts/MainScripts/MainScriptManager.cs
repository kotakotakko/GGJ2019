using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#endif

public class MainScriptManager : SingletonMonoBehaviourFast<MainScriptManager>
{
    [SerializeField] PlayerController playerController;
    private bool isPlayerControll;
    private bool isToiletStopCheck;

    // Start is called before the first frame update
    void Start()
    {
        playerController.SetIsInput(true);
        isPlayerControll = true;
        isToiletStopCheck = false;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }
#endif
}
