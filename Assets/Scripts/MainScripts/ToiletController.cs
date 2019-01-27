using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletController : MonoBehaviour
{
    private bool isCheck;
    private bool inToilet;
    [SerializeField] private GameObject dustObject;
    Rigidbody2D rb;
    private AudioSource audioSource;
    private void Start()
    {
        inToilet = false;
        isCheck = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        audioSource = Camera.main.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheck && rb.IsSleeping())
        {
            isCheck = false;
            StartCoroutine(GoJudge());
        }
    }

    public IEnumerator GoJudge()
    {
        yield return new WaitForSeconds(1.0f);
        PlayerStatus.AddTotalCarry(Vector3.Distance(transform.parent.position,transform.position) * 10.0f);
        MainScriptManager.Instance.Judge(inToilet, this.transform.rotation);
    }

    //投げる処理
    public void Thorw(Vector2 thorwPoint,float nowPower)
    {
        rb.velocity = thorwPoint * nowPower;
        rb.angularVelocity = thorwPoint.magnitude * nowPower * 300.0f;
        isCheck = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground" && isCheck)
        {
            audioSource.PlayOneShot(audioSource.clip);
            GameObject obj = Instantiate(dustObject, transform.position, Quaternion.Euler(90.0f,0.0f,0.0f));
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
