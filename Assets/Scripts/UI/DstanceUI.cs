using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DistanceUI : MonoBehaviour
{

    [SerializeField] private GameObject scoreText = null;

    public void SetDistancText(float value)
    {
        scoreText.GetComponent<Text>().text = "目標までの距離:" + value.ToString("f1") + "m";
    }
}