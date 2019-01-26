using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletSelect : MonoBehaviour
{
    [SerializeField] GameObject[] lockImage = new GameObject[4]; 

    public void UnLock(int imageId)
    {
        Debug.Log("unlock");
        lockImage[imageId].SetActive(false);
    }
}