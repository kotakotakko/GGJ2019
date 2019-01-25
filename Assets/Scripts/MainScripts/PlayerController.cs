using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode throwButton = KeyCode.Mouse0;
    [SerializeField] private bool isInput = false;
    [SerializeField] private bool isPowerUp = true;

    [SerializeField] private float minPower = 1.0f;
    [SerializeField] private float maxPower = 10.0f;

    [SerializeField] private float nowPower = 0.0f;
    [SerializeField] private float addPower = 1.0f;

    [SerializeField] private Vector2 serializePos;
    [SerializeField] private Vector2 serializeToiletPos;
    [SerializeField] private GameObject toiletObject;
    [SerializeField] private Vector3 serializeThorw;

    void Start()
    {
        nowPower = minPower;
        UIManager.Instance.SetMinPower(minPower);
        UIManager.Instance.SetMaxPower(maxPower);
    }

    void Update()
    {
        if (isInput) { 
            if (Input.GetKey(throwButton)) { Charge(); }
            if (Input.GetKeyUp(throwButton)) { Thorw(); }
        }
    }

    //いつでも戦争が起きる
    private void Charge()
    {
        if(isPowerUp)
        {
            nowPower += addPower * Time.deltaTime;
        }
        else
        {
            nowPower -= addPower * Time.deltaTime;
        }

        if(minPower > nowPower) {
            nowPower = minPower;
            isPowerUp = true;
        }

        if(maxPower < nowPower) {
            nowPower = maxPower;
            isPowerUp = false;
        }

        UIManager.Instance.SetValue(nowPower);
    }

    private void Thorw()
    {
        //マウス位置座標をVector3で取得
        Vector2 pos = Input.mousePosition;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector2 worldPointPos = Camera.main.ScreenToWorldPoint(pos);

        //目的の座標をnormalizeする
        Vector2 thorwPoint = Vector3.Normalize(worldPointPos - (Vector2)toiletObject.transform.position);

        toiletObject.GetComponent<ToiletController>().Thorw(thorwPoint, nowPower);

        isInput = false;
    }

    public void SetIsInput(bool enable)
    {
        isInput = enable;
    }
}
