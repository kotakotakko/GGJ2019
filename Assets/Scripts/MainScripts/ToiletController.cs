using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletController : MonoBehaviour
{
    private bool isCheck;
    private bool inToilet;
    [SerializeField] private GameObject dustObject;
    Rigidbody2D rb;

    private void Start()
    {
        inToilet = false;
        isCheck = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheck && rb.IsSleeping())
        {
            isCheck = false;
            Judge();
            Debug.Log("End");
        }
    }

    //判定
    private void Judge()
    {
        if (inToilet)
        {
            Debug.Log("勝ち");
        }
        else
        {
            Debug.Log("負け");
        }
    }

    //投げる処理
    public void Thorw(Vector2 thorwPoint,float nowPower)
    {
        rb.velocity = thorwPoint * nowPower;
        isCheck = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && isCheck)
        {
            GameObject obj = Instantiate(dustObject, transform.position, dustObject.transform.rotation);
            obj.SetActive(true);
            Destroy(obj, 0.7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("入った");
            inToilet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("出た");
            inToilet = false;
        }
    }
}
