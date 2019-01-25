using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DistanceUI : MonoBehaviour
{

    [SerializeField] private Text scoreText = null;

    public void SetDistancText(float value)
    {
        scoreText.text = "目標までの距離:" + value.ToString("f1") + "m";
    }
}